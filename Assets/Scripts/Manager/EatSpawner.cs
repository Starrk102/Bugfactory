using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Eat.Factory;
using Eat.Factory.Interface;
using Eat.Pool;
using Zenject;
using Random = UnityEngine.Random;

namespace Manager
{
    public class EatSpawner : IInitializable, IDisposable
    {
        private IEatFactory factory;
        private CancellationTokenSource cts;

        [Inject]
        public EatSpawner(IEatFactory factory)
        {
            this.factory = factory;
        }
    
        public void Initialize()
        {
            cts = new CancellationTokenSource();
            Loop(cts.Token).Forget();
        }

        private async UniTaskVoid Loop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                Spawn();
                await UniTask.Delay(2000, cancellationToken: token);
            }
        }

        private void Spawn()
        {
            var pos = Random.insideUnitCircle * 10;
            factory.Create(pos);
        }
    
        public void Dispose()
        {
            cts.Cancel();
        }
    }
}

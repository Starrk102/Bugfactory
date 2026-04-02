using Cysharp.Threading.Tasks;

namespace Manager
{
    public class LifetimeSystem
    {
        public void Attach(Bug.Bug bug)
        {
            Run(bug).Forget();
        }

        private async UniTaskVoid Run(Bug.Bug bug)
        {
            await UniTask.Delay(10000);
            bug.Die();
        }
    }
}
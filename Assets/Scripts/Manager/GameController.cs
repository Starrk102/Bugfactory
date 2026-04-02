using System;
using System.Collections.Generic;
using System.Threading;
using Bug.Factory.Interface;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using IInitializable = Zenject.IInitializable;
using Random = UnityEngine.Random;

namespace Manager
{
    public class GameController : IInitializable, IDisposable
    {
        public List<Bug.Bug> bugs = new();
        public List<Bug.Bug> toAdd = new();
        public List<Bug.Bug> toRemove = new();
        private IBugFactory factory;

        private CancellationTokenSource cts;

        [Inject]
        public GameController(IBugFactory factory)
        {
            this.factory = factory;
        }
    
        public void Initialize()
        {
            cts = new CancellationTokenSource();

            var newBug = factory.CreateWorker(Random.insideUnitCircle);
            Register(newBug);
            
            GameLoop(cts.Token).Forget();
        }

        async UniTaskVoid GameLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                foreach (var bug in bugs)
                {
                    bug.ActionUpdate();
                }
                
                if (toAdd.Count > 0)
                {
                    bugs.AddRange(toAdd);
                    toAdd.Clear();
                }

                if (toRemove.Count > 0)
                {
                    foreach (var bug in toRemove)
                    {
                        bug.OnDied -= OnBugDied;
                        bugs.Remove(bug);
                    }
                
                    toRemove.Clear();
                }
                
                if (bugs.Count == 0 && toAdd.Count == 0)
                {
                    SpawnNewWorker();
                }

                await UniTask.Yield();
            }
        }
        
        public void Register(Bug.Bug bug)
        {
            toAdd.Add(bug);
            bug.OnDied += OnBugDied;
        }
        
        private void SpawnNewWorker()
        {
            var pos2D = Random.insideUnitCircle * 5;
            var pos = new Vector3(pos2D.x, 0, pos2D.y);

            var bug = factory.CreateWorker(pos);
            Register(bug);
        }
        
        private void OnBugDied(Bug.Bug bug)
        {
            toRemove.Add(bug);
        }
    
        public void Dispose()
        {
            cts.Cancel();
        }
    }
}
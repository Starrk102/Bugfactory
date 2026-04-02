using Bug.Factory.Interface;
using Manager;
using Split.Interface;
using UnityEngine;
using Zenject;

namespace Split
{
    public class SplitWorker : ISplit
    {
        private IBugFactory factory;
        private GameController gameController;
        
        [Inject]
        public SplitWorker(IBugFactory factory, GameController gameController)
        {
            this.factory = factory;
            this.gameController = gameController;
        }
        
        public void TrySplit(Bug.Bug bug)
        {
            if (bug.food < bug.bugConfig.splitThreshold)
            {
                return;
            }

            if (Random.value < 0.1f)
            {
                var newBug = factory.CreatePredator(bug.Pos);
                gameController.Register(newBug);
            }
            else
            {
                var newBug = factory.CreateWorker(bug.Pos);
                gameController.Register(newBug);
            }
        
            bug.food = 0;
        }
    }
}
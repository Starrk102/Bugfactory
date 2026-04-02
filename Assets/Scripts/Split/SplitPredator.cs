using Bug.Factory.Interface;
using Split.Interface;
using Zenject;

namespace Split
{
    public class SplitPredator : ISplit
    {
        private IBugFactory factory;

        [Inject]
        public SplitPredator(IBugFactory factory)
        {
            this.factory = factory;
        }
        
        public void TrySplit(Bug.Bug bug)
        {
            if (bug.food < bug.bugConfig.splitThreshold)
            {
                return;
            }

            factory.CreatePredator(bug.Pos);
            factory.CreatePredator(bug.Pos);
        
            bug.food = 0;
        }
    }
}
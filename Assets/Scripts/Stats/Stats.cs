using System;
using Interface;

namespace Stats
{
    public class Stats
    {
        public int DeadWorkers { get; private set; }
        public int DeadPredators { get; private set; }

        public event Action<EntityType> OnChanged;

        public void OnBugDied(Bug.Bug bug)
        {
            if (bug.Type == EntityType.Worker)
                DeadWorkers++;
            else if (bug.Type == EntityType.Predator)
                DeadPredators++;

            OnChanged?.Invoke(bug.Type);
        }
        
    }
}
using System;
using Bug.Factory.Interface;
using Bug.Pool;
using Eat;
using Interface;
using Manager;
using Movement;
using Split;
using UnityEngine;
using Zenject;

namespace Bug.Factory
{
    public class BugFactory : IBugFactory
    {
        private DiContainer container;
        private BugPool pool;
        private EatRegistry eatCount;
        private LifetimeSystem lifetime;
        
        private BugConfig.BugConfig workerConfig;
        //private BugConfig.BugConfig predatorConfig;
        
        [Inject]
        public BugFactory(DiContainer container, BugPool pool, 
            BugConfig.BugConfig workerConfig, /*BugConfig.BugConfig predatorConfig,*/
            EatRegistry eatCount, LifetimeSystem lifetime)
        {
            this.container = container;
            this.pool = pool;
            this.workerConfig = workerConfig;
            //this.predatorConfig = predatorConfig;
            this.eatCount = eatCount;
            this.lifetime = lifetime;
        }

        public global::Bug.Bug CreateWorker(Vector3 pos)
        {
            var bug = container.Instantiate<global::Bug.Bug>(new object[]
            {
                new SmartMovement(),
                new Target.Target(eatCount),
                new EatFood(),
                container.Instantiate<SplitWorker>(),
                workerConfig
            });

            var view = pool.Get();
            view.transform.position = pos;
            view.SetTypeBug(Color.yellow);

            view.Construct(bug, pool);
            bug.Type = EntityType.Worker;
            bug.SetView(view);

            lifetime.Attach(bug);
            
            return bug;
        }
    
        public global::Bug.Bug CreatePredator(Vector3 pos)
        {
            var bug = container.Instantiate<global::Bug.Bug>(new object[]
            {
                new SmartMovement(),
                new Target.AnyTarget(eatCount),
                new EatEverything(),
                container.Instantiate<SplitPredator>(),
                workerConfig
            });

            var view = pool.Get();
            view.transform.position = pos;
            view.SetTypeBug(Color.red);
            
            view.Construct(bug, pool);
            bug.Type = EntityType.Predator;
            bug.SetView(view);

            lifetime.Attach(bug);
            
            return bug;
        }
    }
}
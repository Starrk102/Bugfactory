using System.Collections.Generic;
using Bug.View;
using Zenject;

namespace Bug.Pool
{
    public class BugPool
    {
        private DiContainer container;
        private BugView prefab;
        private Queue<BugView> pool = new();

        [Inject]
        public BugPool(DiContainer container, BugView prefab)
        {
            this.container = container;
            this.prefab = prefab;
        }
    
        public BugView Get()
        {
            if (pool.Count > 0)
            {
                var bug = pool.Dequeue();
                bug.gameObject.SetActive(true);
                return bug;
            }
        
            return CreateNew();
        }

        public void Return(BugView bug)
        {
            bug.gameObject.SetActive(false);
            pool.Enqueue(bug);
        }

        public BugView CreateNew()
        {
            return container.InstantiatePrefabForComponent<BugView>(prefab);
        }
    }
}
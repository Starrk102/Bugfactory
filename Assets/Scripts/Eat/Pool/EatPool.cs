using System.Collections.Generic;
using Eat.View;
using UnityEngine;
using Zenject;

namespace Eat.Pool
{
    public class EatPool
    {
        private DiContainer container;
        private EatView prefab;

        private Queue<EatView> pool = new();

        [Inject]
        public EatPool(DiContainer container, EatView prefab)
        {
            this.container = container;
            this.prefab = prefab;
        }

        public EatView Get(Vector3 pos)
        {
            var food = pool.Count > 0 ? pool.Dequeue() : CreateNew();

            food.transform.position = pos;
            food.gameObject.SetActive(true);

            return food;
        }

        public void Return(EatView food)
        {
            food.gameObject.SetActive(false);
            pool.Enqueue(food);
        }

        public EatView CreateNew()
        {
            return container.InstantiatePrefabForComponent<EatView>(prefab);
        }
    }
}
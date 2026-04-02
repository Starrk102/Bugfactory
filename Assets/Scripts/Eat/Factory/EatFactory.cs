using Eat.Factory.Interface;
using Eat.Pool;
using Interface;
using Manager;
using UnityEngine;

namespace Eat.Factory
{
    public class EatFactory : IEatFactory
    {
        private EatPool pool;
        private EatRegistry eatCount;

        public EatFactory(EatPool pool, EatRegistry eatCount)
        {
            this.pool = pool;
            this.eatCount = eatCount;
        }

        public void Create(Vector3 pos)
        {
            var view = pool.Get(pos);
            var eat = new Eat(pos, view, pool, eatCount);
            eat.Type = EntityType.Food;
            eatCount.Entities.Add(eat);
        }
    }
}
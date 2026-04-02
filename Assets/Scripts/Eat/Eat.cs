using Eat.Pool;
using Eat.View;
using Interface;
using Manager;
using UnityEngine;

namespace Eat
{
    public class Eat : IEntity
    {
        public EntityType Type { get; set; }
        public Vector3 Pos { get; private set; }

        private EatView view;
        private EatPool pool;
        private EatRegistry eatRegistry;

        public Eat(Vector3 pos, EatView view, EatPool pool, EatRegistry eatRegistry)
        {
            Pos = pos;
            this.view = view;
            this.pool = pool;
            this.eatRegistry = eatRegistry;
        }

        public void Consume()
        {
            eatRegistry.Entities.Remove(this);
            pool.Return(view);
        }
    }
}
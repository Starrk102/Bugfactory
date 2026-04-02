using System;
using Bug.View.Interface;
using Eat.Interface;
using Interface;
using Manager;
using Movement.Interface;
using Split.Interface;
using Target.Interface;
using UnityEngine;
using Zenject;

namespace Bug
{
    public class Bug : IEntity
    {
        public int food;

        public event Action<Bug> OnDied;
        
        public BugConfig.BugConfig bugConfig { get; }
        public IEntity CurrentTarget { get; set; }

        private IBugView view;
        private IMovement movement;
        private IEat eat;
        public ITarget target;
        private ISplit split;

        private bool isDead;
        
        public Bug(IMovement movement, IEat eat, ITarget target, ISplit split, BugConfig.BugConfig bugConfig)
        {
            this.movement = movement;
            this.eat = eat;
            this.target = target;
            this.split = split;
            this.bugConfig = bugConfig;
        }
    
        public void SetView(IBugView view)
        {
            this.view = view;
        }

        public void ActionUpdate()
        {
            CurrentTarget = target.GetTarget(this);

            movement.Move(this);

            if (CurrentTarget != null)
            {
                float dist = Vector3.Distance(Pos, CurrentTarget.Pos);

                if (dist < 0.5f)
                {
                    eat.Eat(this, CurrentTarget);
                    CurrentTarget = null;
                }
            }

            split.TrySplit(this);

            view?.SetPosition(Pos);
        }
    
        public void Eat()
        {
            food++;
        }

        public void Die()
        {
            if (isDead)
            {
                return;
            }

            isDead = true;
            OnDied?.Invoke(this);
            view?.Death();
        }

        public EntityType Type { get; set; }
        public Vector3 Pos { get; set; }

        public void Consume()
        {
            Die();
        }
    }
}
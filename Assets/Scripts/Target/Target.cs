using Bug.View;
using Interface;
using Manager;
using Target.Interface;
using UnityEngine;

namespace Target
{
    public class Target : ITarget
    {
        private EatRegistry eatCount;

        public Target(EatRegistry eatCount)
        {
            this.eatCount = eatCount;
        }

        public IEntity GetTarget(Bug.Bug bug)
        {
            IEntity closest = null;
            float minDist = float.MaxValue;

            foreach (var entity in eatCount.Entities)
            {
                if (entity.Type != EntityType.Food)
                    continue;

                float dist = Vector3.Distance(bug.Pos, entity.Pos);

                if (dist < minDist)
                {
                    minDist = dist;
                    closest = entity;
                }
            }

            return closest;
        }
    
    }
}
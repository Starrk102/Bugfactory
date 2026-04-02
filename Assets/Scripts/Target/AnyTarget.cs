using Bug.View;
using Interface;
using Manager;
using Target.Interface;
using UnityEngine;

namespace Target
{
    public class AnyTarget : ITarget
    {
        private EatRegistry eatCount;
    
        public AnyTarget(EatRegistry eatCount)
        {
            this.eatCount = eatCount;
        }
    
        public IEntity GetTarget(Bug.Bug bug)
        {
            IEntity bestTarget = null;
            float bestScore = float.MaxValue;

            foreach (var entity in eatCount.Entities)
            {
                if (entity == bug) continue;

                float dist = Vector3.Distance(bug.Pos, entity.Pos);

                float score = GetScore(entity, dist);

                if (score < bestScore)
                {
                    bestScore = score;
                    bestTarget = entity;
                }
            }

            return bestTarget;
        }
        
        private float GetScore(IEntity entity, float distance)
        {
            switch (entity.Type)
            {
                case EntityType.Worker:
                    return distance * 0.5f;

                case EntityType.Predator:
                    return distance * 1.2f;

                case EntityType.Food:
                    return distance * 2f;

                default:
                    return distance;
            }
        }
    }
}

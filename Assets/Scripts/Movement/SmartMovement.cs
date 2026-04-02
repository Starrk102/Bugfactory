using Movement.Interface;
using UnityEngine;

namespace Movement
{
    public class SmartMovement : IMovement
    {
        private Vector3 randomDir;
        private float timer;
    
        public void Move(Bug.Bug bug)
        {
            float speed = bug.bugConfig.speed;
            
            if (bug.CurrentTarget != null)
            {
                var dir = (bug.CurrentTarget.Pos - bug.Pos).normalized;
                bug.Pos += dir * speed * Time.deltaTime;
                return;
            }

            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                randomDir = Random.onUnitSphere;
                randomDir.y = 0;
                randomDir.Normalize();

                timer = Random.Range(1f, 3f);
            }

            bug.Pos += randomDir * speed * Time.deltaTime;
        }
    }
}
using Bug.StateMachine.Interface;
using UnityEngine;

namespace Bug.StateMachine.State
{
    public class WanderState : IBugState
    {
        private Vector3 dir;
        private float timer;

        public void Enter(Bug bug)
        {
            SetRandom();
        }

        public void Update(Bug bug)
        {
            var target = bug.target.GetTarget(bug);

            if (target != null)
            {
                bug.CurrentTarget = target;
                //bug.ChangeState(new ChaseState());
                return;
            }

            timer -= Time.deltaTime;

            if (timer <= 0)
                SetRandom();

            bug.Pos += dir * Time.deltaTime * 2f;
        }

        public void Exit(Bug bug) { }

        void SetRandom()
        {
            dir = Random.onUnitSphere;
            dir.y = 0;
            dir.Normalize();

            timer = Random.Range(1f, 3f);
        }
    }
}
using Bug.StateMachine.Interface;

namespace Bug.StateMachine
{
    public class BugStateMachine
    {
        private IBugState currentState;
        private Bug bug;

        public BugStateMachine(Bug bug)
        {
            this.bug = bug;
        }

        public void ChangeState(IBugState newState)
        {
            currentState?.Exit(bug);
            currentState = newState;
            currentState.Enter(bug);
        }

        public void Update()
        {
            currentState?.Update(bug);
        }
    }
}
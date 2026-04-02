
namespace Bug.StateMachine.Interface
{
    public interface IBugState
    {
        void Enter(Bug bug);
        void Update(Bug bug);
        void Exit(Bug bug);
    }
}
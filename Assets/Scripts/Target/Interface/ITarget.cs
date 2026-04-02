using Interface;

namespace Target.Interface
{
    public interface ITarget
    {
        IEntity GetTarget(Bug.Bug bug);
    }
}
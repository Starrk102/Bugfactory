using Interface;

namespace Eat.Interface
{
    public interface IEat
    {
        void Eat(Bug.Bug bug, IEntity target);
    }
}
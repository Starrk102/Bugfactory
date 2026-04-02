using Eat.Interface;
using Interface;

namespace Eat
{
    public class EatFood : IEat
    {
        public void Eat(Bug.Bug bug, IEntity target)
        {
            target.Consume();
            bug.Eat();
        }
    }
}
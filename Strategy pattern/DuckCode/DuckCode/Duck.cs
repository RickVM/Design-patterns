using System;

namespace DuckCode
{
    public abstract class Duck
    {
        protected IFlyBehavior flyBehavior;
        protected IQuackBehavior quackBehavior;
        
        public Duck()
        {
            flyBehavior = null;
            quackBehavior = null;
        }

        public abstract void Display();

        public void PerformFly()
        {
            flyBehavior.Fly();
        }

        public void PerformQuack()
        {
            quackBehavior.Quack();
        }

        public void Swim()
        {
            Console.WriteLine("All ducks float, even decoys!");
        }

        public void SetFlyBehavior(IFlyBehavior behavior)
        {
            flyBehavior = behavior;
        }

        public void SetQuackBehavior(IQuackBehavior behavior)
        {
            quackBehavior = behavior;
        }
    }
}
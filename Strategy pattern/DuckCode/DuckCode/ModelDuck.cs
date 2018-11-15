using System;

namespace DuckCode
{
    public class ModelDuck : Duck
    {
        public ModelDuck()
        {
            flyBehavior = new FlyNoWay();
            quackBehavior = new Quacker();;
        }

        public override void Display()
        {
            Console.WriteLine("I'm a model Duck.");
        }
    }
}
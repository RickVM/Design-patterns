using System;

namespace DuckCode
{
    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            quackBehavior = new Quacker();
            flyBehavior = new FlyWithWings();
        }
        public override void Display()
        {
            Console.WriteLine("I'm a real mallard duck.");
        }
    }
}
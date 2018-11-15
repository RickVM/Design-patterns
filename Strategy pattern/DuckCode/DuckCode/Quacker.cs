using System;

namespace DuckCode
{
    public class Quacker : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Quack");
        }
    }
}
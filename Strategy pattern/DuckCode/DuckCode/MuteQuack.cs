using System;

namespace DuckCode
{
    public class MuteQuack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("");
        }
    }
}
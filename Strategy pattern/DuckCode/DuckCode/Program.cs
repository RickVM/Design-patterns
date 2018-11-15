using System;

namespace DuckCode
{
    class Program
    {
        static void Main(string[] args)
        {
           Duck mallard = new MallardDuck();
            mallard.PerformQuack();
            mallard.PerformFly();
            
            Duck modelDuck = new ModelDuck();
            modelDuck.PerformFly();
            modelDuck.SetFlyBehavior(new FlyRocketPowered());
            modelDuck.PerformFly();
        }
    }
}
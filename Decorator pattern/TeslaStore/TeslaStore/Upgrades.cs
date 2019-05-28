using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaStore
{
    class LongRange : CarDecorator
    {
        public LongRange(CarDecorator component)
        {
            this.Component = component;
            this.Price = 10000;
            this.Description = "Long range";
        }
    }

    class Performance : CarDecorator
    {
        public Performance(CarDecorator component)
        {
            this.Component = component;
            this.Price = 10000;
            this.Description = "Performance";
        }
    }

    class FullAutoPilot : CarDecorator
    {

        public FullAutoPilot(CarDecorator component)
        {
            this.Component = component;
            this.Price = 6400;
            this.Description = "Full Autonomous driving";
        }
    }

    class Towbar : CarDecorator
    {

        public Towbar(CarDecorator component)
        {
            this.Component = component;
            this.Price = 1080;
            this.Description = "Towbar";
        }
    }

}

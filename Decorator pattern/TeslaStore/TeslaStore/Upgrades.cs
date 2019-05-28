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
            this.cost = 10000;
            this.descriptor = "Long range";
        }
    }

    class Performance : CarDecorator
    {
        public Performance(CarDecorator component)
        {
            this.Component = component;
            this.cost = 10000;
            this.descriptor = "Performance";
        }
    }

    class FullAutoPilot : CarDecorator
    {

        public FullAutoPilot(CarDecorator component)
        {
            this.Component = component;
            this.cost = 6400;
            this.descriptor = "Full Autonomous driving";
        }
    }

    class Towbar : CarDecorator
    {

        public Towbar(CarDecorator component)
        {
            this.Component = component;
            this.cost = 1080;
            this.descriptor = "Towbar";
        }
    }

}

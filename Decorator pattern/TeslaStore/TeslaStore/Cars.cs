using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaStore
{

    class ModelS : CarDecorator
    {
        public ModelS()
        {
            this.Component = null;
            this.cost = 79200;
            this.descriptor = "Model S";
        }
    }

    class Model3 : CarDecorator
    {
        public Model3()
        {
            this.Component = null;
            this.cost = 47800;
            this.descriptor = "Model 3";
        }
    }

    class ModelX : CarDecorator
    {
        public ModelX()
        {
            this.Component = null;
            this.cost = 85000;
            this.descriptor = "Model X";
        }

    }

    class ModelY : CarDecorator
    {
        public ModelY()
        {
            this.Component = null;
            this.cost = 57000;
            this.descriptor = "Model Y";
        }
    }


}

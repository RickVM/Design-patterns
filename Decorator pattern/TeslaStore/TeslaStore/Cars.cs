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
            this.Price = 79200;
            this.Description = "Model S";
        }
    }

    class Model3 : CarDecorator
    {
        public Model3()
        {
            this.Component = null;
            this.Price = 47800;
            this.Description = "Model 3";
        }
    }

    class ModelX : CarDecorator
    {
        public ModelX()
        {
            this.Component = null;
            this.Price = 85000;
            this.Description = "Model X";
        }

    }

    class ModelY : CarDecorator
    {
        public ModelY()
        {
            this.Component = null;
            this.Price = 57000;
            this.Description = "Model Y";
        }
    }


}

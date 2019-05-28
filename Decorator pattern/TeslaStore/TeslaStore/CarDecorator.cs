using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaStore
{
    // The abstract decorator class gives us the ability to declare a default format for returning descriptions and prices.
    abstract class CarDecorator
    {

        protected CarDecorator Component { get; set; } // Public getter to enable dynamic removal at runtime

        // Protected members ensure that only the derived class can access these variables. 
        // If we set them during construction we can use them in our default format.
        //protected string descriptor;
        private string description;
        public string Description
        {
            get
            {
                // Since base cars are CarDecators without components we need to check.
                string baseComponentDescriptor = (this.Component != null ? this.Component.Description : "");
                return $"{baseComponentDescriptor}, {this.description}";
            }
            protected set
            {
                this.description = value;
            }
        }

        private double price;
        public double Price
        {
            get
            {
                // Since base cars are CarDecators without components we need to check.
                double baseComponentPrice = (this.Component != null ? this.Component.Price : 0);
                return baseComponentPrice + this.price;
            }
            protected set
            {
                this.price = value;
            }
        }

        // Returning a CarDecorator is required to support removal of the master decorator. This is done by returning the child.
        // In all other cases the requested object will be removed and the original master will be returned.
        public CarDecorator RemoveDecorator(Type toBeRemovedComponent)
        {
            if (this.Component == null)
            {
                //Do Nothing, no wrapped classes available
                return this;
            }
            else if (this.GetType() == toBeRemovedComponent)  // Master decorator needs to be removed
            {
                return this.Component; // Return child;
            }
            else if (this.Component.GetType() == toBeRemovedComponent)
            {
                this.Component = this.Component.Component;
                return this;
            }
            else
            {
                this.Component.RemoveDecorator(toBeRemovedComponent);
                return this;
            }
        }
    }
}

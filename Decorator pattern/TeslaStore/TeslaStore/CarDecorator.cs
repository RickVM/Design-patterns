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

        public CarDecorator Component { get; set; } // Public getter to enable dynamic removal at runtime

        // Protected members ensure that only the derived class can access these variables. 
        // If we set them during construction we can use them in our default format.
        protected string descriptor;
        protected double cost;

        private void setCost(double cost)
        {
            this.cost = cost;
        }

        public string Description
        {
            get
            {
                // Since base cars are CarDecators without components we need to check.
                string baseComponentDescriptor = (Component != null ? Component.Description : "");
                return $"{baseComponentDescriptor}, {descriptor}";
            }
        }

        public double Price
        {
            get
            {
                // Since base cars are CarDecators without components we need to check.
                double baseComponentPrice = (Component != null ? Component.Price : 0);
                return baseComponentPrice + cost;
            }
        }

        // Returning a CarDecorator is required to support removal of the master decorator by returning the child.
        public CarDecorator RemoveUpgrade(Type toBeRemovedComponent)
        {
            if (Component == null)
            {
                //Do Nothing, no wrapped classes available
                return this;
            }
            else if (this.GetType() == toBeRemovedComponent)  // Master decorator needs to be removed
            {
                return Component; // Return child;
            }
            else if (this.Component.GetType() == toBeRemovedComponent)
            {
                this.Component = this.Component.Component;
                return this;
            }
            else
            {
                Component.RemoveUpgrade(toBeRemovedComponent);
                return this;
            }
        }
    }
}

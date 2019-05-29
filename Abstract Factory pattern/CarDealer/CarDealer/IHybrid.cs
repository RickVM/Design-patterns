using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerApp
{
    interface IHybrid : ICar
    {
        string DriveOnGas();
        string DriveOnElectricity();
    }

    class VolkswagenHybrid : VolkswagenCharacteristics, IHybrid
    {
        string fuel = "Electricity";

        public string Drive()
        {
            return $"Driving smooth and silently on {fuel}. Enjoying a {this.Characteristics} Hybrid.";
        }

        public string DriveOnGas()
        {
            fuel = "gas";
            return $"You are now driving on {fuel}.";
        }
        public string DriveOnElectricity()
        {
            fuel = "electricity";
            return $"You are now driving on {fuel}";
        }
    }

    class PorscheHybrid : PorscheCharacteristics, IHybrid
    {
        string fuel = "Electricity";

        public string Drive()
        {
            return $"Driving smooth and silently on {fuel}. Enjoying a {this.Characteristics} Hybrid.";
        }

        public string DriveOnGas()
        {
            fuel = "gas";
            return $"You are now driving on {fuel}.";
        }
        public string DriveOnElectricity()
        {
            fuel = "electricity";
            return $"You are now driving on {fuel}";
        }
    }
}

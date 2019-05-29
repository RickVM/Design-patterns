using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerApp
{
    interface ISuv : ICar
    {
        string DriveOffRoad();
    }

    class VolkswagenSuv : VolkswagenCharacteristics, ISuv
    {
        public string Drive()
        {
            return $"Driving on the road enjoying a {this.Characteristics} SUV.";
        }

        public string DriveOffRoad()
        {
            return $"Driving offroad enjoying a {this.Characteristics} SUV.";
        }
    }

    class PorscheSuv : PorscheCharacteristics, ISuv
    {
        public string Drive()
        {
            return $"Driving on the road enjoying a {this.Characteristics} SUV.";
        }

        public string DriveOffRoad()
        {
            return $"Driving offroad enjoying a {this.Characteristics} SUV.";
        }
    }

}

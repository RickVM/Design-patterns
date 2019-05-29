using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerApp
{

    interface ILimousine : ICar
    {
        string HaveChampagne();

    }

    class VolkswagenLimousine : VolkswagenCharacteristics, ILimousine
    {
        public string Drive()
        {
            return $"Being driven around with loads of room and confort. Enjoying a {this.Characteristics} Limousine.";
        }

        public string HaveChampagne()
        {
            return $"Having champagne in a {this.Characteristics} Limousine.";
        }
    }

    class PorscheLimousine : PorscheCharacteristics, ILimousine
    {
        public string Drive()
        {
            return $"Being driven around with loads of room and confort. Enojying a {this.Characteristics} Limousine.";
        }

        public string HaveChampagne()
        {
            return $"Having champagne in a {this.Characteristics} Limousine.";
        }
    }
}

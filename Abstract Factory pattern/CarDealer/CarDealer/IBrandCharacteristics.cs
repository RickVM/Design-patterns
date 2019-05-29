using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerApp
{
    interface IBrandCharacteristics
    {
        string Characteristics { get; set; }
    }

    abstract class PorscheCharacteristics : IBrandCharacteristics
    {
        public string Characteristics
        {
            get
            {
                return "Fast, Furious & Expensive";
            }
            set { }
        }
    }

    abstract class VolkswagenCharacteristics : IBrandCharacteristics
    {
        public string Characteristics
        {
            get
            {
                return "Standard, Decent & medium-prized";
            }
            set { }
        }
    }

}

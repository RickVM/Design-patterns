using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerApp
{

    interface ICarFactory
    {
        ISuv CreateSuv();
        IHybrid CreateHybrid();
        ILimousine CreateLimousine();
    }

    class PorscheFactory : ICarFactory
    {
        public ISuv CreateSuv()
        {
            return new PorscheSuv();
        }

        public ILimousine CreateLimousine()
        {
            return new PorscheLimousine();
        }

        public IHybrid CreateHybrid()
        {
            return new PorscheHybrid();
        }
    }

    class VolkswagenFactory : ICarFactory
    {
        public ISuv CreateSuv()
        {
            return new VolkswagenSuv();
        }

        public ILimousine CreateLimousine()
        {
            return new VolkswagenLimousine();
        }

        public IHybrid CreateHybrid()
        {
            return new VolkswagenHybrid();
        }
    }
}

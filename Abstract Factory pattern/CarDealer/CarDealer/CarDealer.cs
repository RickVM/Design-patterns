using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerApp
{
    class CarDealer
    {
        private ICarFactory carFactory;

        public CarDealer(ICarFactory carFactory)
        {
            this.carFactory = carFactory;
        }

        public ISuv BuySuv()
        {
            return carFactory.CreateSuv();
        }

        public ILimousine BuyLimousine()
        {
            return carFactory.CreateLimousine();
        }

        public IHybrid BuyHybrid()
        {
            return carFactory.CreateHybrid();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    interface IObservable
    {
        void RegisterSubscriber(IObserver observer);
        void DeleteSubscriber(IObserver observer);
        void NotifySubscribers();
        LocalWeather pullWeather(); // Pull mechanism
    }
}

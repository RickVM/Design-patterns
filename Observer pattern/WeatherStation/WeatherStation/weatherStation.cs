using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace App
{
    public class WeatherStation : IObservable
    {

        private List<IObserver> observers;
        private static HttpClient client;
        private static string baseUrl = "http://api.openweathermap.org/data/2.5/weather";
        private static string apiKey = "684fea935c1754da80748341e4f700bd";
        public string City { get; }
        public WeatherStation(string City)
        {
            observers = new List<IObserver>();
            this.City = City;
            client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public void RegisterSubscriber(IObserver observer)
        {
            observers.Add(observer);
        }
        public void DeleteSubscriber(IObserver observer)
        {
            observers.Remove(observer);
        }
        public async void NotifySubscribers()
        {
            LocalWeather weather = await GetWeather();
            if(weather == null)
            {
                Console.WriteLine("Failed to get weather data.");
                return;
            }
            foreach(IObserver observer in observers)
            {
                observer.Update(weather);
            }
        }

        public async Task<LocalWeather> GetWeather()
        {
            LocalWeather weather = null;
            HttpResponseMessage res = await client.GetAsync($"?q={this.City}&units=metric&APPID={apiKey}");
            if (res.IsSuccessStatusCode)
            {
                weather = await res.Content.ReadAsAsync<LocalWeather>();
            }
            return weather;
        }
    }
}

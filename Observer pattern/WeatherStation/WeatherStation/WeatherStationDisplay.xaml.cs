using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace App
{
    /// <summary>
    /// Interaction logic for WeatherStationDisplay.xaml
    /// </summary>
    public partial class WeatherStationDisplay : Window, IObservable
    {
        private List<IObserver> observers;
        private static HttpClient client;
        private static string baseUrl = "http://api.openweathermap.org/data/2.5/weather";
        private static string apiKey = "684fea935c1754da80748341e4f700bd";
        private LocalWeather weather; // Save weather to save api calls because of limited usage. Also since api updates only every 10 mins
        DispatcherTimer timer;

        public string City { get; }


        public WeatherStationDisplay(string City)
        {
            InitializeComponent();
            labelStation.Content = $"Station: {City}";

            observers = new List<IObserver>();
            this.City = City;
            client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            }; 

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(UpdateWeatherStation);
            timer.Interval = new TimeSpan(0, 10, 0); // Used api refreshes only every 10 mins.
            timer.Start();

            UpdateWeatherStation(this, null);
        }


        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
            UpdateObserverLabel();
        }
        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
            UpdateObserverLabel();
        }

        public async void NotifySubscribers()
        {
            LocalWeather weather = await GetWeather();
            if (weather == null)
            {
                Console.WriteLine("Failed to get weather data.");
                return;
            }
            foreach (IObserver observer in observers)
            {
                observer.Update(weather);
            }
        }

        public LocalWeather PullWeather()
        {
            return weather;
        }

        private async Task<LocalWeather> GetWeather()
        {
            LocalWeather weather = null;
            HttpResponseMessage res = await client.GetAsync($"?q={this.City}&units=metric&APPID={apiKey}");
            if (res.IsSuccessStatusCode)
            {
                weather = await res.Content.ReadAsAsync<LocalWeather>();
            }
            return weather;
        }

        private async void UpdateWeatherStation(object sender, EventArgs e)
        {
            LocalWeather w = await GetWeather();
            if (w == null)
            {
                return;
            }
            weather = w;
            NotifySubscribers();
        }

        private void button_Click_GetWeather(object sender, RoutedEventArgs e)
        {
            NotifySubscribers();
        }

        private void button_Click_StartDisplay(object sender, RoutedEventArgs e)
        {
            WeatherDisplay display = new WeatherDisplay(this);
            display.Show();
            UpdateObserverLabel();
        }

        private void UpdateObserverLabel()
        {
            labelSubscribers.Content = $"Subscribers: {observers.Count().ToString()}";
        }
    }
}

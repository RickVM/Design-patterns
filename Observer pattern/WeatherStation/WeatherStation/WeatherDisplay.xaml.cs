using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace App
{
    /// <summary>
    /// Interaction logic for WeatherDisplay.xaml
    /// </summary>
    public partial class WeatherDisplay : Window, IObserver
    {
        private IObservable weatherStation;

        public WeatherDisplay(IObservable weatherStation)
        {
            InitializeComponent();
            this.weatherStation = weatherStation;
            weatherStation.Subscribe(this);
            this.Closing += new CancelEventHandler(WeatherDisplay_Closing);
            Update(weatherStation.PullWeather()); // Pull latest update
        }

        void WeatherDisplay_Closing(object sender, CancelEventArgs e)
        {
            weatherStation.Unsubscribe(this);
        }



        public void Update(LocalWeather weather)
        {
            if(weather == null)
            {
                return;
            }
            labelLastUpdate.Content = $"Last updated: {DateTime.Now.ToString()}";
            labelCity.Content = $"city:  {weather.Name}";
            labelTemperature.Content = $"Tempature: {weather.Main.Temp}";
            labelVisibility.Content = $"visibility: {weather.Visibility}";
            labelWind.Content = $"Wind speed: {weather.Wind.Speed}";
            string weatherDescription = "Weather: ";
            foreach(Weather w in weather.Weather)
            {
                weatherDescription += $" {w.Description}";
            }
            labelDescription.Content = weatherDescription;
        }

        private void ButtonRefreshData_Click(object sender, RoutedEventArgs e)
        {
            LocalWeather w = weatherStation.PullWeather();
            if(w == null)
            {
                return;
            }
            Update(w);
        }

        
    }
}

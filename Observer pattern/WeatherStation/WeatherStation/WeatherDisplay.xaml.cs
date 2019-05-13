using System;
using System.Collections.Generic;
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
        private WeatherStation weatherStation;
        public WeatherDisplay(WeatherStation weatherStation)
        {
            InitializeComponent();
            this.weatherStation = weatherStation;
            weatherStation.RegisterSubscriber(this);
            Update(weatherStation.pullWeather()); // Pull latest update
            //this.weatherStation = weatherStation;
            //this.weatherStation = weatherStation;
        }

        public void Update(LocalWeather weather)
        {
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

    }
}

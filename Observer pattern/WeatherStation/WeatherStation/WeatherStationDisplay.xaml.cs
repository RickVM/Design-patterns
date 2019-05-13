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
using System.Windows.Threading;

namespace App
{
    /// <summary>
    /// Interaction logic for WeatherStationDisplay.xaml
    /// </summary>
    public partial class WeatherStationDisplay : Window
    {
        private WeatherStation weatherStation;
        public WeatherStationDisplay(string weatherStation)
        {
            InitializeComponent();
            this.weatherStation = new WeatherStation(weatherStation);
        }

        private void button_Click_GetWeather(object sender, RoutedEventArgs e)
        {
            weatherStation.NotifySubscribers();
        }

        private void button_Click_StartDisplay(object sender, RoutedEventArgs e)
        {
            WeatherDisplay display = new WeatherDisplay(weatherStation);
            display.Show();
        }
    }
}

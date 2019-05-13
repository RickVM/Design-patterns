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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WeatherStation weatherStation;
        public MainWindow()
        {
            InitializeComponent();
            weatherStation = new WeatherStation("Eindhoven");
        }

        private void button_Click_GetWeather(object sender, RoutedEventArgs e)
        {
            weatherStation.NotifySubscribers();
        }

        private void button_Click_ShowWeather(object sender, RoutedEventArgs e)
        {
            WeatherDisplay display = new WeatherDisplay(weatherStation);
            display.Show();
        }
    }
}

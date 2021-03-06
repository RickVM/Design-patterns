﻿using System;
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
    public partial class StationManager : Window
    {
        public StationManager()
        {
            InitializeComponent();
        }

        private void button_Click_StartWeatherStation(object sender, RoutedEventArgs e)
        {
            string city = textBoxCity.Text;
            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("City cannot be null or empty!");
            }
            WeatherStationDisplay wsd = new WeatherStationDisplay(city);
            wsd.Show();
        }
    }
}

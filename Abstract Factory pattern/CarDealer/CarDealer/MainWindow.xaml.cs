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

namespace CarDealerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CarDealer carDealer;
        ICar car;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void disableCarFeatures()
        {
            buttonDriveOffroad.Visibility = Visibility.Hidden;
            button_HaveChampagne.Visibility = Visibility.Hidden;
            buttonElectric.Visibility = Visibility.Hidden;
            buttonGas.Visibility = Visibility.Hidden;
        }

        private void log(string text)
        {
            Log.Items.Insert(0, $"{DateTime.Now.ToLongTimeString()}: {text}");
        }

        private void RadioButtonVolkswagen_Checked(object sender, RoutedEventArgs e)
        {
            ICarFactory carFactory = new VolkswagenFactory();
            carDealer = new CarDealer(carFactory);
        }

        private void RadioButtonPorsche_Checked(object sender, RoutedEventArgs e)
        {
            ICarFactory carFactory = new PorscheFactory();
            carDealer = new CarDealer(carFactory);
        }

        private void ButtonSuv_Click(object sender, RoutedEventArgs e)
        {
            if (carDealer == null)
            {
                MessageBox.Show("You need a dealer to buy a car. :)");
                return;
            }
            car = carDealer.BuySuv();
            labelActiveCar.Content = "Drive a SUV";
            disableCarFeatures();
            buttonDriveOffroad.Visibility = Visibility.Visible;
            log("You bought a Suv");
        }

        private void ButtonLimousine_Click(object sender, RoutedEventArgs e)
        {
            if (carDealer == null)
            {
                MessageBox.Show("You need a dealer to buy a car. :)");
                return;
            }
            car = carDealer.BuyLimousine();
            labelActiveCar.Content = "Drive a Limousine";
            disableCarFeatures();
            button_HaveChampagne.Visibility = Visibility.Visible;
            log("You bought a Limousine");

        }

        private void ButtonHybrid_Click(object sender, RoutedEventArgs e)
        {
            if (carDealer == null)
            {
                MessageBox.Show("You need a dealer to buy a car. :)");
                return;
            }
            car = carDealer.BuyHybrid();
            labelActiveCar.Content = "Drive a Hybrid";
            disableCarFeatures();
            buttonElectric.Visibility = Visibility.Visible;
            buttonGas.Visibility = Visibility.Visible;
            log("You bought a Hybrid");
        }

        private void ButtonDrive_Click(object sender, RoutedEventArgs e)
        {
            if (car == null) 
            {
                MessageBox.Show("How are you planning on driving without a car?");
                return;
            }
            log(car.Drive());
        }

        private void ButtonDriveOffroad_Click(object sender, RoutedEventArgs e)
        {
            if (car is ISuv suv)
            {
                log(suv.DriveOffRoad());
            }
        }

        private void Button_HaveChampagne_Click(object sender, RoutedEventArgs e)
        {
            if (car is ILimousine limousine)
            {
                log(limousine.HaveChampagne());
            }
        }

        private void ButtonElectric_Click(object sender, RoutedEventArgs e)
        {
            if (car is IHybrid hybrid)
            {
                log(hybrid.DriveOnElectricity());
            }
        }

        private void ButtonGas_Click(object sender, RoutedEventArgs e)
        {
            if (car is IHybrid hybrid)
            {
                log(hybrid.DriveOnGas());
            }
        }
    }
}

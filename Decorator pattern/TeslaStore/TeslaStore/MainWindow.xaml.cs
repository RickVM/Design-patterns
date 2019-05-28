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

namespace TeslaStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CarDecorator car;

        public MainWindow()
        {
            InitializeComponent();
            car = new ModelS(); // Default choice for customer.
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            updateDisplay();
        }

        void updateDisplay()
        {
            if (!this.IsLoaded)
            {
                return;
            }
            featureLabel.Content = $"Features: {car.Description}";
            priceLabel.Content = $"Price: € {car.Price}";
        }

        void uncheckFeatures()
        {
            if (!this.IsLoaded)
            {
                return;
            }
            checkBoxLongRange.IsChecked = false;
            checkBoxPerformance.IsChecked = false;
            checkBoxFullAutopilot.IsChecked = false;
            checkBoxTowbar.IsChecked = false;
        }

        private void RadioButtonModelS_Checked(object sender, RoutedEventArgs e)
        {
            car = new ModelS();
            uncheckFeatures();
            updateDisplay();
        }

        private void RadioButtonModel3_Checked(object sender, RoutedEventArgs e)
        {
            car = new Model3();
            uncheckFeatures();
            updateDisplay();
        }

        private void RadioButtonModelX_Checked(object sender, RoutedEventArgs e)
        {
            car = new ModelX();
            uncheckFeatures();
            updateDisplay();
        }

        private void RadioButtonModelY_Checked(object sender, RoutedEventArgs e)
        {
            car = new ModelY();
            uncheckFeatures();
            updateDisplay();
        }

        private void CheckBoxLongRange_Checked(object sender, RoutedEventArgs e)
        {
            car = new LongRange(car);
            updateDisplay();
        }

        private void CheckBoxPerformance_Checked(object sender, RoutedEventArgs e)
        {
            car = new Performance(car);
            updateDisplay();
        }

        private void CheckBoxTowbar_Checked(object sender, RoutedEventArgs e)
        {
            car = new Towbar(car);
            updateDisplay();
        }

        private void CheckBoxFullAutopilot_Checked(object sender, RoutedEventArgs e)
        {
            car = new FullAutoPilot(car);
            updateDisplay();
        }

        private void CheckBoxLongRange_Unchecked(object sender, RoutedEventArgs e)
        {
            car = car.RemoveDecorator(typeof(LongRange));
            updateDisplay();
        }

        private void CheckBoxPerformance_Unchecked(object sender, RoutedEventArgs e)
        {
            car = car.RemoveDecorator(typeof(Performance));
            updateDisplay();
        }

        private void CheckBoxFullAutopilot_Unchecked(object sender, RoutedEventArgs e)
        {
            car = car.RemoveDecorator(typeof(FullAutoPilot));
            updateDisplay();
        }

        private void CheckBoxTowbar_Unchecked(object sender, RoutedEventArgs e)
        {
            car = car.RemoveDecorator(typeof(Towbar));
            updateDisplay();
        }
    }
}

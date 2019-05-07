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
using System.Windows.Threading;

namespace strategypattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Request> requests;
        List<int> queue;
        Random randomGenerator;
        int head;
        DispatcherTimer timer;
        int driveSize = 1024000; // Also edit slider range in window
        int headSpeed = 1000;

        IQueueHandler queueHandler;

        public MainWindow()
        {
            InitializeComponent();
            requests = new List<Request>();
            queue = new List<int>();
            randomGenerator = new Random();
            head = 0;

            queueHandler = new FirstComeFirstServe();
            updateHeadDisplay();

            // Start UI timer
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(handleTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 4);
            timer.Start();
        }

        public void handleTick(object sender, EventArgs e)
        {
            if(queue.Count > 0)
            {
                // Move towards requested sector
                int nextSector = queue[0];
                // Account for over / underscan.
                if(valsAreWithin(head, nextSector, headSpeed))
                {
                    head = nextSector;
                    requests.RemoveAll(request => request.sector == head);
                    UpdateRequestedSectorsTextBox();
                    updateQueue();
                } else
                {
                    if (nextSector > head)
                    {

                        head += headSpeed;
                     
                    }
                    else
                    {
                        head -= headSpeed;
                    }
                }
            }
            updateHeadDisplay();
        }

        /// <summary>
        /// Returns whether the distance between x and y is within distance
        /// </summary>
        /// <param name="head"></param>
        /// <param name="sector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        private bool valsAreWithin(int x, int y, int distance)
        {
            int valDistance = x - y;
            if(valDistance > (0 - distance) && valDistance < distance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void FirstComeFirstServeBtn_Checked(object sender, RoutedEventArgs e)
        {
            updateQueueHandler(new FirstComeFirstServe());
            Console.WriteLine("FCFS strategy enabled.");
        }

        private void ShortestSeekTimeButton_Checked(object sender, RoutedEventArgs e)
        {
            updateQueueHandler(new ShortestSeekTime());
            Console.WriteLine("SST strategy enabled.");
        }

        private void ScanButton_Checked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("SCAN strategy enabled.");
        }

        private void updateQueueHandler(IQueueHandler handler)
        {
            queueHandler = handler;
            updateQueue();
        }
        private void RandomRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Random request generated");
            requestTextBox.Text = randomGenerator.Next(0, driveSize).ToString();
        }

        private void SubmitRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Request submitted");
            string requestText = requestTextBox.GetLineText(0);
            try
            {
                Request request = new Request(parseSector(requestText));
                requests.Add(request);
                UpdateRequestedSectorsTextBox();
                updateQueue();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }

        private int parseSector(string sector)
        {
            int s = int.Parse(sector);
            if(s > driveSize)
            {
                throw new ArgumentOutOfRangeException($"Sector size should be between 0 and {driveSize}");
            }
            return  s;
        }

        private void updateQueue()
        {
            if(requests == null)
            {
                return;
            }
            // Calculate queue based upon strategy
            queue = queueHandler.CalculateOptimalQueue(requests.ToList(), head);
            updateQueueBox();
        }

        private void updateQueueBox()
        {
            if (queue == null)
            {
                return;
            }
    
            string displayText = "";
            foreach (int sector in queue)
            {
                displayText = String.Concat(displayText, $"{sector.ToString()},");
            }
            queueTextBox.Text = displayText;
        }

        private void UpdateRequestedSectorsTextBox()
        {
            if (requests == null)
            {
                return;
            }
                  
            string displayText = "";
            foreach(Request request in requests)
            {
                displayText = String.Concat(displayText, request.ToString());
            }
            RequestedSectorsTextBox.Text = displayText;
        }

        private void updateHeadDisplay()
        {
            headLabel.Content = head.ToString();
            headSlider.Value = head;
        }
    }
}

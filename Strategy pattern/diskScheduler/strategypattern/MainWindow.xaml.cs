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

namespace diskScheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int head;
        bool running;
        List<Request> requests;
        List<int> queue;
        Random randomGenerator;

        DispatcherTimer timer;
        static int driveSize; // Also edit slider range in window
        int headSpeed = 1000;

        IQueueHandler queueHandler;

        public MainWindow()
        {
            InitializeComponent();
            requests = new List<Request>();
            queue = new List<int>();
            randomGenerator = new Random();
            driveSize = int.Parse(FindResource("driveSize").ToString());
            head = 0;

            queueHandler = new FirstComeFirstServe();
            UpdateHeadDisplay();
            running = true;

            // Start UI timer
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(HandleTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 4);
            timer.Start();
        }

        public void HandleTick(object sender, EventArgs e)
        {
            if (running)
            {
                if (queue.Count > 0)
                {
                    // Move towards requested sector
                    int nextSector = queue[0];
                    // Account for over / underscan.
                    if (ValsAreWithin(head, nextSector, headSpeed))
                    {
                        head = nextSector;
                        requests.RemoveAll(request => request.sector == head);
                        UpdateRequestedSectorsTextBox();
                        UpdateQueue();
                    }
                    else
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
                UpdateHeadDisplay();
            }
        }

        /// <summary>
        /// Returns whether the distance between x and y is within distance
        /// </summary>
        /// <param name="head"></param>
        /// <param name="sector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        private bool ValsAreWithin(int x, int y, int distance)
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
            UpdateQueuHandler(new FirstComeFirstServe());
            Console.WriteLine("FCFS strategy enabled.");
        }

        private void ShortestSeekTimeButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateQueuHandler(new ShortestSeekTime());
            Console.WriteLine("SST strategy enabled.");
        }

        private void ScanButton_Checked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("SCAN strategy enabled.");
            UpdateQueuHandler(new Scan());
        }

        private void UpdateQueuHandler(IQueueHandler handler)
        {
            queueHandler = handler;
            UpdateQueue();
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
                Request request = new Request(ParseSector(requestText));
                requests.Add(request);
                UpdateRequestedSectorsTextBox();
                UpdateQueue();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }

        private int ParseSector(string sector)
        {
            int s = int.Parse(sector);
            if(s > driveSize)
            {
                throw new ArgumentOutOfRangeException($"Sector size should be between 0 and {driveSize}");
            }
            return  s;
        }

        private void UpdateQueue()
        {
            if(requests == null)
            {
                return;
            }
            // Calculate queue based upon strategy
            queue = queueHandler.CalculateOptimalQueue(requests.ToList(), head);
            UpdateQueueBox();
        }

        private void UpdateQueueBox()
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

        private void UpdateHeadDisplay()
        {
            headLabel.Content = head.ToString();
            headSlider.Value = head;
        }

        private void RandomIOBtn_Click(object sender, RoutedEventArgs e)
        {
            // Add random IO
            for(int i= 0; i < 10; i++)
            {
                requests.Add(new Request(randomGenerator.Next(0, driveSize)));
            }
            UpdateRequestedSectorsTextBox();
            UpdateQueue();
        }

        private void ConsecutiveIO_Click(object sender, RoutedEventArgs e)
        {
            // Add consecutive io
            int[] arr = { 10000, 50000, 74310, 29087, 450425, 515023, 1101240 };
            foreach(int i in arr )
            {
                requests.Add(new Request(i));
            }
            UpdateRequestedSectorsTextBox();
            UpdateQueue();
        }

        private void startStopBtn_Click(object sender, RoutedEventArgs e)
        {
            running = !running;
        }
    }
}

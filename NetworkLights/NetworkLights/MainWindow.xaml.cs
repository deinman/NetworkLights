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
using System.Net;
using System.Net.NetworkInformation;

namespace NetworkLights
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        public Ping sendPing = new Ping();

        public PingOptions sendOptions = new PingOptions(128,true);
                                                        //Ttl,DontFragment
        public static string sendData = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        public byte[] sendBuffer = Encoding.ASCII.GetBytes(sendData);
        public int sendTimeout = 120;
        
        private void NetworkBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DNSTestBtn_Click(object sender, RoutedEventArgs e)
        {
            string dnsIPAddress = DNSTextbox.Text;

            try
            {
                PingReply reply = sendPing.Send(dnsIPAddress, sendTimeout, sendBuffer, sendOptions);

                if (reply.Status == IPStatus.Success)
                {
                    DNSStatus.Fill = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    DNSStatus.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            catch (PingException)
            {
                //
                throw;
            }
        }

        private void RouterTestBtn_Click(object sender, RoutedEventArgs e)
        {
            string routerIPAddress = RouterIPTextbox.Text;

            try
            {
                PingReply reply = sendPing.Send(routerIPAddress, sendTimeout, sendBuffer, sendOptions);

                if (reply.Status == IPStatus.Success)
                {
                    RouterStatus.Fill = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    RouterStatus.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            catch (PingException)
            {
                //
                throw;
            }
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            LocalIpStatus.Fill = new SolidColorBrush(Colors.Gray);
            WapStatus.Fill = new SolidColorBrush(Colors.Gray);
            RouterStatus.Fill = new SolidColorBrush(Colors.Gray);
            DNSStatus.Fill = new SolidColorBrush(Colors.Gray);
            InternetStatus.Fill = new SolidColorBrush(Colors.Gray);
        }

        private void WAPTestBtn_Click(object sender, RoutedEventArgs e)
        {
            string wapIPAddress = RouterIPTextbox.Text;

            try
            {
                PingReply reply = sendPing.Send(wapIPAddress, sendTimeout, sendBuffer, sendOptions);

                if (reply.Status == IPStatus.Success)
                {
                    WapStatus.Fill = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    WapStatus.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            catch (PingException)
            {
                //
                throw;
            }
        }

        private void InternetTestBtn_Click(object sender, RoutedEventArgs e)
        {
            string internetIPAddress = RouterIPTextbox.Text;

            try
            {
                PingReply reply = sendPing.Send(internetIPAddress, sendTimeout, sendBuffer, sendOptions);

                if (reply.Status == IPStatus.Success)
                {
                    InternetStatus.Fill = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    InternetStatus.Fill = new SolidColorBrush(Colors.Red);
                }
            }
            catch (PingException)
            {
                //
                throw;
            }
        }
    }
} 
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DNSTestBtn_Click(object sender, RoutedEventArgs e)
        {
            string dnsIPAddress = DNSTextbox.Text;

            Ping dnsPing = new Ping();
            PingOptions dnsOptions = new PingOptions();

            dnsOptions.DontFragment = true;

            string dnsData = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] dnsBuffer = Encoding.ASCII.GetBytes(dnsData);
            int dnsTimeout = 120;

            try
            {
                PingReply reply = dnsPing.Send(dnsIPAddress, dnsTimeout, dnsBuffer, dnsOptions);

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
    }
}
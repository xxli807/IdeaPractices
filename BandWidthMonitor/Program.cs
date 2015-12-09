using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BandWidthMonitor
{
    class Program
    {
        private static NetworkDetail networkDetail = new NetworkDetail();
        

        static void Main(string[] args)
        {
           
            var timer = new Timer();

            timer.Elapsed += new ElapsedEventHandler(MonitorNetwork);
            timer.Interval = 5000;
            // And start it        
            timer.Enabled = true;

            Console.ReadKey();
        }


        public static void MonitorNetwork(object source, ElapsedEventArgs e)
        {
            IEnumerable<NetworkInterface> nics = NetworkInterface.GetAllNetworkInterfaces().Where(n => n.NetworkInterfaceType == NetworkInterfaceType.Wireless80211);
            networkDetail.NetWorkInterfaces = new List<NetworkInterface>();

            foreach (var nic in nics)
            { 
                networkDetail.NetWorkInterfaces.Add(nic);
            }

            foreach(var item in networkDetail.NetWorkInterfaces)
            {
                CalculatorBandwidth(item);
            }

        }

        //need to calculator to get the right detail up/down function
        public static void CalculatorBandwidth(NetworkInterface selecNic)
        {
            if (selecNic == null)
                return;

            var name = selecNic.Name;
            var networkInterfaceType = selecNic.NetworkInterfaceType.ToString();
            var operationStatus = selecNic.OperationalStatus.ToString();
            
            var interfaceData = selecNic.GetIPv4Statistics();

            var byteReceived = interfaceData.BytesReceived;
            var byteSend = interfaceData.BytesSent;
            Console.WriteLine("byteReceived: {0}, send: {1}", byteReceived, byteSend);

            System.Threading.Thread.Sleep(2000);

            interfaceData = selecNic.GetIPv4Statistics();

            var byteReceived1 = interfaceData.BytesReceived;
            var byteSend1 = interfaceData.BytesSent;
            Console.WriteLine("byteReceived1: {0}, send1: {1}", byteReceived1, byteSend1);


            long recievedBytes = byteReceived1 - byteReceived;
            var sendBytes = byteSend1 - byteSend;

            Console.WriteLine("send: {0} mb/s, receive: {1} mb/s", sendBytes.ToString(), recievedBytes.ToString());

           

        }

       
    }

    public class NetworkDetail
    {
        public string DisplayName { get; set; }
        public string ValueMember { get; set; }
        public List<NetworkInterface> NetWorkInterfaces { get; set; }
    }


}

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace BACnetNetduino
{
    public class Program
    {

        private static LocalDevice _device;

        public static void Main()
        {
            
            // write your code here
            LinkLayer ll = new LinkLayer();
            NetworkLayer network = new NetworkLayer(1, ll);
            ApplicationLayer app = new ApplicationLayer(network);

            _device = new LocalDevice(999,app,"Netduino","Netduino");

            ll.Start();
        }

        public static LocalDevice Device => _device;
    }
}

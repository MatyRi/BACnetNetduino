using System.Net;
using System.Threading;
using BACnetNetwork;
using BACnetServices;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace BACnetNetduino
{
    public class Program
    {

        private static LocalDevice _device;
        private static readonly OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);

        public static void Main()
        {
            // write your code here
            LinkLayer ll = new LinkLayer();
            NetworkLayer network = new NetworkLayer(1, ll);
            ApplicationLayer app = new ApplicationLayer(network);

            ll.NewMessageReceived += BlinkLed;

            _device = new LocalDevice(999,app,"Netduino","Netduino");

            ll.Start();
        }

        private static void BlinkLed(EndPoint from, byte[] data)
        {
            led.Write(true);
            Thread.Sleep(50);
            led.Write(false);
        }

        public static LocalDevice Device => _device;
    }
}

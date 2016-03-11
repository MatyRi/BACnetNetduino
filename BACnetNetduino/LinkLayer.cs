using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace BACnetNetduino
{
    internal class LinkLayer
    {

        public static readonly int DEFAULT_PORT = 47808; // 0xBAC0

        readonly Thread _receiverThread;
        private readonly int _port;
        private bool _timeToDie;
        private readonly OutputPort led;

        public delegate void MessageReceiverHandler(EndPoint from, byte[] data);

        public event MessageReceiverHandler NewMessageReceived;


        public LinkLayer()
            : this(DEFAULT_PORT)
        {
            
        }

        public LinkLayer(int port)
        {
            this._port = port;
            this._timeToDie = false;

            led = new OutputPort(Pins.ONBOARD_LED, false);

            _receiverThread = new Thread(Receive);

            NewMessageReceived += BlinkLed;

        }

        public void Start()
        {
            _receiverThread.Start();
        }

        private void Receive()
        {
            using (Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, _port);
                serverSocket.Bind(remoteEndPoint);

                //serverSocket.Listen(5);

                while (!_timeToDie)
                {
                    if (serverSocket.Poll(-1, SelectMode.SelectRead))
                    {
                        byte[] inBuffer = new byte[serverSocket.Available];
                        int count = serverSocket.ReceiveFrom(inBuffer, ref remoteEndPoint);

                        byte[] trimedBytes = new byte[count];
                        Array.Copy(inBuffer,0,trimedBytes,0,count);

                        NewMessageReceived?.Invoke(remoteEndPoint, trimedBytes);
                    }
                    else
                    {
                        Thread.Sleep(0);
                    }
                }


            }
        }

        private void BlinkLed(EndPoint from, byte[] data)
        {
            led.Write(true);
            Thread.Sleep(50);
            led.Write(false);
        }

        public void Stop()
        {
            this._timeToDie = true;
            this._receiverThread.Abort();
        }

    }
}

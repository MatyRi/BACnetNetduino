using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT.Net.NetworkInformation;

namespace BACnetNetwork
{
    public class LinkLayer
    {
        public static readonly int DEFAULT_PORT = 47808; // 0xBAC0

        readonly Thread _receiverThread;
        private readonly int _port;
        private bool _timeToDie;

        private Socket server;

        public delegate void MessageReceiverHandler(EndPoint from, byte[] data);

        public event MessageReceiverHandler NewMessageReceived;


        public LinkLayer()
            : this(DEFAULT_PORT)
        {
        }

        public LinkLayer(int port)
        {
            _port = port;
            _timeToDie = false;
            _receiverThread = new Thread(Receive);
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

                server = serverSocket;

                //serverSocket.Listen(5);

                while (!_timeToDie)
                {
                    if (serverSocket.Poll(-1, SelectMode.SelectRead))
                    {
                        byte[] inBuffer = new byte[serverSocket.Available];
                        int count = serverSocket.ReceiveFrom(inBuffer, ref remoteEndPoint);

                        byte[] trimedBytes = new byte[count];
                        Array.Copy(inBuffer, 0, trimedBytes, 0, count);

                        NewMessageReceived?.Invoke(remoteEndPoint, trimedBytes);
                    }
                    else
                    {
                        Thread.Sleep(0);
                    }
                }
            }
        }

        public void SendPacket(IPEndPoint endpoint, byte[] data)
        {
            if (server != null) server.SendTo(data, endpoint);
        }

        public void Stop()
        {
            _timeToDie = true;
            _receiverThread.Abort();
        }

        internal IPAddress[] GetLocalAddresses()
        {
            NetworkInterface[] Interfaces = NetworkInterface.GetAllNetworkInterfaces();
            IPAddress[] result = new IPAddress[Interfaces.Length];
            int i = 0;
            foreach (NetworkInterface Interface in Interfaces)
            {
                IPAddress toAdd = IPAddress.Parse(Interface.IPAddress);
                result[i] = toAdd;
            }
            return result;

        }

    }
}

using System;
using System.Net;
using Microsoft.SPOT;

namespace BACnetNetduino
{
    internal class ApplicationLayer
    {
        private readonly NetworkLayer network;

        public ApplicationLayer(NetworkLayer network)
        {
            this.network = network;
            this.network.NewNPDUReceived += OnNPDUReceived;
        }

        private void OnNPDUReceived(IPEndPoint from, NPDU.NPDU npdu, ByteStream raw)
        {
            try
            {

                APDU.APDU apdu = APDU.APDU.Parse(raw);

                // TODO return APDU.createAPDU(servicesSupported, queue);
            }
            catch (System.Exception e)
            {
                // If it's already a BACnetException, don't bother wrapping it.
                throw e;
            }

            /*if (inBuffer.Length > 20)
                {
                    string result = printRouterInfo(inBuffer);
                    Debug.Print("Sending> " + result);

                    using (
                        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
                            ProtocolType.Udp))
                    {
                        //EndPoint remoteEP = new IPEndPoint(IPAddress.Parse("192.168.0.14"), 55056);
                        byte[] messageBytes = Encoding.UTF8.GetBytes(result);
                        clientSocket.SendTo(messageBytes, remoteEndPoint);
                    }

                }
                else
                {
                    string message = new string(Encoding.UTF8.GetChars(inBuffer));
                    Debug.Print("Received> " + message);
                }*/
        }
    }
}

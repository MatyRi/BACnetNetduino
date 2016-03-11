using System;
using System.Net;
using BACnetNetduino.DataTypes;
using BACnetNetduino.DataTypes.Constructed;
using BACnetNetduino.DataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetNetduino
{
    internal class NetworkLayer
    {

        private readonly int localNetworkNumber;


        public NetworkLayer(int newtrokNumber, LinkLayer linkLayer)
        {
            localNetworkNumber = newtrokNumber;
            linkLayer.NewMessageReceived += OnReceived;
            //linkLayer.Start();
        }

        public delegate void NPDUReceiverHandler(IPEndPoint from, NPDU.NPDU data, ByteStream raw);

        public event NPDUReceiverHandler NewNPDUReceived;

        private void OnReceived(EndPoint aFrom, byte[] data)
        {
            IPEndPoint from = (IPEndPoint) aFrom;
            ByteStream bs = new ByteStream(data);

            BVLC bvlc = BVLC.Parse(bs);

            int packetLength = bvlc.Length;

            NPDU.NPDU npdu = NPDU.NPDU.Parse(bs);

            if (npdu.getVersion() != 1)
                throw new System.Exception("Invalid protocol version: " + npdu.getVersion());
            if (npdu.isNetworkMessage())
                return; // throw new MessageValidationAssertionException("Network messages are not supported");

            // Check the destination network number work and do not respond to foreign networks requests  
            if (npdu.hasDestinationInfo())
            {
                int destNet = npdu.getDestinationNetwork();
                if (destNet > 0 && destNet != 0xffff && localNetworkNumber > 0 && localNetworkNumber != destNet)
                {
                    return;
                }
            }

            Address fromAddress;

            if (npdu.hasSourceInfo())
                fromAddress = new Address((ushort) npdu.getSourceNetwork(), npdu.getSourceAddress());
            else
                fromAddress = new Address(new OctetString(from.Address.GetAddressBytes(), from.Port)); //macAddress
            
            // Create the APDU.

            NewNPDUReceived?.Invoke(@from, npdu, bs);
        }


    }
}

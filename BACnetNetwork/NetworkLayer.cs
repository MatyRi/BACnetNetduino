using System.Net;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;

namespace BACnetNetwork
{
    public class NetworkLayer
    {
        private readonly int localNetworkNumber;
        private readonly LinkLayer link;

        private Address _broadcastAddress;

        public int LocalNetworkNumber => localNetworkNumber;

        private Address[] addresses;

        public Address[] AllLocalAddresses
        {
            get
            {
                if (addresses == null)
                {
                    IPAddress[] networkAddresses = link.GetLocalAddresses();
                    addresses = new Address[networkAddresses.Length];
                    int i = 0;
                    foreach (IPAddress addr in networkAddresses)
                    {
                        Address adrs = new Address(addr.GetAddressBytes());
                        addresses[i] = adrs;
                    }
                }
                return addresses;
            }
        }

        public NetworkLayer(int newtrokNumber, LinkLayer linkLayer)
        {
            localNetworkNumber = newtrokNumber;
            link = linkLayer;
            linkLayer.NewMessageReceived += OnReceived;
            //linkLayer.Start();
        }

        public delegate void NPDUReceiverHandler(
            IPEndPoint from, Address fromAddress, OctetString linkService, NPDU.NPDU data, ByteStream raw);

        public event NPDUReceiverHandler NewNPDUReceived;

        private void OnReceived(EndPoint aFrom, byte[] data)
        {
            IPEndPoint from = (IPEndPoint) aFrom;
            ByteStream bs = new ByteStream(data);

            BVLC.BVLC bvlc = new BVLC.BVLC(bs);

            int packetLength = bvlc.Length;

            NPDU.NPDU npdu = new NPDU.NPDU(bs);

            if (npdu.Version != 1)
                throw new System.Exception("Invalid protocol version: " + npdu.Version);
            if (npdu.IsNetworkMessage)
                return; // throw new MessageValidationAssertionException("Network messages are not supported");

            // Check the destination network number work and do not respond to foreign networks requests  
            if (npdu.HasDestinationInfo)
            {
                int destNet = npdu.DestinationNetwork;
                if (destNet > 0 && destNet != 0xffff && localNetworkNumber > 0 && localNetworkNumber != destNet)
                {
                    return;
                }
            }

            Address fromAddress;

            if (npdu.HasSourceInfo)
                fromAddress = new Address((ushort) npdu.SourceNetwork, npdu.SourceAddress);
            else
                fromAddress = new Address(new OctetString(from.Address.GetAddressBytes(), from.Port)); //macAddress

            // Create the APDU.

            NewNPDUReceived?.Invoke(@from, fromAddress, fromAddress.MACAddress, npdu, bs);
        }

        public void sendAPDU(Address recipient, OctetString link, IAPDU apdu, bool broadcast)
        {
            ByteStream queue = new ByteStream();

            // BACnet virtual link layer detail

            // BACnet/IP
            queue.WriteByte(0x81);

            // Original-Unicast-NPDU, or Original-Broadcast-NPDU
            queue.WriteByte((byte) (broadcast ? 0xb : 0xa));

            // NPCI
            ByteStream apduStream = new ByteStream();
            writeNpci(apduStream, recipient, link, apdu);

            // APDU
            apdu.write(apduStream);

            // Length
            queue.WriteShort((ushort) (queue.Position + apduStream.Length + 2));

            // Combine the queues
            queue.Write(apduStream);

            IPEndPoint isa;
            if (recipient.IsGlobal)
                isa = LocalBroadcastAddress.MACAddress.InetSocketAddress;
            else if (link != null)
                isa = link.InetSocketAddress;
            else
                isa = recipient.MACAddress.InetSocketAddress;

            this.link.SendPacket(isa, queue.ReadToEnd());
        }

        public Address LocalBroadcastAddress
        {
            get {
                return _broadcastAddress ??
                       (_broadcastAddress = new Address(BACnetUtils.dottedStringToBytes("192.168.0.255"), 47808));
            }
            set { _broadcastAddress = value; }
        }

        protected void writeNpci(ByteStream queue, Address recipient, OctetString link, IAPDU apdu)
        {
            NPDU.NPDU npci;
            if (recipient.IsGlobal)
                npci = new NPDU.NPDU((Address) null);
            else if (isLocal(recipient))
            {
                if (link != null)
                    throw new System.Exception("Invalid arguments: link service address provided for a local recipient");
                npci = new NPDU.NPDU(null, null, apdu.expectsReply());
            }
            else
            {
                if (link == null)
                    throw new System.Exception(
                        "Invalid arguments: link service address not provided for a remote recipient");
                npci = new NPDU.NPDU(recipient, null, apdu.expectsReply());
            }
            npci.write(queue);
        }

        protected bool isLocal(Address recipient)
        {
            uint nn = recipient.NetworkNumber.Value;
            return nn == Address.LOCAL_NETWORK || nn == localNetworkNumber;
        }
    }
}

using System;
using System.Net;
using System.Text;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class Address : BaseType
    {
        public static readonly ushort LOCAL_NETWORK = 0;
        public static readonly Address GLOBAL = new Address(new Unsigned16(0xFFFF), null);

        private readonly Unsigned16 networkNumber;

        public Address(ushort networkNumber, byte[] macAddress)
            : this(new Unsigned16(networkNumber), new OctetString(macAddress))
        {
        }

        public Address(ushort networkNumber, string dottedString)
            : this(new Unsigned16(networkNumber), new OctetString(dottedString))
        {
        }

        public Address(OctetString macAddress) : this(LOCAL_NETWORK, macAddress)
        {
        }

        public Address(ushort networkNumber, OctetString macAddress) : this(new Unsigned16(networkNumber), macAddress)
        {
        }

        public Address(Unsigned16 networkNumber, OctetString macAddress)
        {
            this.networkNumber = networkNumber;
            this.MacAddress = macAddress;
        }

        /**
         * Convenience constructor for MS/TP addresses local to this network.
         * 
         * @param station
         *            the station id
         */

        public Address(byte station) : this(LOCAL_NETWORK, station)
        {
        }

        /**
         * Convenience constructor for MS/TP addresses remote to this network.
         * 
         * @param network
         * @param station
         */

        public Address(ushort networkNumber, byte station)
        {
            this.networkNumber = new Unsigned16(networkNumber);
            MacAddress = new OctetString(new[] {station});
        }

        /**
         * Convenience constructor for IP addresses local to this network.
         * 
         * @param ipAddress
         * @param port
         */

        public Address(byte[] ipAddress, int port) : this(LOCAL_NETWORK, ipAddress, port)
        {
        }

        /**
         * Convenience constructor for IP addresses remote to this network.
         * 
         * @param network
         * @param ipAddress
         * @param port
         */

        public Address(ushort networkNumber, byte[] ipAddress, int port)
        {
            this.networkNumber = new Unsigned16(networkNumber);

            byte[] ipMacAddress = new byte[ipAddress.Length + 2];
            Array.Copy(ipAddress, 0, ipMacAddress, 0, ipAddress.Length);
            ipMacAddress[ipAddress.Length] = (byte) (port >> 8);
            ipMacAddress[ipAddress.Length + 1] = (byte) port;
            MacAddress = new OctetString(ipMacAddress);
        }

        public Address(string host, int port) : this(LOCAL_NETWORK, host, port)
        {
        }

        public Address(ushort networkNumber, string host, int port) : this(networkNumber, InetAddrCache.get(host, port))
        {
            // TODO Not Implemented asi
        }

        public Address(IPAddress addr, int port) : this(LOCAL_NETWORK, addr.GetAddressBytes(), port)
        {
        }
        public Address(IPEndPoint addr) : this(LOCAL_NETWORK, addr.Address.GetAddressBytes(), addr.Port)
        {
        }

        public Address(ushort networkNumber, IPEndPoint addr)
            : this(networkNumber, addr.Address.GetAddressBytes(), addr.Port)
        {
        }


        public override void write(ByteStream queue)
        {
            write(queue, networkNumber);
            write(queue, MacAddress);
        }

        public Address(ByteStream queue)
        {
            networkNumber = (Unsigned16) read(queue, typeof (Unsigned16));
            MacAddress = (OctetString) read(queue, typeof (OctetString));
        }

        public OctetString MacAddress { get; }

        public UnsignedInteger NetworkNumber => networkNumber;

        public bool IsGlobal => networkNumber.Value == 0xFFFF;

        //    //
        //    //
        //    // I/P convenience
        //    //
        //    public String getMacAddressDottedString() {
        //        return macAddress.getMacAddressDottedString();
        //    }
        //
        //    public InetAddress getInetAddress() {
        //        return macAddress.getInetAddress();
        //    }
        //
        //    public InetSocketAddress getInetSocketAddress() {
        //        return macAddress.getInetSocketAddress();
        //    }
        //
        //    public int getPort() {
        //        return macAddress.getPort();
        //    }
        //
        //    public String toIpString() {
        //        return macAddress.toIpString();
        //    }
        //
        //    public String toIpPortString() {
        //        return macAddress.toIpPortString();
        //    }
        //
        //    //
        //    //
        //    // MS/TP convenience
        //    //
        //    public byte getMstpAddress() {
        //        return macAddress.getBytes()[0];
        //    }
        //
        //    @Override
        //    public String toString() {
        //        return "Address(networkNumber=" + networkNumber + ", macAddress=" + macAddress + ")";
        //    }

        //
        //
        // General convenience
        //
        public string Description
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(MacAddress.Description);
                if (networkNumber.Value != 0)
                    sb.Append('(').Append(networkNumber).Append(')');
                return sb.ToString();
            }
        }

        public override string ToString()
            => "Address [networkNumber=" + networkNumber + ", macAddress=" + MacAddress + "]";
    }
}

using System;
using System.Net;
using System.Text;

namespace BACnetDataTypes.Primitive
{
    public class OctetString : Primitive
    {
        public static readonly int DEFAULT_PORT = 47808; // 0xBAC0

        public static readonly byte TYPE_ID = 6;

        public byte[] Bytes { get; }

        public OctetString(byte[] value)
        {
            Bytes = value;
        }

        public OctetString(string dottedString) : this(dottedString, DEFAULT_PORT) { }

        public OctetString(string dottedString, int portArg)
        {
            dottedString = dottedString.Trim();
            int colon = dottedString.IndexOf(":");
            if (colon == -1)
            {
                byte[] b = BACnetUtils.dottedStringToBytes(dottedString);
                if (b.Length == 4)
                    Bytes = toBytes(b, portArg);
                else
                    Bytes = b;
            }
            else {
                byte[] ip = BACnetUtils.dottedStringToBytes(dottedString.Substring(0, colon));
                int port = int.Parse(dottedString.Substring(colon + 1));
                Bytes = toBytes(ip, port);
            }
        }

        /**
         * Convenience constructor for MS/TP addresses local to this network.
         * 
         * @param station
         *            the station id
         */
        public OctetString(byte station)
        {
            Bytes = new[] { station };
        }

        /**
         * Convenience constructor for IP addresses local to this network.
         * 
         * @param ipAddress
         * @param port
         */
        public OctetString(byte[] ipAddress, int port)
        {
            Bytes = toBytes(ipAddress, port);
        }

        public OctetString(IPEndPoint addr) : this(addr.Address.GetAddressBytes(), addr.Port) { }

        private static byte[] toBytes(byte[] ipAddress, int port)
        {
            if (ipAddress.Length != 4)
                throw new ArgumentException("IP address must have 4 parts, not " + ipAddress.Length);

            byte[] b = new byte[6];
            Array.Copy(ipAddress, 0, b, 0, ipAddress.Length);
            b[ipAddress.Length] = (byte)(port >> 8);
            b[ipAddress.Length + 1] = (byte)port;
            return b;
        }

        //
        //
        // I/P convenience
        //
        public string MacAddressDottedString => BACnetUtils.bytesToDottedString(Bytes);

        public IPAddress InetAddress => new IPAddress(IpBytes);

        public IPEndPoint InetSocketAddress => new IPEndPoint(InetAddress, Port);

        public int Port
        {
            get
            {
                if (Bytes.Length == 6)
                    return ((Bytes[4] & 0xff) << 8) | (Bytes[5] & 0xff);
                return -1;
            }
        }

        public string ToIpString() => InetAddress.ToString();

        public string ToIpPortString() => ToIpString() + ":" + Port;

        public byte[] IpBytes
        {
            get
            {
                if (Bytes.Length == 4)
                    return Bytes;

                byte[] b = new byte[4];
                Array.Copy(Bytes, 0, b, 0, 4);
                return b;
            }
        }

        //
        //
        // MS/TP convenience
        //
        public byte MstpAddress => Bytes[0];

        //
        // Reading and writing
        //
        public OctetString(ByteStream queue)
        {
            int length = (int)readTag(queue);
            Bytes = new byte[length];
            queue.Read(Bytes);
        }


        protected override void WriteImpl(ByteStream queue)
        {
            queue.Write(Bytes);
        }

        protected override long Length => Bytes.Length;

        protected override byte TypeId => TYPE_ID;

        public override string ToString() => InetSocketAddress.ToString();

        public string Description
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (Bytes.Length == 1)
                    // Assume an MS/TP address
                    sb.Append(MstpAddress & 0xff);
                else if (Bytes.Length == 6)
                    // Assume an I/P address
                    sb.Append(ToIpPortString());
                else
                    sb.Append(ToString());
                return sb.ToString();
            }
        }
    }
}

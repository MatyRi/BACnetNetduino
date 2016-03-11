using System;
using System.Net;
using System.Text;

namespace BACnetNetduino.DataTypes.Primitive
{
    internal class OctetString : Primitive
    {
        public static readonly byte TYPE_ID = 6;

        private readonly byte[] value;

        public OctetString(byte[] value)
        {
            this.value = value;
        }

        public OctetString(string dottedString) : this(dottedString, LinkLayer.DEFAULT_PORT) { }

        public OctetString(string dottedString, int defaultPort)
        {
            dottedString = dottedString.Trim();
            int colon = dottedString.IndexOf(":");
            if (colon == -1)
            {
                byte[] b = BACnetUtils.dottedStringToBytes(dottedString);
                if (b.Length == 4)
                    value = toBytes(b, defaultPort);
                else
                    value = b;
            }
            else {
                byte[] ip = BACnetUtils.dottedStringToBytes(dottedString.Substring(0, colon));
                int port = int.Parse(dottedString.Substring(colon + 1));
                value = toBytes(ip, port);
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
            value = new byte[] { station };
        }

        /**
         * Convenience constructor for IP addresses local to this network.
         * 
         * @param ipAddress
         * @param port
         */
        public OctetString(byte[] ipAddress, int port)
        {
            value = toBytes(ipAddress, port);
        }

        public OctetString(IPEndPoint addr) : this(addr.Address.GetAddressBytes(), addr.Port) { }

        public byte[] getBytes()
        {
            return value;
        }

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
        public string getMacAddressDottedString()
        {
            return BACnetUtils.bytesToDottedString(value);
        }

        public IPAddress getInetAddress()
        {
            return new IPAddress(getIpBytes());
        }

        public IPEndPoint getInetSocketAddress()
        {
            return new IPEndPoint(getInetAddress(), getPort());
        }

        public int getPort()
        {
            if (value.Length == 6)
                return ((value[4] & 0xff) << 8) | (value[5] & 0xff);
            return -1;
        }

        public string toIpString()
        {
            return getInetAddress().ToString();
        }

        public string toIpPortString()
        {
            return toIpString() + ":" + getPort();
        }

        public byte[] getIpBytes()
        {
            if (value.Length == 4)
                return value;

            byte[] b = new byte[4];
            Array.Copy(value, 0, b, 0, 4);
            return b;
        }

        //
        //
        // MS/TP convenience
        //
        public byte getMstpAddress()
        {
            return value[0];
        }

        //
        // Reading and writing
        //
        public OctetString(ByteStream queue)
        {
            int length = (int)readTag(queue);
            value = new byte[length];
            queue.pop(value);
        }

        
        /*public override void writeImpl(ByteStream queue)
        {
            queue.push(value);
        }*/

        protected override long getLength()
        {
            return value.Length;
        }

        protected override byte getTypeId()
        {
            return TYPE_ID;
        }


        public override string ToString()
        {
            return getInetSocketAddress().ToString();
        }

        public string getDescription()
        {
            StringBuilder sb = new StringBuilder();
            if (value.Length == 1)
                // Assume an MS/TP address
                sb.Append(getMstpAddress() & 0xff);
            else if (value.Length == 6)
                // Assume an I/P address
                sb.Append(toIpPortString());
            else
                sb.Append(ToString());
            return sb.ToString();
        }
    }
}

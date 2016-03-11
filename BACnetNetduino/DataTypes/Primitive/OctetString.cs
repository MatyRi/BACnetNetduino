using System;

namespace BACnetNetduino.DataTypes.Primitive
{
    internal class OctetString
    {
        public static readonly byte TYPE_ID = 6;

        private byte[] data;

        public OctetString(byte[] data)
        {
            this.data = data;
        }

        public OctetString(byte[] ipAddress, int port)
        {
            this.data = toBytes(ipAddress, port);
        }

        private static byte[] toBytes(byte[] ipAddress, int port)
        {
            if (ipAddress.Length != 4)
                throw new ArgumentException("IP address must have 4 parts, not " + ipAddress.Length);

            byte[] b = new byte[6];
            Array.Copy(ipAddress,0,b,0,ipAddress.Length);
            b[ipAddress.Length] = (byte)(port >> 8);
            b[ipAddress.Length + 1] = (byte)port;
            return b;
        }
    }
}

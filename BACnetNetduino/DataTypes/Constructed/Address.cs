using System;
using System.Collections;
using BACnetNetduino.DataTypes.Primitive;

namespace BACnetNetduino.DataTypes.Constructed
{
    internal class Address : BaseType
    {
        internal static readonly ushort LOCAL_NETWORK = 0;
        public static readonly Address GLOBAL = new Address((ushort)0xFFFF, new byte[] {});

        private readonly Unsigned16 networkNumber;
        private readonly OctetString macAddress;

        public Address(ushort networkNumber, OctetString macAddress)
        {
            this.networkNumber = new Unsigned16(networkNumber);
            this.macAddress = macAddress;
        }

        public Address(ushort networkNum, byte[] macAddress)
            : this(networkNum, new OctetString(macAddress))
        { }

        public Address(OctetString macAddress)
            : this(LOCAL_NETWORK, macAddress)
        { }

        public Address(byte[] macAddress)
            : this(LOCAL_NETWORK, new OctetString(macAddress))
        { }

        public Address(byte[] ipAddress, int port) : this(LOCAL_NETWORK, ipAddress, port) { }

        public Address(uint networkNumber, byte[] ipAddress, int port)
        {
            this.networkNumber = new Unsigned16(networkNumber);

            byte[] ipMacAddress = new byte[ipAddress.Length + 2];
            Array.Copy(ipAddress, 0, ipMacAddress, 0, ipAddress.Length);
            ipMacAddress[ipAddress.Length] = (byte)(port >> 8);
            ipMacAddress[ipAddress.Length + 1] = (byte)port;
            macAddress = new OctetString(ipMacAddress);
        }

        public OctetString MACAddress => macAddress;

        public Unsigned16 NetworkNumber => networkNumber;

        public bool isGlobal()
        {
            return networkNumber.intValue() == ushort.MaxValue;
        }
    }
}

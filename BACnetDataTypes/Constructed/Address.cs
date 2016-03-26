using System;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class Address : BaseType
    {

        public OctetString MACAddress { get; }
        public Unsigned16 NetworkNumber { get; }

        public static readonly ushort LOCAL_NETWORK = 0;
        public static readonly Address GLOBAL = new Address((ushort)0xFFFF, new byte[] {});

        public Address(ushort networkNumber, OctetString macAddress)
        {
            this.NetworkNumber = new Unsigned16(networkNumber);
            this.MACAddress = macAddress;
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
            this.NetworkNumber = new Unsigned16(networkNumber);

            byte[] ipMacAddress = new byte[ipAddress.Length + 2];
            Array.Copy(ipAddress, 0, ipMacAddress, 0, ipAddress.Length);
            ipMacAddress[ipAddress.Length] = (byte)(port >> 8);
            ipMacAddress[ipAddress.Length + 1] = (byte)port;
            MACAddress = new OctetString(ipMacAddress);
        }



        public bool IsGlobal => NetworkNumber.Value== ushort.MaxValue;
    }
}

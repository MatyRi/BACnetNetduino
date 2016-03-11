using BACnetNetduino.DataTypes.Primitive;

namespace BACnetNetduino.DataTypes.Constructed
{
    internal class Address
    {
        private static readonly ushort LOCAL_NETWORK = 0;
        public static readonly Address GLOBAL = new Address((ushort)0xFFFF, new byte[] {});

        private readonly ushort networkNumber;
        private readonly OctetString macAddress;

        public Address(ushort networkNumber, OctetString macAddress)
        {
            this.networkNumber = networkNumber;
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

    }
}

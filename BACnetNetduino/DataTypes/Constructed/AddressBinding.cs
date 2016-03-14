using System;
using BACnetNetduino.DataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Constructed
{
    class AddressBinding : BaseType
    {
        private readonly ObjectIdentifier deviceObjectIdentifier;
        private readonly Address deviceAddress;

        public AddressBinding(ObjectIdentifier deviceObjectIdentifier, Address deviceAddress)
        {
            this.deviceObjectIdentifier = deviceObjectIdentifier;
            this.deviceAddress = deviceAddress;
        }

        public override void write(ByteStream queue)
        {
            write(queue, deviceObjectIdentifier);
            write(queue, deviceAddress);
        }

        public AddressBinding(ByteStream queue)
        {
            deviceObjectIdentifier = (ObjectIdentifier) read(queue, typeof(ObjectIdentifier));
            deviceAddress = (Address) read(queue, typeof(Address));
        }

    public ObjectIdentifier DeviceObjectIdentifier => deviceObjectIdentifier;

    public Address DeviceAddress => deviceAddress;

}
}

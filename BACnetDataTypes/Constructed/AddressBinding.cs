using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class AddressBinding : BaseType
    {
        public ObjectIdentifier DeviceObjectIdentifier { get; }
        public Address DeviceAddress { get; }

        public AddressBinding(ObjectIdentifier deviceObjectIdentifier, Address deviceAddress)
        {
            DeviceObjectIdentifier = deviceObjectIdentifier;
            DeviceAddress = deviceAddress;
        }

        public override void write(ByteStream queue)
        {
            write(queue, DeviceObjectIdentifier);
            write(queue, DeviceAddress);
        }

        public AddressBinding(ByteStream queue)
        {
            DeviceObjectIdentifier = (ObjectIdentifier) read(queue, typeof(ObjectIdentifier));
            DeviceAddress = (Address) read(queue, typeof(Address));
        }



    }
}

using System;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetDataTypes.Constructed
{
    public class DeviceObjectPropertyReference : BaseType
    {
        public DeviceObjectPropertyReference(ObjectIdentifier objectIdentifier, PropertyIdentifier propertyIdentifier,
            UnsignedInteger propertyArrayIndex, ObjectIdentifier deviceIdentifier)
        {
            ObjectIdentifier = objectIdentifier;
            PropertyIdentifier = propertyIdentifier;
            PropertyArrayIndex = propertyArrayIndex;
            DeviceIdentifier = deviceIdentifier;
        }


        public override void write(ByteStream queue)
        {
            write(queue, ObjectIdentifier, 0);
            write(queue, PropertyIdentifier, 1);
            writeOptional(queue, PropertyArrayIndex, 2);
            writeOptional(queue, DeviceIdentifier, 3);
        }

        public DeviceObjectPropertyReference(ByteStream queue)
        {
            ObjectIdentifier = (ObjectIdentifier) read(queue, typeof (ObjectIdentifier), 0);
            PropertyIdentifier = (PropertyIdentifier) read(queue, typeof (PropertyIdentifier), 1);
            PropertyArrayIndex = (UnsignedInteger) readOptional(queue, typeof (UnsignedInteger), 2);
            DeviceIdentifier = (ObjectIdentifier) readOptional(queue, typeof (ObjectIdentifier), 3);
        }

        public ObjectIdentifier ObjectIdentifier { get; }

        public PropertyIdentifier PropertyIdentifier { get; }

        public UnsignedInteger PropertyArrayIndex { get; }

        public ObjectIdentifier DeviceIdentifier { get; }
    }
}

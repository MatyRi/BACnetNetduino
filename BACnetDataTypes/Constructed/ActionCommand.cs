using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    class ActionCommand : BaseType
    {
        public ActionCommand(ObjectIdentifier deviceIdentifier, ObjectIdentifier objectIdentifier,
            PropertyIdentifier propertyIdentifier, UnsignedInteger propertyArrayIndex, Encodable propertyValue,
            UnsignedInteger priority, UnsignedInteger postDelay, BBoolean quitOnFailure, BBoolean writeSuccessful)
        {
            DeviceIdentifier = deviceIdentifier;
            ObjectIdentifier = objectIdentifier;
            PropertyIdentifier = propertyIdentifier;
            PropertyArrayIndex = propertyArrayIndex;
            PropertyValue = propertyValue;
            Priority = priority;
            PostDelay = postDelay;
            QuitOnFailure = quitOnFailure;
            WriteSuccessful = writeSuccessful;
        }

        public override void write(ByteStream queue)
        {
            writeOptional(queue, DeviceIdentifier, 0);
            write(queue, ObjectIdentifier, 1);
            write(queue, PropertyIdentifier, 2);
            writeOptional(queue, PropertyArrayIndex, 3);
            write(queue, PropertyValue, 4);
            writeOptional(queue, Priority, 5);
            writeOptional(queue, PostDelay, 6);
            write(queue, QuitOnFailure, 7);
            write(queue, WriteSuccessful, 8);
        }

        public ActionCommand(ByteStream queue)
        {
            DeviceIdentifier = (ObjectIdentifier) readOptional(queue, typeof (ObjectIdentifier), 0);
            ObjectIdentifier = (ObjectIdentifier) read(queue, typeof (ObjectIdentifier), 1);
            PropertyIdentifier = (PropertyIdentifier) read(queue, typeof (PropertyIdentifier), 2);
            PropertyArrayIndex = (UnsignedInteger) readOptional(queue, typeof (UnsignedInteger), 3);
            PropertyValue = readEncodable(queue, ObjectIdentifier.ObjectType, PropertyIdentifier, PropertyArrayIndex, 4);
            Priority = (UnsignedInteger) readOptional(queue, typeof (UnsignedInteger), 5);
            PostDelay = (UnsignedInteger) readOptional(queue, typeof (UnsignedInteger), 6);
            QuitOnFailure = (BBoolean) read(queue, typeof (BBoolean), 7);
            WriteSuccessful = (BBoolean) read(queue, typeof (BBoolean), 8);
        }

        public ObjectIdentifier DeviceIdentifier { get; }

        public ObjectIdentifier ObjectIdentifier { get; }

        public PropertyIdentifier PropertyIdentifier { get; }

        public UnsignedInteger PropertyArrayIndex { get; }

        public Encodable PropertyValue { get; }

        public UnsignedInteger Priority { get; }

        public UnsignedInteger PostDelay { get; }

        public BBoolean QuitOnFailure { get; }

        public BBoolean WriteSuccessful { get; }
    }
}

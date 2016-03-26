using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class ObjectPropertyReference : BaseType
    {

        public ObjectIdentifier ObjectIdentifier { get; }
        public PropertyIdentifier PropertyIdentifier { get; }
        public UnsignedInteger PropertyArrayIndex { get; }

        public ObjectPropertyReference(ObjectIdentifier objectIdentifier, PropertyIdentifier propertyIdentifier)
        {
            this.ObjectIdentifier = objectIdentifier;
            this.PropertyIdentifier = propertyIdentifier;
        }

        public ObjectPropertyReference(ObjectIdentifier objectIdentifier, PropertyIdentifier propertyIdentifier,
                UnsignedInteger propertyArrayIndex)
        {
            this.ObjectIdentifier = objectIdentifier;
            this.PropertyIdentifier = propertyIdentifier;
            this.PropertyArrayIndex = propertyArrayIndex;
        }

        /*public override void write(ByteStream queue)
        {
            write(queue, objectIdentifier, 0);
            write(queue, propertyIdentifier, 1);
            writeOptional(queue, propertyArrayIndex, 2);
        }*/

        public ObjectPropertyReference(ByteStream queue)
        {
            // TODO objectIdentifier = read(queue, ObjectIdentifier.class, 0);
            // TODO propertyIdentifier = read(queue, PropertyIdentifier.class, 1);
            // TODO propertyArrayIndex = readOptional(queue, UnsignedInteger.class, 2);
        }

        public override string ToString()
    {
        return "ObjectPropertyReference(objectIdentifier=" + ObjectIdentifier + ", propertyIdentifier="
                + PropertyIdentifier + ", propertyArrayIndex=" + PropertyArrayIndex + ")";
    }

}
}

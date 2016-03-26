using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class ObjectPropertyReference : BaseType
    {
        private readonly ObjectIdentifier objectIdentifier;
        private readonly PropertyIdentifier propertyIdentifier;
        private UnsignedInteger propertyArrayIndex;

        public ObjectPropertyReference(ObjectIdentifier objectIdentifier, PropertyIdentifier propertyIdentifier)
        {
            this.objectIdentifier = objectIdentifier;
            this.propertyIdentifier = propertyIdentifier;
        }

        public ObjectPropertyReference(ObjectIdentifier objectIdentifier, PropertyIdentifier propertyIdentifier,
                UnsignedInteger propertyArrayIndex)
        {
            this.objectIdentifier = objectIdentifier;
            this.propertyIdentifier = propertyIdentifier;
            this.propertyArrayIndex = propertyArrayIndex;
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

    public ObjectIdentifier getObjectIdentifier()
    {
        return objectIdentifier;
    }

    public PropertyIdentifier getPropertyIdentifier()
    {
        return propertyIdentifier;
    }

    public UnsignedInteger getPropertyArrayIndex()
    {
        return propertyArrayIndex;
    }

    public override string ToString()
    {
        return "ObjectPropertyReference(objectIdentifier=" + objectIdentifier + ", propertyIdentifier="
                + propertyIdentifier + ", propertyArrayIndex=" + propertyArrayIndex + ")";
    }

}
}

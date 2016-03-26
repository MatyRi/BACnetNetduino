using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class PropertyValue : BaseType
    {
        private readonly PropertyIdentifier propertyIdentifier; // 0
        private readonly UnsignedInteger propertyArrayIndex; // 1 optional
        private Encodable value; // 2
        private readonly UnsignedInteger priority; // 3 optional

        public PropertyValue(PropertyIdentifier propertyIdentifier, Encodable value)
            : this(propertyIdentifier, null, value, null)
        {
        }


        public PropertyValue(PropertyIdentifier propertyIdentifier, UnsignedInteger propertyArrayIndex, Encodable value,
            UnsignedInteger priority)
        {
            this.propertyIdentifier = propertyIdentifier;
            this.propertyArrayIndex = propertyArrayIndex;
            this.value = value;
            this.priority = priority;
        }

        public UnsignedInteger getPriority()
        {
            return priority;
        }

        public UnsignedInteger getPropertyArrayIndex()
        {
            return propertyArrayIndex;
        }

        public PropertyIdentifier getPropertyIdentifier()
        {
            return propertyIdentifier;
        }

        public Encodable getValue()
        {
            return value;
        }

        public void setValue(Encodable value)
        {
            this.value = value;
        }


        /*public override void write(ByteStream queue)
        {
            write(queue, propertyIdentifier, 0);
            writeOptional(queue, propertyArrayIndex, 1);
            writeEncodable(queue, value, 2);
            writeOptional(queue, priority, 3);
        }*/

        public PropertyValue(ByteStream queue)
        {
            /*propertyIdentifier = read(queue, PropertyIdentifier.class,0);
            propertyArrayIndex = readOptional(queue, UnsignedInteger.class,1);
            value = readEncodable(queue, ThreadLocalObjectTypeStack.get(), propertyIdentifier, propertyArrayIndex, 2);
            priority = readOptional(queue, UnsignedInteger.class,3);*/
        }


        public override string ToString()
        {
            return "PropertyValue(propertyIdentifier=" + propertyIdentifier + ", propertyArrayIndex=" +
                   propertyArrayIndex
                   + ", value=" + value + ", priority=" + priority + ")";
        }
    }
}

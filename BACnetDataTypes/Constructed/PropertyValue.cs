using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class PropertyValue : BaseType
    {

        public UnsignedInteger Priority { get; }
        public UnsignedInteger PropertyArrayIndex { get; }
        public PropertyIdentifier PropertyIdentifier { get; }
        public Encodable Value { get; set; }


        public PropertyValue(PropertyIdentifier propertyIdentifier, Encodable value)
            : this(propertyIdentifier, null, value, null)
        {
        }


        public PropertyValue(PropertyIdentifier propertyIdentifier, UnsignedInteger propertyArrayIndex, Encodable value,
            UnsignedInteger priority)
        {
            this.PropertyIdentifier = propertyIdentifier;
            this.PropertyArrayIndex = propertyArrayIndex;
            this.Value = value;
            this.Priority = priority;
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
            return "PropertyValue(propertyIdentifier=" + PropertyIdentifier + ", propertyArrayIndex=" +
                   PropertyArrayIndex
                   + ", value=" + Value + ", priority=" + Priority + ")";
        }
    }
}

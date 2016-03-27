using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.EventParameter
{
    class Extended : EventParameter
    {
        public static readonly byte TYPE_ID = 9;

        public Extended(UnsignedInteger vendorId, UnsignedInteger extendedEventType, SequenceOf parameters)
        {
            VendorId = vendorId;
            ExtendedEventType = extendedEventType;
            Parameters = parameters;
        }


        protected override void writeImpl(ByteStream queue)
        {
            write(queue, VendorId, 0);
            write(queue, ExtendedEventType, 1);
            write(queue, Parameters, 2);
        }

        public Extended(ByteStream queue)
        {
            VendorId = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 0);
            ExtendedEventType = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 1);
            Parameters = readSequenceOf(queue, typeof (Parameter), 2);
        }


        protected override int TypeId => TYPE_ID;

        public UnsignedInteger VendorId { get; }

        public UnsignedInteger ExtendedEventType { get; }

        public SequenceOf Parameters { get; }
    }

    public class Parameter : BaseType
    {
        private readonly Primitive.Primitive _primitive;
        private readonly DeviceObjectPropertyReference _reference;

        public Parameter(Null primitive)
        {
            _primitive = primitive;
        }

        public Parameter(Real primitive)
        {
            _primitive = primitive;
        }

        public Parameter(UnsignedInteger primitive)
        {
            _primitive = primitive;
        }

        public Parameter(BBoolean primitive)
        {
            _primitive = primitive;
        }

        public Parameter(BDouble primitive)
        {
            _primitive = primitive;
        }

        public Parameter(OctetString primitive)
        {
            _primitive = primitive;
        }

        public Parameter(BitString primitive)
        {
            _primitive = primitive;
        }

        public Parameter(Primitive.Enumerated primitive)
        {
            _primitive = primitive;
        }

        public Parameter(DeviceObjectPropertyReference reference)
        {
            _reference = reference;
        }

        public void write(ByteStream queue)
        {
            if (_primitive != null)
                _primitive.write(queue);
            else
                _reference.write(queue, 0);
        }
    }
}

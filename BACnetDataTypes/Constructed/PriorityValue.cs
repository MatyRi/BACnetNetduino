using System.Text;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class PriorityValue : BaseType
    {
        public Null NullValue { get; }
        public Real RealValue { get; }
        public BinaryPV BinaryValue { get; }
        public UnsignedInteger IntegerValue { get; }
        public Encodable ConstructedValue { get; }

        public PriorityValue(Null nullValue)
        {
            this.NullValue = nullValue;
        }

        public PriorityValue(Real realValue)
        {
            this.RealValue = realValue;
        }

        public PriorityValue(BinaryPV binaryValue)
        {
            this.BinaryValue = binaryValue;
        }

        public PriorityValue(UnsignedInteger integerValue)
        {
            this.IntegerValue = integerValue;
        }

        public PriorityValue(BaseType constructedValue)
        {
            this.ConstructedValue = constructedValue;
        }

        public bool IsNull => NullValue != null;

        public Encodable Value
        {
            get
            {
                if (NullValue != null)
                    return NullValue;
                if (RealValue != null)
                    return RealValue;
                if (BinaryValue != null)
                    return BinaryValue;
                if (IntegerValue != null)
                    return IntegerValue;
                return ConstructedValue;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("PriorityValue(");
            if (NullValue != null)
                sb.Append("nullValue=").Append(NullValue);
            else if (RealValue != null)
                sb.Append("realValue=").Append(RealValue);
            else if (BinaryValue != null)
                sb.Append("binaryValue=").Append(BinaryValue);
            else if (IntegerValue != null)
                sb.Append("integerValue=").Append(IntegerValue);
            else if (ConstructedValue != null)
                sb.Append("constructedValue=").Append(ConstructedValue);
            sb.Append(")");
            return sb.ToString();
        }

        /*public override void write(ByteStream queue)
        {
            if (nullValue != null)
                nullValue.write(queue);
            else if (realValue != null)
                realValue.write(queue);
            else if (binaryValue != null)
                binaryValue.write(queue);
            else if (integerValue != null)
                integerValue.write(queue);
            else
                constructedValue.write(queue, 0);
        }*/

        public PriorityValue(ByteStream queue)
        {
            // Sweet Jesus...
            int tag = (queue.PeekFromHere(0) & 0xff);
            if ((tag & 8) == 8)
            {
                // A class tag, so this is a constructed value.
                ConstructedValue = new AmbiguousValue(queue, 0);
            }
            else
            {
                // A primitive value
                tag = tag >> 4;
                if (tag == Null.TYPE_ID)
                    NullValue = new Null(queue);
                else if (tag == Real.TYPE_ID)
                    RealValue = new Real(queue);
                else if (tag == Primitive.Enumerated.TYPE_ID)
                    BinaryValue = new BinaryPV(queue);
                else if (tag == UnsignedInteger.TYPE_ID)
                    IntegerValue = new UnsignedInteger(queue);
                else
                    throw new BACnetErrorException(ErrorClass.Property, ErrorCode.InvalidDataType,
                        "Unsupported primitive id: " + tag);
            }
        }
    }
}

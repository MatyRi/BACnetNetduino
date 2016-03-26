using System.Text;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class PriorityValue : BaseType
    {
        private Null nullValue;
        private Real realValue;
        private BinaryPV binaryValue;
        private UnsignedInteger integerValue;
        private Encodable constructedValue;

        public PriorityValue(Null nullValue)
        {
            this.nullValue = nullValue;
        }

        public PriorityValue(Real realValue)
        {
            this.realValue = realValue;
        }

        public PriorityValue(BinaryPV binaryValue)
        {
            this.binaryValue = binaryValue;
        }

        public PriorityValue(UnsignedInteger integerValue)
        {
            this.integerValue = integerValue;
        }

        public PriorityValue(BaseType constructedValue)
        {
            this.constructedValue = constructedValue;
        }

        public Null getNullValue()
        {
            return nullValue;
        }

        public Real getRealValue()
        {
            return realValue;
        }

        public BinaryPV getBinaryValue()
        {
            return binaryValue;
        }

        public UnsignedInteger getIntegerValue()
        {
            return integerValue;
        }

        public Encodable getConstructedValue()
        {
            return constructedValue;
        }

        public bool isNull()
        {
            return nullValue != null;
        }

        public Encodable getValue()
        {
            if (nullValue != null)
                return nullValue;
            if (realValue != null)
                return realValue;
            if (binaryValue != null)
                return binaryValue;
            if (integerValue != null)
                return integerValue;
            return constructedValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("PriorityValue(");
            if (nullValue != null)
                sb.Append("nullValue=").Append(nullValue);
            else if (realValue != null)
                sb.Append("realValue=").Append(realValue);
            else if (binaryValue != null)
                sb.Append("binaryValue=").Append(binaryValue);
            else if (integerValue != null)
                sb.Append("integerValue=").Append(integerValue);
            else if (constructedValue != null)
                sb.Append("constructedValue=").Append(constructedValue);
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
        if ((tag & 8) == 8) {
            // A class tag, so this is a constructed value.
            constructedValue = new AmbiguousValue(queue, 0);
    }
        else {
            // A primitive value
            tag = tag >> 4;
            if (tag == Null.TYPE_ID)
                nullValue = new Null(queue);
            else if (tag == Real.TYPE_ID)
                realValue = new Real(queue);
            else if (tag == Primitive.Enumerated.TYPE_ID)
                binaryValue = new BinaryPV(queue);
            else if (tag == UnsignedInteger.TYPE_ID)
                integerValue = new UnsignedInteger(queue);
            else
                throw new BACnetErrorException(ErrorClass.property, ErrorCode.invalidDataType,
                        "Unsupported primitive id: " + tag);
}
    }
    }
}

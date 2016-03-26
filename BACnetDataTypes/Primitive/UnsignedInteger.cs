using System;

namespace BACnetDataTypes.Primitive
{
    public class UnsignedInteger : Primitive
    {
        public static readonly byte TYPE_ID = 2;

        public UnsignedInteger(uint value)
        {
            if (value < 0)
                throw new ArgumentException("Value cannot be less than zero");
            Value = value;
        }

        /*public UnsignedInteger(long value)
        {
            bigValue = new BitArray();.valueOf(value);
        }*/

        /*public UnsignedInteger(BitArray value)
        {
            if (value.signum() == -1)
                throw new ArgumentException("Value cannot be less than zero");
            bigValue = value;
        }*/

        public uint Value { get; }

        /*public long longValue()
        {
            if (bigValue == null)
                return internalValue;
            return bigValue.longValue();
        }*/

        /*public BigInteger bigIntegerValue()
        {
            if (bigValue == null)
                return BigInteger.valueOf(internalValue);
            return bigValue;
        }*/

        //
        // Reading and writing
        //
        public UnsignedInteger(ByteStream queue)
        {
            int length = (int)readTag(queue);
            if (length < 4)
            {
                while (length > 0)
                    Value |= (uint)(queue.popU1B() & 0xff) << (--length * 8);
            }
            else {
                byte[] bytes = new byte[length + 1];
                queue.Read(bytes, 1, length);
                //bigValue = new BigInteger(bytes);
            }
        }

        public UnsignedInteger(ByteStream queue, int contextTag)
        {
            int length = (int)readTag(queue);
            if (length < 4)
            {
                while (length > 0)
                    Value |= (uint)(queue.popU1B() & 0xff) << (--length * 8);
            }
            else {
                byte[] bytes = new byte[length + 1];
                queue.Read(bytes, 1, length);
                //bigValue = new BigInteger(bytes);
            }
        }

        // TODO to fix>
        private object bigValue = null;

        protected override void writeImpl(ByteStream queue)
            {
                int length = (int)Length;
                if (bigValue == null)
                {
                    while (length > 0)
                        queue.WriteByte((byte) (Value >> (--length * 8)));
                }
                else {
                    byte[] bytes = new byte[length];

                    /*for (int i = 0; i < bigValue.bitLength(); i++)
                    {
                        if (bigValue.testBit(i))
                            bytes[length - i / 8 - 1] |= 1 << (i % 8);
                    }*/

                    queue.Write(bytes);
                }
            }

        protected override long Length
        {
            get
            {
                //if (bigValue == null)
                //{
                int length;
                if (Value < 0x100)
                    length = 1;
                else if (Value < 0x10000)
                    length = 2;
                else if (Value < 0x1000000)
                    length = 3;
                else
                    length = 4;

                return length;
                //}

                //if (bigValue.intValue() == 0)
                //    return 1;
                //return (bigValue.bitLength() + 7) / 8;
            }
        }

        protected override byte TypeId => TYPE_ID;

        public override string ToString() => Value.ToString();
    }
}

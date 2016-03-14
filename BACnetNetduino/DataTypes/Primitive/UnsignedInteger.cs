using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Primitive
{
    class UnsignedInteger : Primitive
    {
        public static readonly byte TYPE_ID = 2;

        private uint internalValue;

        public UnsignedInteger(uint value)
        {
            if (value < 0)
                throw new ArgumentException("Value cannot be less than zero");
            internalValue = value;
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

        public uint intValue()
        {
            return internalValue;
        }

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
                    internalValue |= (uint)(queue.popU1B() & 0xff) << (--length * 8);
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
                    internalValue |= (uint)(queue.popU1B() & 0xff) << (--length * 8);
            }
            else {
                byte[] bytes = new byte[length + 1];
                queue.Read(bytes, 1, length);
                //bigValue = new BigInteger(bytes);
            }
        }

        /* TODO protected override void writeImpl(ByteStream queue)
            {
                int length = (int)getLength();
                if (bigValue == null)
                {
                    while (length > 0)
                        queue.push(internalValue >> (--length * 8));
                }
                else {
                    byte[] bytes = new byte[length];

                    for (int i = 0; i < bigValue.bitLength(); i++)
                    {
                        if (bigValue.testBit(i))
                            bytes[length - i / 8 - 1] |= 1 << (i % 8);
                    }

                    queue.push(bytes);
                }
            }*/

        protected override long getLength()
        {
            //if (bigValue == null)
            //{
                int length;
                if (internalValue < 0x100)
                    length = 1;
                else if (internalValue < 0x10000)
                    length = 2;
                else if (internalValue < 0x1000000)
                    length = 3;
                else
                    length = 4;

                return length;
            //}

            //if (bigValue.intValue() == 0)
            //    return 1;
            //return (bigValue.bitLength() + 7) / 8;
        }

    protected override byte getTypeId()
        {
            return TYPE_ID;
        }

    public override string ToString()
        {
            return internalValue.ToString();

        }
    }
}

using System;

namespace BACnetDataTypes.Primitive
{
    public class UnsignedInteger : Primitive
    {
        public static readonly byte TYPE_ID = 2;

        public uint Value { get; }

        public UnsignedInteger(uint value)
        {
            Value = value;
        }

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
                throw new NotSupportedException("Code does not support uint values longer then 4 bytes!");
                //byte[] bytes = new byte[length + 1];
                //queue.Read(bytes, 1, length);
                //BitConverter
                //bigValue = new BigInteger(bytes);
            }
        }

        protected override void WriteImpl(ByteStream queue)
            {
                int length = (int)Length;
                //if (BigValue == null)
                //{
                    while (length > 0)
                        queue.WriteByte((byte) (Value >> (--length * 8)));
                //}
                //else {
                //    byte[] bytes = new byte[length];

                    /*for (int i = 0; i < bigValue.bitLength(); i++)
                    {
                        if (bigValue.testBit(i))
                            bytes[length - i / 8 - 1] |= 1 << (i % 8);
                    }*/

                //    queue.Write(bytes);
                //}
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

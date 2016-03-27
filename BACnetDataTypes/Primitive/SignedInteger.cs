using System;

namespace BACnetDataTypes.Primitive
{
    public class SignedInteger : Primitive
    {
        public static readonly byte TYPE_ID = 3;

        public int Value { get; }

        public SignedInteger(int value)
        {
            Value = value;
        }

        //
        // Reading and writing
        //
        public SignedInteger(ByteStream queue)
        {
            // Read the data length value.
            int length = (int)readTag(queue);

            byte[] bytes = new byte[length];
            queue.Read(bytes);

            if (length < 5)
                Value = BitConverter.ToInt32(bytes, 0);
            else
                throw new NotImplementedException();
        }

        protected override void WriteImpl(ByteStream queue)
        {
            //if (bigValue == null)
            //{
            long length = Length;
            while (length > 0)
                queue.WriteByte((byte) (Value >> (int) (--length * 8)));
            //}
            //else
            //    queue.push(bigValue.toByteArray());
        }

        protected override long Length
        {
            get
            {
                //if (bigValue == null)
                //{
                int length;
                if (Value < byte.MaxValue && Value > byte.MinValue)
                    length = 1;
                else if (Value < short.MaxValue && Value > short.MinValue)
                    length = 2;
                else if (Value < 8388607 && Value > -8388608)
                    length = 3;
                else
                    length = 4;
                return length;
                //}
                //return bigValue.toByteArray().length;
            }
        }

        protected override byte TypeId => TYPE_ID;

        public override string ToString() => Value.ToString();
    }
}

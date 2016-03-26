using System;

namespace BACnetDataTypes.Primitive
{
    public class SignedInteger : Primitive
    {
        public static readonly byte TYPE_ID = 3;

        public SignedInteger(int value)
        {
            Value = value;
        }

        public int Value { get; }

        //
        // Reading and writing
        //
        public SignedInteger(ByteStream queue)
        {
            // Read the data length value.
            int length = (int)readTag(queue);

            byte[] bytes = new byte[length];
            queue.pop(bytes);

            if (length < 5)
                Value = BitConverter.ToInt32(bytes, 0);
            else
                throw new NotImplementedException();
        }

        /*public override void writeImpl(ByteStream queue)
        {
            if (bigValue == null)
            {
                long length = getLength();
                while (length > 0)
                    queue.push(internalValue >> (--length * 8));
            }
            else
                queue.push(bigValue.toByteArray());
        }*/

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

using System;

namespace BACnetDataTypes.Primitive
{
    public class SignedInteger : Primitive
    {
        public static readonly byte TYPE_ID = 3;

        private int internalValue;

        public SignedInteger(int value)
        {
            internalValue = value;
        }

        public int intValue()
        {
            return internalValue;
        }

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
                internalValue = BitConverter.ToInt32(bytes, 0);
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

        protected override long getLength()
        {
            //if (bigValue == null)
            //{
                int length;
                if (internalValue < byte.MaxValue && internalValue > byte.MinValue)
                    length = 1;
                else if (internalValue < short.MaxValue && internalValue > short.MinValue)
                    length = 2;
                else if (internalValue < 8388607 && internalValue > -8388608)
                    length = 3;
                else
                    length = 4;
                return length;
            //}
            //return bigValue.toByteArray().length;
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

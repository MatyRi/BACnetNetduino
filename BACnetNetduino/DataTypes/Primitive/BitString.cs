using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Primitive
{
    class BitString : Primitive
    {
        public static readonly byte TYPE_ID = 8;

        private bool[] value;

        public BitString(bool[] value)
        {
            this.value = value;
        }

        public BitString(int size, bool defaultValue)
        {
            value = new bool[size];
            if (defaultValue)
            {
                for (int i = 0; i < size; i++)
                    value[i] = true;
            }
        }

        public bool[] getValue()
        {
            return value;
        }

        public void setAll(bool value)
        {
            bool[] values = getValue();
            for (int i = 0; i < values.Length; i++)
                values[i] = value;
        }

        //
        // Reading and writing
        //
        public BitString(ByteStream queue)
        {
            int Length = (int)readTag(queue) - 1;
            int remainder = queue.popU1B();

            if (Length == 0)
                value = new bool[0];
            else {
                byte[] data = new byte[Length];
                queue.pop(data);
                // TODO value = BACnetUtils.convertToBooleans(data, Length * 8 - remainder);
            }
        }

        /*public override void writeImpl(ByteStream queue)
        {
            if (value.Length == 0)
                queue.push((byte)0);
            else {
                int remainder = value.Length % 8;
                if (remainder > 0)
                    remainder = 8 - remainder;
                queue.push((byte)remainder);
                queue.push(BACnetUtils.convertToBytes(value));
            }
        }*/

        
    protected override long getLength()
        {
            if (value.Length == 0)
                return 1;
            return (value.Length - 1) / 8 + 2;
        }

        
    protected override byte getTypeId()
        {
            return TYPE_ID;
        }

        
    public override string ToString()
        {
            return value.ToString();
        }
    }
}

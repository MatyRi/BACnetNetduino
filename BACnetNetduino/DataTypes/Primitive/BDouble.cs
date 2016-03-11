using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Primitive
{
    class BDouble : Primitive
    {
        public static readonly byte TYPE_ID = 5;

        private readonly double value;

        public BDouble(double value)
        {
            this.value = value;
        }

        public double doubleValue()
        {
            return value;
        }

        //
        // Reading and writing
        //
        public BDouble(ByteStream queue)
        {
            readTag(queue);
            value = queue.ReadDouble();
        }


        /*public override void writeImpl(ByteStream queue)
        {
            BACnetUtils.pushLong(queue, java.lang.Double.doubleToLongBits(value));
        }*/


        protected override long getLength()
        {
            return 8;
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

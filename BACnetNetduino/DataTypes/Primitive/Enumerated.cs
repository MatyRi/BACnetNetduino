using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Primitive
{
    class Enumerated : UnsignedInteger
    {
        public static readonly byte TYPE_ID = 9;

        public Enumerated(int value) : base(value) { }

        public Enumerated(BitArray value) : base(value) { }

        public byte byteValue()
        {
            return (byte)intValue();
        }

        /*public bool equals(Enumerated that)
        {
            //AdK
            if (that == null) return false;
            return intValue() == that.intValue();
        }*/

        //
        // Reading and writing
        //
        public Enumerated(ByteStream queue) : base(queue) { }

        protected override byte getTypeId()
        {
            return TYPE_ID;
        }
    }
}

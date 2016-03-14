using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Primitive
{
    class Unsigned16 : UnsignedInteger
    {
        private static readonly int MAX = 0xffff;

        public Unsigned16(uint value) : base(value)
        {
            if (value > MAX)
                throw new ArgumentException("Value cannot be greater than " + MAX);
        }

        public Unsigned16(ByteStream queue) : base(queue) { }
    }
}

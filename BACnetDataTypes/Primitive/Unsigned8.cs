using System;
using Microsoft.SPOT;

namespace BACnetDataTypes.Primitive
{
    public class Unsigned8 : UnsignedInteger
    {
        private static readonly int MAX = byte.MaxValue; //0xffff;

        public Unsigned8(byte value) : base(value)
        {
            if (value > MAX)
                throw new ArgumentException("Value cannot be greater than " + MAX);
        }

        public Unsigned8(ByteStream queue) : base(queue) { }
    }
}

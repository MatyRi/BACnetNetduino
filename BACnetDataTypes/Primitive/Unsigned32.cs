using System;
using Microsoft.SPOT;

namespace BACnetDataTypes.Primitive
{
    public class Unsigned32 : UnsignedInteger
    {
        private static readonly uint MAX = uint.MaxValue; //0xffff;

        public Unsigned32(uint value) : base(value)
        {
            if (value > MAX)
                throw new ArgumentException("Value cannot be greater than " + MAX);
        }

        public Unsigned32(ByteStream queue) : base(queue) { }
    }
}

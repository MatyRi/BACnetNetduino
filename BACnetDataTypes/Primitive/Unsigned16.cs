using System;

namespace BACnetDataTypes.Primitive
{
    public class Unsigned16 : UnsignedInteger
    {
        private static readonly int MAX = ushort.MaxValue; //0xffff;

        public Unsigned16(ushort value) : base(value)
        {
            if (value > MAX)
                throw new ArgumentException("Value cannot be greater than " + MAX);
        }

        public Unsigned16(ByteStream queue) : base(queue) { }
    }
}

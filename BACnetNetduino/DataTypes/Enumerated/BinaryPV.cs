using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Enumerated
{
    class BinaryPV : Primitive.Enumerated
    {
        public static readonly BinaryPV inactive = new BinaryPV(0);
        public static readonly BinaryPV active = new BinaryPV(1);

        public static readonly BinaryPV[] ALL = { inactive, active, };

    public BinaryPV(uint value) : base(value) { }

    public BinaryPV(ByteStream queue) : base(queue) { }
}
}

using System;
using Microsoft.SPOT;

namespace BACnetNetduino.APDU
{
    class ComplexACK : AckAPDU
    {
        public static readonly byte TYPE_ID = 3;

        internal static ComplexACK Parse(ByteStream source)
        {
            return null;
        }
    }
}

using System;
using Microsoft.SPOT;

namespace BACnetNetduino.APDU
{
    class Abort : AckAPDU
    {
        public static readonly byte TYPE_ID = 7;

        internal static Abort Parse(ByteStream source)
        {
            return null;
        }
    }
}

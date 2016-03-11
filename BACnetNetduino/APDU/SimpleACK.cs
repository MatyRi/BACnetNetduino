using System;
using Microsoft.SPOT;

namespace BACnetNetduino.APDU
{
    class SimpleACK : AckAPDU
    {
        public static readonly byte TYPE_ID = 2;

        internal static SimpleACK Parse(ByteStream source)
        {
            return null;
        }
    }
}

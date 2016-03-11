using System;
using Microsoft.SPOT;

namespace BACnetNetduino.APDU
{
    class SegmentACK : AckAPDU
    {
        public static readonly byte TYPE_ID = 4;

        internal static SegmentACK Parse(ByteStream source)
        {
            return null;
        }
    }
}

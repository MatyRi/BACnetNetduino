using System;
using Microsoft.SPOT;

namespace BACnetNetduino.APDU
{
    class Reject : AckAPDU
    {
        public static readonly byte TYPE_ID = 6;

        internal static Reject Parse(ByteStream source)
        {
            return null;
        }
    }
}

using System;
using Microsoft.SPOT;

namespace BACnetNetduino.APDU
{
    class ConfirmedRequest : APDU
    {
        public static readonly byte TYPE_ID = 0;

        internal static ConfirmedRequest Parse(ByteStream source)
        {
            return null;
        }

    }
}

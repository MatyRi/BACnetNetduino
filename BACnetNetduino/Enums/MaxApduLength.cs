using System;
using Microsoft.SPOT;

namespace BACnetNetduino.Enums
{
    /*
        UP_TO_50(0, 50), // MinimumMessageSize
        UP_TO_128(1, 128), //
        UP_TO_206(2, 206), // Fits in a LonTalk frame
        UP_TO_480(3, 480), // Fits in an ARCNET frame
        UP_TO_1024(4, 1024), //
        UP_TO_1476(5, 1476); // Fits in an ISO 8802-3 frame
    */

    public enum MaxApduLength
    {
        UP_TO_50 = 0,
        UP_TO_128 = 1,
        UP_TO_206 = 2,
        UP_TO_480 = 3,
        UP_TO_1024 = 4,
        UP_TO_1476 = 5
    }


    public static class ApduLengthExt
    {
        public static int GetMaxApduLength(this MaxApduLength length)
        {
            switch (length)
            {
                case MaxApduLength.UP_TO_50:
                    return 50;
                case MaxApduLength.UP_TO_128:
                    return 128;
                case MaxApduLength.UP_TO_206:
                    return 206;
                case MaxApduLength.UP_TO_480:
                    return 480;
                case MaxApduLength.UP_TO_1024:
                    return 1024;
                case MaxApduLength.UP_TO_1476:
                    return 1476;
                default:
                    throw new ArgumentOutOfRangeException(nameof(length));
            }
        }

        public static int GetId(this MaxApduLength length)
        {
            return (int) length;
        }
    }
}

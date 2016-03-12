using System;
using Microsoft.SPOT;

namespace BACnetNetduino.Enums
{
    public enum MaxSegments
    {
        UNSPECIFIED = 0,
        UP_TO_2 = 1,
        UP_TO_4 = 2,
        UP_TO_8 = 3,
        UP_TO_16 = 4,
        UP_TO_32 = 5,
        UP_TO_64 = 6,
        MORE_THAN_64 = 7
    }


    public static class SegmentsExt
    {
        public static int GetMaxSegments(this MaxSegments segments)
        {
            switch (segments)
            {
                case MaxSegments.UP_TO_2:
                    return 2;
                case MaxSegments.UP_TO_4:
                    return 4;
                case MaxSegments.UP_TO_8:
                    return 8;
                case MaxSegments.UP_TO_16:
                    return 16;
                case MaxSegments.UP_TO_32:
                    return 32;
                case MaxSegments.UP_TO_64:
                    return 64;
                case MaxSegments.MORE_THAN_64:
                case MaxSegments.UNSPECIFIED:
                default:
                    return int.MaxValue;
            }
        }

        public static int GetId(this MaxSegments segments)
        {
            return (int) segments;
        }
    }
}

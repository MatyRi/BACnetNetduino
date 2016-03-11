using System;
using Microsoft.SPOT;

namespace BACnetNetduino
{
    class BACnetUtils
    {
        public static int toInt(byte b)
        {
            return b & 0xff;
        }

        public static long toLong(byte b)
        {
            return (b & 0xff);
        }
    }
}

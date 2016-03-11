using System;
using Microsoft.SPOT;

namespace BACnetNetduino.Exception
{
    class BACnetTimeoutException : BACnetException
    {
        public BACnetTimeoutException() : base() { }

        public BACnetTimeoutException(string message) : base() { }
    }
}

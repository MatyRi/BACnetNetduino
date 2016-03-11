using System;
using Microsoft.SPOT;

namespace BACnetNetduino.Exception
{
    class BACnetRuntimeException : System.Exception
    {
        public BACnetRuntimeException() : base() { }

        public BACnetRuntimeException(string message, System.Exception cause) : base(message, cause) { }

        public BACnetRuntimeException(string message) : base(message) { }

        public BACnetRuntimeException(System.Exception cause) : base(string.Empty, cause) { }

    }
}

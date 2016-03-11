using System;
using Microsoft.SPOT;

namespace BACnetNetduino.NPDU
{
    class MessageValidationAssertionException : System.Exception
    {
        public MessageValidationAssertionException(string message) : base(message) { }
    }
}

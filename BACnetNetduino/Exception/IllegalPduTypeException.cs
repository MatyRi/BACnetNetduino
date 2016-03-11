using System;
using Microsoft.SPOT;

namespace BACnetNetduino.Exception
{
    class IllegalPduTypeException : BACnetRuntimeException
    {
        public IllegalPduTypeException(string message) : base(message) { }
    }
}

using System;
using Microsoft.SPOT;

namespace BACnetNetduino.Exception
{
    class ReflectionException : BACnetException
    {
        public ReflectionException(System.Exception cause) : base(cause) { }
    }
}

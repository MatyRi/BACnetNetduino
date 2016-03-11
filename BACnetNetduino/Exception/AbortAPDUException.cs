using System;
using BACnetNetduino.APDU;
using Microsoft.SPOT;

namespace BACnetNetduino.Exception
{
    class AbortAPDUException : BACnetException
    {
        private readonly Abort apdu;

        public AbortAPDUException(Abort apdu) : base(apdu.ToString()) { }

        public Abort getApdu()
        {
            return apdu;
        }
    }
}

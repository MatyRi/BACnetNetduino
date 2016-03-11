using System;
using BACnetNetduino.APDU;
using Microsoft.SPOT;

namespace BACnetNetduino.Exception
{
    class RejectAPDUException : BACnetException
    {
        private readonly Reject apdu;

    public RejectAPDUException(Reject apdu) : base(apdu.ToString())
        {
            this.apdu = apdu;
        }

        public Reject getApdu()
        {
            return apdu;
        }
    }
}

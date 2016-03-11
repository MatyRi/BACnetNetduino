using System;
using BACnetNetduino.APDU;
using BACnetNetduino.DataTypes.Constructed;
using Microsoft.SPOT;

namespace BACnetNetduino.Exception
{
    class ErrorAPDUException : BACnetException
    {
        private readonly Error apdu;

    public ErrorAPDUException(Error apdu) : base(apdu.ToString())
        {
            this.apdu = apdu;
        }

        public Error getApdu()
        {
            return apdu;
        }

        public BACnetError getBACnetError()
        {
            return apdu.getError().getError();
        }
    }
}

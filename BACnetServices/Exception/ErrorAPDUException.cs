using BACnetDataTypes.Constructed;
using BACnetDataTypes.Exception;

namespace BACnetServices.Exception
{
    class ErrorAPDUException : BACnetException
    {
        public ErrorAPDUException(APDU.Error apdu) : base(apdu.ToString())
        {
            Apdu = apdu;
        }

        public APDU.Error Apdu { get; }

        public BACnetError BaCnetError => Apdu.ErrorValue.Error;
    }
}

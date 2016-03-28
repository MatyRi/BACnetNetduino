using BACnetDataTypes.Exception;
using BACnetServices.APDU;

namespace BACnetServices.Exception
{
    class RejectAPDUException : BACnetException
    {
        public RejectAPDUException(Reject apdu) : base(apdu.ToString())
        {
            this.Apdu = apdu;
        }

        public Reject Apdu { get; }
    }
}

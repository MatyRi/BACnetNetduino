using BACnetDataTypes.Exception;
using BACnetServices.APDU;

namespace BACnetServices.Exception
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

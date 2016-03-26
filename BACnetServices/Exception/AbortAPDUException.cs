using BACnetDataTypes.Exception;
using BACnetServices.APDU;

namespace BACnetServices.Exception
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

using BACnetDataTypes.Exception;
using BACnetServices.APDU;

namespace BACnetServices.Exception
{
    class AbortAPDUException : BACnetException
    {
        public AbortAPDUException(Abort apdu) : base(apdu.ToString()) { }

        public Abort Apdu { get; }
    }
}

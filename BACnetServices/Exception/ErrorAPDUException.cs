using BACnetDataTypes.Constructed;
using BACnetDataTypes.Exception;

namespace BACnetServices.Exception
{
    class ErrorAPDUException : BACnetException
    {
        private readonly APDU.Error apdu;

    public ErrorAPDUException(APDU.Error apdu) : base(apdu.ToString())
        {
            this.apdu = apdu;
        }

        public APDU.Error getApdu()
        {
            return apdu;
        }

        public BACnetError getBACnetError()
        {
            return apdu.getError().getError();
        }
    }
}

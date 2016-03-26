using System.Text;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Error;

namespace BACnetDataTypes.Exception
{
    public class BACnetErrorException : BACnetException
    {
        public BACnetErrorException(byte choice, ErrorClass errorClass, ErrorCode errorCode) : base(GetBaseMessage(errorClass, errorCode, null))
        {
            Error = new BaseError(choice, new BACnetError(errorClass, errorCode));
        }

        public BACnetErrorException(byte choice, BACnetServiceException e) : base(e)
        {
            Error = new BaseError(choice, new BACnetError(e.ErrorClass, e.ErrorCode));
        }

        public BACnetErrorException(ErrorClass errorClass, ErrorCode errorCode) : base(GetBaseMessage(errorClass, errorCode, null))
        {
            Error = new BaseError((byte)127, new BACnetError(errorClass, errorCode));
        }

        public BACnetErrorException(BACnetServiceException e) : base(e.Message)
        {
            Error = new BaseError((byte)127, new BACnetError(e.ErrorClass, e.ErrorCode));
        }

        public BACnetErrorException(ErrorClass errorClass, ErrorCode errorCode, string message) : base (GetBaseMessage(errorClass, errorCode, message))
        {
            Error = new BaseError((byte)127, new BACnetError(errorClass, errorCode));
        }

        public BACnetErrorException(BaseError error)
        {
            this.Error = error;
        }

        public BaseError Error { get; }

        private static string GetBaseMessage(ErrorClass errorClass, ErrorCode errorCode, string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(errorClass.ToString());
            sb.Append(": ");
            sb.Append(errorCode.ToString());
            if (message != null)
                sb.Append(" '").Append(message).Append("'");
            return sb.ToString();
        }
    }
}

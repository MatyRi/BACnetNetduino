using BACnetDataTypes.Enumerated;

namespace BACnetDataTypes.Exception
{
    public class BACnetServiceException : System.Exception
    {
        public BACnetServiceException(ErrorClass errorClass, ErrorCode errorCode)
        {
            ErrorClass = errorClass;
            ErrorCode = errorCode;
        }

        public BACnetServiceException(ErrorClass errorClass, ErrorCode errorCode, string message) : base(message)
        {
            ErrorClass = errorClass;
            ErrorCode = errorCode;
        }

        public ErrorClass ErrorClass { get; }

        public ErrorCode ErrorCode { get; }

        public bool equals(ErrorClass errorClass, ErrorCode errorCode)
        {
            return ErrorClass.Equals(errorClass) && ErrorCode.Equals(errorCode);
        }

        public override string Message
        {
            get
            {
                string message = "class=" + ErrorClass + ", code=" + ErrorCode;
                string userDesc = base.Message;
                if (userDesc != null)
                    message += ", message=" + userDesc;
                return message;
            }
        }
    }
}

using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;

namespace BACnetDataTypes.Constructed
{
    public class BACnetError : BaseType
    {

        public ErrorClass ErrorClass { get; }
        public ErrorCode ErrorCode { get; }

        public BACnetError(ErrorClass errorClass, ErrorCode errorCode)
        {
            ErrorClass = errorClass;
            ErrorCode = errorCode;
        }

        public BACnetError(BACnetServiceException e)
        {
            ErrorClass = e.ErrorClass;
            ErrorCode = e.ErrorCode;
        }

        public override void write(ByteStream queue)
        {
            write(queue, ErrorClass);
            write(queue, ErrorCode);
        }

        public BACnetError(ByteStream queue)
        {
            ErrorClass = new ErrorClass(queue);
            ErrorCode = new ErrorCode(queue);
        }

        public bool equals(ErrorClass errorClass, ErrorCode errorCode)
        {
            return ErrorClass.Equals(errorClass) && ErrorCode.Equals(errorCode);
        }

        public override string ToString() => "errorClass=" + ErrorClass + ", errorCode=" + ErrorCode;
    }
}

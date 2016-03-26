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
            this.ErrorClass = errorClass;
            this.ErrorCode = errorCode;
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

        public BACnetError(ByteStream queue) // throws BACnetException
        {
            ErrorClass = new ErrorClass(queue);
            ErrorCode = new ErrorCode(queue);
        }

        public bool equals(ErrorClass errorClass, ErrorCode errorCode)
        {
            return this.ErrorClass.Equals(errorClass) && this.ErrorCode.Equals(errorCode);
        }

        public override string ToString()
        {
            return "errorClass=" + ErrorClass + ", errorCode=" + ErrorCode;
        }
    }
}

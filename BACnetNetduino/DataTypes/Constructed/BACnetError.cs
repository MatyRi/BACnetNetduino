using System;
using BACnetNetduino.DataTypes.Enumerated;
using BACnetNetduino.Exception;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Constructed
{
    class BACnetError : BaseType
    {
        private readonly ErrorClass errorClass;
        private readonly ErrorCode errorCode;

        public BACnetError(ErrorClass errorClass, ErrorCode errorCode)
        {
            this.errorClass = errorClass;
            this.errorCode = errorCode;
        }

        public BACnetError(BACnetServiceException e)
        {
            this.errorClass = e.ErrorClass;
            this.errorCode = e.ErrorCode;
        }

        public override void write(ByteStream queue)
        {
            write(queue, errorClass);
            write(queue, errorCode);
        }

        public BACnetError(ByteStream queue) // throws BACnetException
        {
            errorClass = new ErrorClass(queue);
            errorCode = new ErrorCode(queue);
        }

        public ErrorClass ErrorClass => errorClass;

        public ErrorCode ErrorCode => errorCode;

        public bool equals(ErrorClass errorClass, ErrorCode errorCode)
        {
            return this.errorClass.Equals(errorClass) && this.errorCode.Equals(errorCode);
        }

        public override string ToString()
        {
            return "errorClass=" + errorClass + ", errorCode=" + errorCode;
        }
    }
}

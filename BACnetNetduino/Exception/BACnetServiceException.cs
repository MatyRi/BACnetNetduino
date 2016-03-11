using System;
using BACnetNetduino.DataTypes.Enumerated;
using Microsoft.SPOT;

namespace BACnetNetduino.Exception
{
    class BACnetServiceException : System.Exception
    {
        private readonly ErrorClass errorClass;
        private readonly ErrorCode errorCode;

        public BACnetServiceException(ErrorClass errorClass, ErrorCode errorCode)
        {
            this.errorClass = errorClass;
            this.errorCode = errorCode;
        }

        public BACnetServiceException(ErrorClass errorClass, ErrorCode errorCode, string message) : base(message)
        {
            this.errorClass = errorClass;
            this.errorCode = errorCode;
        }

        public ErrorClass getErrorClass()
        {
            return errorClass;
        }

        public ErrorCode getErrorCode()
        {
            return errorCode;
        }

        public bool equals(ErrorClass errorClass, ErrorCode errorCode)
        {
            return this.errorClass.Equals(errorClass) && this.errorCode.Equals(errorCode);
        }

        public override string Message
        {
            get
            {
                string message = "class=" + errorClass + ", code=" + errorCode;
                string userDesc = base.Message;
                if (userDesc != null)
                    message += ", message=" + userDesc;
                return message;
            }
        }
    }
}

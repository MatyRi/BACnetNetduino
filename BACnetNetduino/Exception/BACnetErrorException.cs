using System;
using System.Text;
using BACnetNetduino.DataTypes.Constructed;
using BACnetNetduino.DataTypes.Enumerated;
using BACnetNetduino.DataTypes.Error;
using Microsoft.SPOT;

namespace BACnetNetduino.Exception
{
    class BACnetErrorException : BACnetException
    {
        private readonly BaseError error;

        public BACnetErrorException(byte choice, ErrorClass errorClass, ErrorCode errorCode) : base(getBaseMessage(errorClass, errorCode, null))
        {
            error = new BaseError(choice, new BACnetError(errorClass, errorCode));
        }

        public BACnetErrorException(byte choice, BACnetServiceException e) : base(e)
        {
            error = new BaseError(choice, new BACnetError(e.ErrorClass, e.ErrorCode));
        }

        public BACnetErrorException(ErrorClass errorClass, ErrorCode errorCode) : base(getBaseMessage(errorClass, errorCode, null))
        {
            error = new BaseError((byte)127, new BACnetError(errorClass, errorCode));
        }

        public BACnetErrorException(BACnetServiceException e) : base(e.Message)
        {
            error = new BaseError((byte)127, new BACnetError(e.ErrorClass, e.ErrorCode));
        }

        public BACnetErrorException(ErrorClass errorClass, ErrorCode errorCode, string message) : base (getBaseMessage(errorClass, errorCode, message))
        {
            error = new BaseError((byte)127, new BACnetError(errorClass, errorCode));
        }

        public BACnetErrorException(BaseError error)
        {
            this.error = error;
        }

        public BaseError getError()
        {
            return error;
        }

        private static string getBaseMessage(ErrorClass errorClass, ErrorCode errorCode, string message)
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

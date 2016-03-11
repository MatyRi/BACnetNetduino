using System;
using BACnetNetduino.DataTypes.Error;
using Microsoft.SPOT;

namespace BACnetNetduino.APDU
{
    class Error : AckAPDU
    {
        public static readonly byte TYPE_ID = 5;

        /**
         * This parameter, of type BACnet-Error, indicates the reason the indicated service request could not be carried
         * out. This parameter shall be encoded according to the rules of 20.2.
         */
        private readonly BaseError error;

        public Error(byte originalInvokeId, BaseError error)
        {
            this.originalInvokeId = originalInvokeId;
            this.error = error;
        }

        public override byte getPduType()
        {
            return TYPE_ID;
        }

        public override void write(ByteStream queue)
        {
            queue.push(getShiftedTypeId(TYPE_ID));
            queue.push(originalInvokeId);
            error.write(queue);
        }

        Error(ByteStream queue) // throws BACnetException
        {
            queue.pop(); // Ignore the first byte. No news there.
            originalInvokeId = queue.pop();
            error = BaseError.createBaseError(queue);
        }

        public override string ToString()
        {
            return "ErrorAPDU(" + error + ")";
        }

        public BaseError getError()
        {
            return error;
        }

        public override bool expectsReply()
        {
            return false;
        }
    }
}

using System;
using BACnetNetduino.DataTypes.Enumerated;
using Microsoft.SPOT;

namespace BACnetNetduino.APDU
{
    class Reject : AckAPDU
    {
        public static readonly byte TYPE_ID = 6;

        /**
         * This parameter, of type BACnetRejectReason, contains the reason the PDU with the indicated 'invokeID' is being
         * rejected.
         */
        private readonly RejectReason rejectReason;

    public Reject(byte originalInvokeId, RejectReason rejectReason)
        {
            this.originalInvokeId = originalInvokeId;
            this.rejectReason = rejectReason;
        }

        override
    public byte getPduType()
        {
            return TYPE_ID;
        }

        
    /*public override void write(ByteStream queue)
        {
            queue.push(getShiftedTypeId(TYPE_ID));
            queue.push(originalInvokeId);
            queue.push(rejectReason.byteValue());
        }*/

        Reject(ByteStream queue)
        {
            queue.pop(); // Ignore the first byte. No news there.
            originalInvokeId = queue.pop();
            rejectReason = new RejectReason(queue.popU1B());
        }


    public override string ToString()
        {
            return "Reject(originalInvokeId=" + originalInvokeId + ", rejectReason=" + rejectReason + ")";
        }

        override
    public bool expectsReply()
        {
            return false;
        }
    }
}

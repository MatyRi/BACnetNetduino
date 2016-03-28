using BACnetDataTypes;
using BACnetDataTypes.Enumerated;

namespace BACnetServices.APDU
{
    public class Reject : AckAPDU
    {
        public static readonly byte TYPE_ID = 6;

        /**
         * This parameter, of type BACnetRejectReason, contains the reason the PDU with the indicated 'invokeID' is being
         * rejected.
         */
        private readonly RejectReason rejectReason;

        public Reject(byte originalInvokeId, RejectReason rejectReason)
        {
            this.OriginalInvokeId = originalInvokeId;
            this.rejectReason = rejectReason;
        }


        public override byte PduType => TYPE_ID;


        public override void write(ByteStream queue)
            {
                queue.WriteByte(GetShiftedTypeId(TYPE_ID));
                queue.WriteByte(OriginalInvokeId);
                queue.WriteByte((byte) rejectReason.Value);
            }

        internal Reject(ByteStream queue)
        {
            queue.ReadByte(); // Ignore the first byte. No news there.
            OriginalInvokeId = queue.ReadByte();
            rejectReason = new RejectReason(queue.popU1B());
        }


        public override string ToString() => "Reject(originalInvokeId=" + OriginalInvokeId + ", rejectReason=" + rejectReason + ")";


        public override bool expectsReply { get; protected set; } = false;
    }
}

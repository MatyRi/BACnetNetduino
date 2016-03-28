using BACnetDataTypes;
using BACnetDataTypes.Error;

namespace BACnetServices.APDU
{
    public class Error : AckAPDU
    {
        public static readonly byte TYPE_ID = 5;

        /**
         * This parameter, of type BACnet-Error, indicates the reason the indicated service request could not be carried
         * out. This parameter shall be encoded according to the rules of 20.2.
         */

        public Error(byte originalInvokeId, BaseError error)
        {
            this.OriginalInvokeId = originalInvokeId;
            this.ErrorValue = error;
        }

        public override byte PduType => TYPE_ID;

        public override void write(ByteStream queue)
        {
            queue.WriteByte(GetShiftedTypeId(TYPE_ID));
            queue.WriteByte(OriginalInvokeId);
            ErrorValue.write(queue);
        }

        internal Error(ByteStream queue)
        {
            queue.ReadByte(); // Ignore the first byte. No news there.
            OriginalInvokeId = queue.ReadByte();
            ErrorValue = BaseError.createBaseError(queue);
        }

        public override string ToString() => "ErrorAPDU(" + ErrorValue + ")";

        public BaseError ErrorValue { get; }

        public override bool expectsReply { get; protected set; } = false;
    }
}

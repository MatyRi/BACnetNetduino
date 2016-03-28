using BACnetDataTypes;

namespace BACnetServices.APDU
{
    class SimpleACK : AckAPDU
    {
        public static readonly byte TYPE_ID = 2;

        /**
         * This parameter shall contain the value of the BACnetConfirmedServiceChoice corresponding to the service contained
         * in the previous BACnet-Confirmed-Service-Request that has resulted in this acknowledgment.
         */
        private readonly int serviceAckChoice;

        public SimpleACK(byte originalInvokeId, int serviceAckChoice)
        {
            this.OriginalInvokeId = originalInvokeId;
            this.serviceAckChoice = serviceAckChoice;
        }

        public override byte PduType => TYPE_ID;

        public override void write(ByteStream queue)
        {
            queue.WriteByte(GetShiftedTypeId(TYPE_ID));
            queue.WriteByte(OriginalInvokeId);
            queue.WriteByte((byte) serviceAckChoice);
        }

        public SimpleACK(ByteStream queue)
        {
            queue.ReadByte(); // no news here
            OriginalInvokeId = queue.ReadByte();
            serviceAckChoice = queue.popU1B();
        }

        public override bool expectsReply { get; protected set; } = false;
    }
}

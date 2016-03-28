using BACnetDataTypes;

namespace BACnetServices.APDU
{
    class Abort : AckAPDU
    {
        public static readonly byte TYPE_ID = 7;

        /**
         * This parameter shall be TRUE when the Abort PDU is sent by a server. This parameter shall be FALSE when the Abort
         * PDU is sent by a client.
         */
        private readonly bool server;

        /**
         * This parameter, of type BACnetAbortReason, contains the reason the transaction with the indicated invoke ID is
         * being aborted.
         */

        public Abort(bool server, byte originalInvokeId, int abortReason)
        {
            this.server = server;
            this.OriginalInvokeId = originalInvokeId;
            this.AbortReason = abortReason;
        }


        public override byte PduType => TYPE_ID;

        public override bool IsServer => server;

        public int AbortReason { get; }


        public override void write(ByteStream queue)
        {
            int data = GetShiftedTypeId(TYPE_ID) | (server ? 1 : 0);
            queue.WriteByte((byte) data);
            queue.WriteByte(OriginalInvokeId);
            queue.WriteByte((byte) AbortReason);
        }

        internal Abort(ByteStream queue)
        {
            server = (queue.popU1B() & 1) == 1;
            OriginalInvokeId = queue.ReadByte();
            AbortReason = queue.popU1B();
        }


        public override string ToString()
            => "Abort(server=" + server + ", originalInvokeId=" + OriginalInvokeId + ", abortReason=;";


        public override bool expectsReply { get; protected set; } = false;
    }
}

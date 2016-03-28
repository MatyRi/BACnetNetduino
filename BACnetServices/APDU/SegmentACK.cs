using BACnetDataTypes;

namespace BACnetServices.APDU
{
    class SegmentACK : AckAPDU
    {
        public static readonly byte TYPE_ID = 4;

        /**
         * This parameter shall be TRUE if the Segment-ACK PDU is being sent to indicate a segment received out of order.
         * Otherwise, it shall be FALSE.
         */

        /**
         * This parameter shall be TRUE when the SegmentACK PDU is sent by a server, that is, when the SegmentACK PDU is in
         * acknowledgment of a segment or segments of a Confirmed-Request PDU.
         * 
         * This parameter shall be FALSE when the SegmentACK PDU is sent by a client, that is, when the SegmentACK PDU is in
         * acknowledgment of a segment or segments of a ComplexACK PDU.
         */

        /**
         * This parameter shall contain the 'sequence-number' of a previously received message segment. It is used to
         * acknowledge the receipt of that message segment and all earlier segments of the message.
         * 
         * If the 'more-follows' parameter of the received message segment is TRUE, then the 'sequence-number' also requests
         * continuation of the segmented message beginning with the segment whose 'sequence-number' is one plus the value of
         * this parameter, modulo 256.
         */

        /**
         * This parameter shall specify as an unsigned binary integer the number of message segments containing
         * 'original-invokeID' the sender will accept before sending another SegmentACK. See 5.3 for additional details. The
         * value of the 'actual-windowsize' shall be in the range 1 - 127.
         */

        public SegmentACK(bool negativeAck, bool server, byte originalInvokeId, int sequenceNumber,
                int actualWindowSize, bool expectsResponse)
        {
            this.IsNegativeAck = negativeAck;
            this.IsServer = server;
            this.OriginalInvokeId = originalInvokeId;
            this.SequenceNumber = sequenceNumber;
            this.ActualWindowSize = actualWindowSize;
            this.expectsReply = expectsResponse;
        }

        public override byte PduType => TYPE_ID;

        public int ActualWindowSize { get; }

        public bool IsNegativeAck { get; }

        public int SequenceNumber { get; }

        public override bool IsServer { get; }

        public override void write(ByteStream queue)
        {
            queue.WriteByte((byte) (GetShiftedTypeId(TYPE_ID) | (IsNegativeAck ? 2 : 0) | (IsServer ? 1 : 0)));
            queue.WriteByte(OriginalInvokeId);
            queue.WriteByte((byte) SequenceNumber);
            queue.WriteByte((byte) ActualWindowSize);
        }

        public SegmentACK(ByteStream queue)
        {
            byte b = queue.ReadByte();
            IsNegativeAck = (b & 2) != 0;
            IsServer = (b & 1) != 0;

            OriginalInvokeId = queue.ReadByte();
            SequenceNumber = queue.popU1B();
            ActualWindowSize = queue.popU1B();
        }

        public override string ToString() => "SegmentACK(negativeAck=" + IsNegativeAck + ", server=" + IsServer + ", originalInvokeId="
                                             + OriginalInvokeId + ", sequenceNumber=" + SequenceNumber + ", actualWindowSize=" + ActualWindowSize
                                             + ")";

        public override bool expectsReply { get; protected set; }
    }
}

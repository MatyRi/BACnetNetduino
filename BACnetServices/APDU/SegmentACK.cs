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
        private readonly bool negativeAck;

        /**
         * This parameter shall be TRUE when the SegmentACK PDU is sent by a server, that is, when the SegmentACK PDU is in
         * acknowledgment of a segment or segments of a Confirmed-Request PDU.
         * 
         * This parameter shall be FALSE when the SegmentACK PDU is sent by a client, that is, when the SegmentACK PDU is in
         * acknowledgment of a segment or segments of a ComplexACK PDU.
         */
        private readonly bool server;

        /**
         * This parameter shall contain the 'sequence-number' of a previously received message segment. It is used to
         * acknowledge the receipt of that message segment and all earlier segments of the message.
         * 
         * If the 'more-follows' parameter of the received message segment is TRUE, then the 'sequence-number' also requests
         * continuation of the segmented message beginning with the segment whose 'sequence-number' is one plus the value of
         * this parameter, modulo 256.
         */
        private readonly int sequenceNumber;

        /**
         * This parameter shall specify as an unsigned binary integer the number of message segments containing
         * 'original-invokeID' the sender will accept before sending another SegmentACK. See 5.3 for additional details. The
         * value of the 'actual-windowsize' shall be in the range 1 - 127.
         */
        private readonly int actualWindowSize;

        private bool expectsResponse;

        public SegmentACK(bool negativeAck, bool server, byte originalInvokeId, int sequenceNumber,
                int actualWindowSize, bool expectsResponse)
        {
            this.negativeAck = negativeAck;
            this.server = server;
            this.originalInvokeId = originalInvokeId;
            this.sequenceNumber = sequenceNumber;
            this.actualWindowSize = actualWindowSize;
            this.expectsResponse = expectsResponse;
        }

        public override byte getPduType()
        {
            return TYPE_ID;
        }

        public int getActualWindowSize()
        {
            return actualWindowSize;
        }

        public bool isNegativeAck()
        {
            return negativeAck;
        }

        public int getSequenceNumber()
        {
            return sequenceNumber;
        }

        public override bool isServer()
        {
            return server;
        }

        /*public override void write(ByteStream queue)
        {
            queue.push(getShiftedTypeId(TYPE_ID) | (negativeAck ? 2 : 0) | (server ? 1 : 0));
            queue.push(originalInvokeId);
            queue.push(sequenceNumber);
            queue.push(actualWindowSize);
        }*/

        public SegmentACK(ByteStream queue)
        {
            byte b = queue.ReadByte();
            negativeAck = (b & 2) != 0;
            server = (b & 1) != 0;

            originalInvokeId = queue.ReadByte();
            sequenceNumber = queue.popU1B();
            actualWindowSize = queue.popU1B();
        }

        public override string ToString()
        {
            return "SegmentACK(negativeAck=" + negativeAck + ", server=" + server + ", originalInvokeId="
                    + originalInvokeId + ", sequenceNumber=" + sequenceNumber + ", actualWindowSize=" + actualWindowSize
                    + ")";
        }

        public override bool expectsReply()
        {
            return expectsResponse;
        }
    }
}

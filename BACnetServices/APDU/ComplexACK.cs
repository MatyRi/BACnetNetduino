using BACnetDataTypes;
using BACnetServices.Service.Acknowledgement;

namespace BACnetServices.APDU
{
    class ComplexACK : AckAPDU
    {
        public static readonly byte TYPE_ID = 3;

        public static int GetHeaderSize(bool segmented)
        {
            if (segmented)
                return 5;
            return 3;
        }

        /**
         * This parameter indicates whether or not the confirmed service response is entirely, or only partially, contained
         * in the present PDU. If the response is present in its entirety, the 'segmented-message' parameter shall be FALSE.
         * If the present PDU contains only a segment of the response, this parameter shall be TRUE.
         */

        /**
         * This parameter is only meaningful if the 'segmented-message' parameter is TRUE. If 'segmented-message' is TRUE,
         * then the 'more-follows' parameter shall be TRUE for all segments comprising the confirmed service response except
         * for the last and shall be FALSE for the readonly segment. If 'segmented-message' is FALSE, then 'more-follows' shall
         * be set FALSE by the encoder and shall be ignored by the decoder.
         */

        /**
         * This optional parameter is only present if the 'segmented-message' parameter is TRUE. In this case, the
         * 'sequence-number' shall be a sequentially incremented unsigned integer, modulo 256, which identifies each segment
         * of a segmented response. The value of the received 'sequence-number' is used by the original requester to
         * acknowledge the receipt of one or more segments of a segmented response. The sequence-number of the first segment
         * of a segmented response shall be zero.
         */

        /**
         * This optional parameter is only present if the 'segmented-message' parameter is TRUE. In this case, the
         * 'proposed-window-size' parameter shall specify as an unsigned binary integer the maximum number of message
         * segments containing 'original-invokeID' the sender is able or willing to send before waiting for a segment
         * acknowledgment PDU (see 5.2 and 5.3). The value of the 'proposed-window-size' shall be in the range 1 - 127.
         */

        /**
         * This parameter shall contain the value of the BACnetConfirmedServiceChoice corresponding to the service contained
         * in the previous BACnet-Confirmed-Service-Request that has resulted in this acknowledgment. See Clause 21.
         * 
         * This parameter shall contain the parameters of the specific service acknowledgment that is being encoded
         * according to the rules of 20.2. These parameters are defined in the individual service descriptions in this
         * standard and are represented in Clause 21 in accordance with the rules of ASN.1.
         */

        /**
         * This field is used to allow parsing of only the APDU so that those fields are available in case there is a
         * problem parsing the service request.
         */
        private ByteStream serviceData;

        private byte serviceChoice;

        public ComplexACK(bool segmentedMessage, bool moreFollows, byte originalInvokeId, int sequenceNumber,
                int proposedWindowSize, AcknowledgementService service)
        {

            setFields(segmentedMessage, moreFollows, originalInvokeId, sequenceNumber, proposedWindowSize,
                    service.ChoiceId);

            this.Service = service;
        }

        public ComplexACK(bool segmentedMessage, bool moreFollows, byte originalInvokeId, int sequenceNumber,
                int proposedWindowSize, byte serviceChoice, ByteStream serviceData)
        {

            setFields(segmentedMessage, moreFollows, originalInvokeId, sequenceNumber, proposedWindowSize, serviceChoice);

            this.serviceData = serviceData;
        }

        private void setFields(bool segmentedMessage, bool moreFollows, byte originalInvokeId, int sequenceNumber,
                int proposedWindowSize, byte serviceChoice)
        {
            this.expectsReply = segmentedMessage;
            this.IsMoreFollows = moreFollows;
            this.OriginalInvokeId = originalInvokeId;
            this.SequenceNumber = sequenceNumber;
            this.ProposedWindowSize = proposedWindowSize;
            this.serviceChoice = serviceChoice;
        }


        public override byte PduType => TYPE_ID;

        public bool IsMoreFollows { get; private set; }

        public int ProposedWindowSize { get; private set; }

        public bool IsSegmentedMessage => expectsReply;

        public int SequenceNumber { get; private set; }

        public AcknowledgementService Service { get; private set; }

        public void AppendServiceData(ByteStream data) => serviceData.Write(data);

        public ByteStream ServiceData => serviceData;

        public byte InvokeId => OriginalInvokeId;

        public override string ToString()
        {
            return "ComplexACK(segmentedMessage=" + expectsReply + ", moreFollows=" + IsMoreFollows
                    + ", originalInvokeId=" + OriginalInvokeId + ", sequenceNumber=" + SequenceNumber
                    + ", proposedWindowSize=" + ProposedWindowSize + ", serviceChoice=" + serviceChoice + ", service="
                    + Service + ")";
        }

        public override void write(ByteStream queue)
        {
            queue.WriteByte((byte) (GetShiftedTypeId(TYPE_ID) | (expectsReply ? 8 : 0) | (IsMoreFollows ? 4 : 0)));
            queue.WriteByte(OriginalInvokeId);
            if (expectsReply)
            {
                queue.WriteByte((byte) SequenceNumber);
                queue.WriteByte((byte) ProposedWindowSize);
            }
            queue.WriteByte(serviceChoice);
            if (Service != null)
                Service.write(queue);
            else
                queue.Write(serviceData);
        }

        internal ComplexACK(ByteStream queue)
        {
            byte b = queue.ReadByte();
            expectsReply = (b & 8) != 0;
            IsMoreFollows = (b & 4) != 0;

            OriginalInvokeId = queue.ReadByte();
            if (expectsReply)
            {
                SequenceNumber = queue.popU1B();
                ProposedWindowSize = queue.popU1B();
            }
            serviceChoice = queue.ReadByte();
            serviceData = new ByteStream(queue.ReadToEnd());
        }

        public void parseServiceData()
        {
        if (serviceData != null) {
                Service = AcknowledgementService.createAcknowledgementService(serviceChoice, serviceData);
                serviceData = null;
            }
        }

        public APDU clone(bool moreFollows, int sequenceNumber, int actualSegWindow, ByteStream serviceData)
        {
            return new ComplexACK(expectsReply, moreFollows, OriginalInvokeId, sequenceNumber,
                    actualSegWindow, serviceChoice, serviceData);
        }


        public override bool expectsReply { get; protected set; }
    }
}

using BACnetDataTypes;
using BACnetServices.Service.Acknowledgement;

namespace BACnetServices.APDU
{
    class ComplexACK : AckAPDU
    {
        public static readonly byte TYPE_ID = 3;

        public static int getHeaderSize(bool segmented)
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
        private bool segmentedMessage;

        /**
         * This parameter is only meaningful if the 'segmented-message' parameter is TRUE. If 'segmented-message' is TRUE,
         * then the 'more-follows' parameter shall be TRUE for all segments comprising the confirmed service response except
         * for the last and shall be FALSE for the readonly segment. If 'segmented-message' is FALSE, then 'more-follows' shall
         * be set FALSE by the encoder and shall be ignored by the decoder.
         */
        private bool moreFollows;

        /**
         * This optional parameter is only present if the 'segmented-message' parameter is TRUE. In this case, the
         * 'sequence-number' shall be a sequentially incremented unsigned integer, modulo 256, which identifies each segment
         * of a segmented response. The value of the received 'sequence-number' is used by the original requester to
         * acknowledge the receipt of one or more segments of a segmented response. The sequence-number of the first segment
         * of a segmented response shall be zero.
         */
        private int sequenceNumber;

        /**
         * This optional parameter is only present if the 'segmented-message' parameter is TRUE. In this case, the
         * 'proposed-window-size' parameter shall specify as an unsigned binary integer the maximum number of message
         * segments containing 'original-invokeID' the sender is able or willing to send before waiting for a segment
         * acknowledgment PDU (see 5.2 and 5.3). The value of the 'proposed-window-size' shall be in the range 1 - 127.
         */
        private int proposedWindowSize;

        /**
         * This parameter shall contain the value of the BACnetConfirmedServiceChoice corresponding to the service contained
         * in the previous BACnet-Confirmed-Service-Request that has resulted in this acknowledgment. See Clause 21.
         * 
         * This parameter shall contain the parameters of the specific service acknowledgment that is being encoded
         * according to the rules of 20.2. These parameters are defined in the individual service descriptions in this
         * standard and are represented in Clause 21 in accordance with the rules of ASN.1.
         */
        private AcknowledgementService service;

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

            this.service = service;
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
            this.segmentedMessage = segmentedMessage;
            this.moreFollows = moreFollows;
            this.originalInvokeId = originalInvokeId;
            this.sequenceNumber = sequenceNumber;
            this.proposedWindowSize = proposedWindowSize;
            this.serviceChoice = serviceChoice;
        }

        
        public override byte getPduType()
        {
            return TYPE_ID;
        }

        public bool isMoreFollows()
        {
            return moreFollows;
        }

        public int getProposedWindowSize()
        {
            return proposedWindowSize;
        }

        public bool isSegmentedMessage()
        {
            return segmentedMessage;
        }

        public int getSequenceNumber()
        {
            return sequenceNumber;
        }

        /*public AcknowledgementService getService()
        {
            return service;
        }*/

        /*public void appendServiceData(ByteStream data)
        {
            this.serviceData.push(data);
        }*/

        public ByteStream getServiceData()
        {
            return serviceData;
        }

        public byte getInvokeId()
        {
            return originalInvokeId;
        }

        
        public override string ToString()
        {
            return "ComplexACK(segmentedMessage=" + segmentedMessage + ", moreFollows=" + moreFollows
                    + ", originalInvokeId=" + originalInvokeId + ", sequenceNumber=" + sequenceNumber
                    + ", proposedWindowSize=" + proposedWindowSize + ", serviceChoice=" + serviceChoice + ", service="
                    + service + ")";
        }

        
    /*public override void write(ByteStream queue)
        {
            queue.push(getShiftedTypeId(TYPE_ID) | (segmentedMessage ? 8 : 0) | (moreFollows ? 4 : 0));
            queue.push(originalInvokeId);
            if (segmentedMessage)
            {
                queue.push(sequenceNumber);
                queue.push(proposedWindowSize);
            }
            queue.push(serviceChoice);
            if (service != null)
                service.write(queue);
            else
                queue.push(serviceData);
        }*/

        internal ComplexACK(ByteStream queue)
        {
            byte b = queue.ReadByte();
            segmentedMessage = (b & 8) != 0;
            moreFollows = (b & 4) != 0;

            originalInvokeId = queue.ReadByte();
            if (segmentedMessage)
            {
                sequenceNumber = queue.popU1B();
                proposedWindowSize = queue.popU1B();
            }
            serviceChoice = queue.ReadByte();
            serviceData = new ByteStream(queue.ReadToEnd());
        }

        public void parseServiceData()
        {
        if (serviceData != null) {
                service = AcknowledgementService.createAcknowledgementService(serviceChoice, serviceData);
                serviceData = null;
            }
        }

        public APDU clone(bool moreFollows, int sequenceNumber, int actualSegWindow, ByteStream serviceData)
        {
            return new ComplexACK(segmentedMessage, moreFollows, originalInvokeId, sequenceNumber,
                    actualSegWindow, serviceChoice, serviceData);
        }

        
        public override bool expectsReply()
        {
            return segmentedMessage;
        }
    }
}

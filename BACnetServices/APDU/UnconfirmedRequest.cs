using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetServices.Service.Unconfirmed;

namespace BACnetServices.APDU
{
    public class UnconfirmedRequest : APDU
    {
        public static readonly byte TYPE_ID = 1;

        /**
         * This parameter shall contain the parameters of the specific service that is being requested, encoded according to
         * the rules of 20.2. These parameters are defined in the individual service descriptions in this standard and are
         * represented in Clause 21 in accordance with the rules of ASN.1.
         */
        private readonly UnconfirmedRequestService service;

        public UnconfirmedRequest(UnconfirmedRequestService service)
        {
            this.service = service;
        }

        public override byte getPduType()
        {
            return TYPE_ID;
        }

        public UnconfirmedRequestService getService()
        {
            return service;
        }

        public override void write(ByteStream queue)
        {
            queue.WriteByte(getShiftedTypeId(TYPE_ID));
            queue.WriteByte(service.getChoiceId());
            service.write(queue);
        }

        public UnconfirmedRequest(ServicesSupported services, ByteStream queue)
        {
            queue.ReadByte();
            byte choiceId = queue.ReadByte();
            service = UnconfirmedRequestService.createUnconfirmedRequestService(services, choiceId, queue);
            //if (service == null) { throw new BACnetErrorException(ErrorClass.device, ErrorCode.serviceRequestDenied); }
        }

        public override bool expectsReply()
        {
            return false;
        }
}
}

using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;
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

        public UnconfirmedRequest(UnconfirmedRequestService service)
        {
            Service = service;
        }

        public override byte PduType => TYPE_ID;

        public UnconfirmedRequestService Service { get; }

        public override void write(ByteStream queue)
        {
            queue.WriteByte(GetShiftedTypeId(TYPE_ID));
            queue.WriteByte(Service.ChoiceId);
            Service.write(queue);
        }

        public UnconfirmedRequest(ServicesSupported services, ByteStream queue)
        {
            queue.ReadByte();
            byte choiceId = queue.ReadByte();
            Service = UnconfirmedRequestService.createUnconfirmedRequestService(services, choiceId, queue);
            if (Service == null) { throw new BACnetErrorException(ErrorClass.Device, ErrorCode.ServiceRequestDenied); }
        }

        public override bool expectsReply { get; protected set; } = false;
    }
}

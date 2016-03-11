using System;
using BACnetNetduino.Service.Unconfirmed;
using Microsoft.SPOT;

namespace BACnetNetduino.APDU
{
    class UnconfirmedRequest : APDU
    {
        public static readonly byte TYPE_ID = 1;

        private readonly UnconfirmedRequestService service;

        private UnconfirmedRequest(UnconfirmedRequestService parsedService)
        {
            service = parsedService;
        }

        internal static UnconfirmedRequest Parse(ByteStream source)
        {
            source.ReadByte();
            byte choiceId = source.ReadByte();

            return new UnconfirmedRequest(UnconfirmedRequestService.createUnconfirmedRequestService(choiceId, source));
            //if (service == null) { throw new BACnetErrorException(ErrorClass.device, ErrorCode.serviceRequestDenied); }
        }
    }
}

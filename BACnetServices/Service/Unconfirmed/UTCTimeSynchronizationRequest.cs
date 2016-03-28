using System;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;
using DateTime = BACnetDataTypes.Constructed.DateTime;

namespace BACnetServices.Service.Unconfirmed
{
    class UTCTimeSynchronizationRequest : UnconfirmedRequestService
    {
        public static readonly byte TYPE_ID = 9;

        private readonly DateTime time;

    public UTCTimeSynchronizationRequest(DateTime time)
        {
            this.time = time;
        }


        public override byte ChoiceId => TYPE_ID;

        
    public override void write(ByteStream queue)
        {
            write(queue, time);
        }

        internal UTCTimeSynchronizationRequest(ByteStream queue)
        {
            time = (DateTime)read(queue, typeof(DateTime));
    }

    
    public override void handle(LocalDevice localDevice, Address from, OctetString linkService)
    {
        try
        {
            ServicesSupported servicesSupported = (ServicesSupported)localDevice.Configuration.getProperty(
                    PropertyIdentifier.ProtocolServicesSupported);
            if (servicesSupported.isUtcTimeSynchronization())
                    throw new NotImplementedException();
                    //localDevice.getEventHandler().synchronizeTime(time, true);
        }
        catch (BACnetServiceException e)
        {
            // no op
        }
    }
}
}

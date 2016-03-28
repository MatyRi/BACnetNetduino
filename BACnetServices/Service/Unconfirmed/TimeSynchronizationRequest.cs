using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;
using BACnetDataTypes.Primitive;

namespace BACnetServices.Service.Unconfirmed
{
    class TimeSynchronizationRequest : UnconfirmedRequestService
    {
        public static readonly byte TYPE_ID = 6;

        private readonly DateTime time;

        public TimeSynchronizationRequest(DateTime time)
        {
            this.time = time;
        }


        public override byte ChoiceId => TYPE_ID;


        public override void write(ByteStream queue)
        {
            write(queue, time);
        }

        internal TimeSynchronizationRequest(ByteStream queue)
        {
            time = (DateTime) read(queue, typeof (DateTime));
        }

        public override void handle(LocalDevice localDevice, Address from, OctetString linkService)
        {
            try
            {
                ServicesSupported servicesSupported =
                    (ServicesSupported)
                        localDevice.Configuration.getProperty(PropertyIdentifier.ProtocolServicesSupported);
                if (servicesSupported.isTimeSynchronization())
                    // TODO localDevice.getEventHandler().synchronizeTime(time, false);
                    int i = 5;
            }
            catch (BACnetServiceException e)
            {
                // no op
            }
        }
    }
}

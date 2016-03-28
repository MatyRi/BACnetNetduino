using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;
using BACnetServices.Objects;

namespace BACnetServices.Service.Unconfirmed
{
    class WhoIsRequest : UnconfirmedRequestService
    {
        public static readonly byte TYPE_ID = 8;

        public UnsignedInteger DeviceInstanceRangeLowLimit { get; }
        public UnsignedInteger DeviceInstanceRangeHighLimit { get; }

        public WhoIsRequest()
        {
            // no op
        }

        public WhoIsRequest(UnsignedInteger deviceInstanceRangeLowLimit, UnsignedInteger deviceInstanceRangeHighLimit)
        {
            DeviceInstanceRangeLowLimit = deviceInstanceRangeLowLimit;
            DeviceInstanceRangeHighLimit = deviceInstanceRangeHighLimit;
        }

        public override byte ChoiceId => TYPE_ID;

        public override void handle(LocalDevice localDevice, Address from, OctetString linkService)
        {
            BACnetObject local = localDevice.Configuration;

        // Check if we're in the device id range.
        if (DeviceInstanceRangeLowLimit != null && local.InstanceId< DeviceInstanceRangeLowLimit.Value)
            return;

        if (DeviceInstanceRangeHighLimit != null && local.InstanceId> DeviceInstanceRangeHighLimit.Value)
            return;

            // Return the result in a i am message.
            //DCC - AdK
            //if(!localDevice.getDCCEnableDisable().equals(EnableDisable.disable)) {
            IAmRequest iam = localDevice.MakeIAmRequest();
            localDevice.sendGlobalBroadcast(iam, true);
            //}
        }


        public override void write(ByteStream queue)
        {
            writeOptional(queue, DeviceInstanceRangeLowLimit, 0);
            writeOptional(queue, DeviceInstanceRangeHighLimit, 1);
        }

        internal WhoIsRequest(ByteStream queue)
        {
            DeviceInstanceRangeLowLimit = (UnsignedInteger) readOptional(queue, typeof(UnsignedInteger), 0);
            DeviceInstanceRangeHighLimit = (UnsignedInteger) readOptional(queue, typeof(UnsignedInteger), 1);
        }
    }
}

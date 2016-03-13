using System;
using BACnetNetduino.DataTypes.Constructed;
using BACnetNetduino.DataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetNetduino.Service.Unconfirmed
{
    class WhoIsRequest : UnconfirmedRequestService
    {
        public static readonly byte TYPE_ID = 8;

        private UnsignedInteger deviceInstanceRangeLowLimit;
        private UnsignedInteger deviceInstanceRangeHighLimit;

        public WhoIsRequest()
        {
            // no op
        }

        public WhoIsRequest(UnsignedInteger deviceInstanceRangeLowLimit, UnsignedInteger deviceInstanceRangeHighLimit)
        {
            this.deviceInstanceRangeLowLimit = deviceInstanceRangeLowLimit;
            this.deviceInstanceRangeHighLimit = deviceInstanceRangeHighLimit;
        }

        
        public override byte getChoiceId()
        {
            return TYPE_ID;
        }

        /*public override void handle(LocalDevice localDevice, Address from, OctetString linkService)
        {
            BACnetObject local = localDevice.getConfiguration();

        // Check if we're in the device id range.
        if (deviceInstanceRangeLowLimit != null && local.getInstanceId() < deviceInstanceRangeLowLimit.intValue())
            return;

        if (deviceInstanceRangeHighLimit != null && local.getInstanceId() > deviceInstanceRangeHighLimit.intValue())
            return;

            // Return the result in a i am message.
            //DCC - AdK
            //if(!localDevice.getDCCEnableDisable().equals(EnableDisable.disable)) {
            IAmRequest iam = localDevice.getIAm();
            localDevice.sendGlobalBroadcast(iam, true);
            //}
        }*/

        /*public override void write(ByteStream queue)
        {
            writeOptional(queue, deviceInstanceRangeLowLimit, 0);
            writeOptional(queue, deviceInstanceRangeHighLimit, 1);
        }*/

        internal WhoIsRequest(ByteStream queue)
        {
            deviceInstanceRangeLowLimit = new UnsignedInteger(queue);
            deviceInstanceRangeHighLimit = new UnsignedInteger(queue);
            //deviceInstanceRangeLowLimit = readOptional(queue, UnsignedInteger.class, 0);
            //deviceInstanceRangeHighLimit = readOptional(queue, UnsignedInteger.class, 1);
        }
    }
}

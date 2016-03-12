using System;
using Microsoft.SPOT;

namespace BACnetNetduino.APDU
{
    class SimpleACK : AckAPDU
    {
        public static readonly byte TYPE_ID = 2;

        /**
         * This parameter shall contain the value of the BACnetConfirmedServiceChoice corresponding to the service contained
         * in the previous BACnet-Confirmed-Service-Request that has resulted in this acknowledgment.
         */
        private readonly int serviceAckChoice;

        public SimpleACK(byte originalInvokeId, int serviceAckChoice)
        {
            this.originalInvokeId = originalInvokeId;
            this.serviceAckChoice = serviceAckChoice;
        }

        public override byte getPduType()
        {
            return TYPE_ID;
        }

        /*public override void write(ByteStream queue)
        {
            queue.push(getShiftedTypeId(TYPE_ID));
            queue.push(originalInvokeId);
            queue.push(serviceAckChoice);
        }*/

        public SimpleACK(ByteStream queue)
        {
            queue.ReadByte(); // no news here
            originalInvokeId = queue.ReadByte();
            serviceAckChoice = queue.popU1B();
        }

        public override bool expectsReply()
        {
            return false;
        }
    }
}

using System;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;
using BACnetServices.Service.Acknowledgement;
using Microsoft.SPOT;

namespace BACnetServices.Service.Confirmed
{
    class ConfirmedCovNotificationRequest : ConfirmedRequestService
    {
        public static readonly byte TYPE_ID = 1;

        private readonly UnsignedInteger subscriberProcessIdentifier;
        private readonly ObjectIdentifier initiatingDeviceIdentifier;
        private readonly ObjectIdentifier monitoredObjectIdentifier;
        private readonly UnsignedInteger timeRemaining;
        private readonly SequenceOf listOfValues;

        public ConfirmedCovNotificationRequest(UnsignedInteger subscriberProcessIdentifier,
            ObjectIdentifier initiatingDeviceIdentifier, ObjectIdentifier monitoredObjectIdentifier,
            UnsignedInteger timeRemaining, SequenceOf listOfValues)
        {
            this.subscriberProcessIdentifier = subscriberProcessIdentifier;
            this.initiatingDeviceIdentifier = initiatingDeviceIdentifier;
            this.monitoredObjectIdentifier = monitoredObjectIdentifier;
            this.timeRemaining = timeRemaining;
            this.listOfValues = listOfValues;
        }

        public override byte ChoiceId => TYPE_ID;

        public override AcknowledgementService handle(LocalDevice localDevice, Address from, OctetString linkService)
        {
            throw new NotImplementedException();
            /*localDevice.getEventHandler().fireCovNotification(subscriberProcessIdentifier,
                localDevice.getRemoteDeviceCreate(initiatingDeviceIdentifier.InstanceNumber, from, linkService),
                monitoredObjectIdentifier, timeRemaining, listOfValues);
            return null;*/
        }


        public override void write(ByteStream queue)
        {
            subscriberProcessIdentifier.write(queue, 0);
            initiatingDeviceIdentifier.write(queue, 1);
            monitoredObjectIdentifier.write(queue, 2);
            timeRemaining.write(queue, 3);
            listOfValues.write(queue, 4);
        }

        internal ConfirmedCovNotificationRequest(ByteStream queue)
        {
            subscriberProcessIdentifier = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 0);
            initiatingDeviceIdentifier = (ObjectIdentifier) read(queue, typeof (ObjectIdentifier), 1);
            monitoredObjectIdentifier = (ObjectIdentifier) read(queue, typeof (ObjectIdentifier), 2);
            timeRemaining = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 3);
            try
            {
                ThreadLocalObjectTypeStack.set(monitoredObjectIdentifier.ObjectType);
                listOfValues = readSequenceOf(queue, typeof (PropertyValue), 4);
            }
            finally
            {
                ThreadLocalObjectTypeStack.remove();
            }
        }
    }
}

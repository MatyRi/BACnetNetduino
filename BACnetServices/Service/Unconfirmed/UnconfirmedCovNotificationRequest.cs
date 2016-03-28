using System;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetServices.Service.Unconfirmed
{
    class UnconfirmedCovNotificationRequest : UnconfirmedRequestService
    {
        public static readonly byte TYPE_ID = 2;

        private readonly UnsignedInteger subscriberProcessIdentifier;
        private readonly ObjectIdentifier initiatingDeviceIdentifier;
        private readonly ObjectIdentifier monitoredObjectIdentifier;
        private readonly UnsignedInteger timeRemaining;
        private readonly SequenceOf listOfValues; //<PropertyValue>

        public UnconfirmedCovNotificationRequest(UnsignedInteger subscriberProcessIdentifier,
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


        public override void handle(LocalDevice localDevice, Address from, OctetString linkService)
        {
            throw new NotImplementedException();
            /*localDevice.getEventHandler().fireCovNotification(subscriberProcessIdentifier,
                    localDevice.getRemoteDeviceCreate(initiatingDeviceIdentifier.InstanceNumber, from, linkService),
                    monitoredObjectIdentifier, timeRemaining, listOfValues);*/
        }


        public override void write(ByteStream queue)
        {
            write(queue, subscriberProcessIdentifier, 0);
            write(queue, initiatingDeviceIdentifier, 1);
            write(queue, monitoredObjectIdentifier, 2);
            write(queue, timeRemaining, 3);
            write(queue, listOfValues, 4);
        }

        internal UnconfirmedCovNotificationRequest(ByteStream queue)
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

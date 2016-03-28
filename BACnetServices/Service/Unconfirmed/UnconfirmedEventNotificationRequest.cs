using System;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.NotificationParameter;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetServices.Service.Unconfirmed
{
    class UnconfirmedEventNotificationRequest : UnconfirmedRequestService
    {
        public static readonly byte TYPE_ID = 3;

        private readonly UnsignedInteger processIdentifier; // 0
        private readonly ObjectIdentifier initiatingDeviceIdentifier; // 1
        private readonly ObjectIdentifier eventObjectIdentifier; // 2
        private readonly TimeStamp timeStamp; // 3
        private readonly UnsignedInteger notificationClass; // 4
        private readonly UnsignedInteger priority; // 5
        private readonly EventType eventType; // 6
        private readonly CharacterString messageText; // 7 optional
        private readonly NotifyType notifyType; // 8
        private readonly BBoolean ackRequired; // 9 optional
        private readonly EventState fromState; // 10 optional
        private readonly EventState toState; // 11
        private readonly NotificationParameters eventValues; // 12 optional

        public UnconfirmedEventNotificationRequest(UnsignedInteger processIdentifier,
            ObjectIdentifier initiatingDeviceIdentifier, ObjectIdentifier eventObjectIdentifier, TimeStamp timeStamp,
            UnsignedInteger notificationClass, UnsignedInteger priority, EventType eventType,
            CharacterString messageText, NotifyType notifyType, BBoolean ackRequired, EventState fromState,
            EventState toState, NotificationParameters eventValues)
        {
            this.processIdentifier = processIdentifier;
            this.initiatingDeviceIdentifier = initiatingDeviceIdentifier;
            this.eventObjectIdentifier = eventObjectIdentifier;
            this.timeStamp = timeStamp;
            this.notificationClass = notificationClass;
            this.priority = priority;
            this.eventType = eventType;
            this.messageText = messageText;
            this.notifyType = notifyType;
            this.ackRequired = ackRequired;
            this.fromState = fromState;
            this.toState = toState;
            this.eventValues = eventValues;
        }


        public override byte ChoiceId => TYPE_ID;


        public override void handle(LocalDevice localDevice, Address from, OctetString linkService)
        {
            throw new NotImplementedException();
            /*localDevice.getEventHandler().fireEventNotification(processIdentifier,
                    localDevice.getRemoteDeviceCreate(initiatingDeviceIdentifier.InstanceNumber, from, linkService),
                    eventObjectIdentifier, timeStamp, notificationClass, priority, eventType, messageText, notifyType,
                    ackRequired, fromState, toState, eventValues);*/
        }


        public override void write(ByteStream queue)
        {
            write(queue, processIdentifier, 0);
            write(queue, initiatingDeviceIdentifier, 1);
            write(queue, eventObjectIdentifier, 2);
            write(queue, timeStamp, 3);
            write(queue, notificationClass, 4);
            write(queue, priority, 5);
            write(queue, eventType, 6);
            writeOptional(queue, messageText, 7);
            write(queue, notifyType, 8);
            writeOptional(queue, ackRequired, 9);
            writeOptional(queue, fromState, 10);
            write(queue, toState, 11);
            writeOptional(queue, eventValues, 12);
        }

        internal UnconfirmedEventNotificationRequest(ByteStream queue)
        {
            processIdentifier = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 0);
            initiatingDeviceIdentifier = (ObjectIdentifier) read(queue, typeof (ObjectIdentifier), 1);
            eventObjectIdentifier = (ObjectIdentifier) read(queue, typeof (ObjectIdentifier), 2);
            timeStamp = (TimeStamp) read(queue, typeof (TimeStamp), 3);
            notificationClass = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 4);
            priority = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 5);
            eventType = (EventType) read(queue, typeof (EventType), 6);
            messageText = (CharacterString) readOptional(queue, typeof (CharacterString), 7);
            notifyType = (NotifyType) read(queue, typeof (NotifyType), 8);
            ackRequired = (BBoolean) readOptional(queue, typeof (BBoolean), 9);
            fromState = (EventState) readOptional(queue, typeof (EventState), 10);
            toState = (EventState) read(queue, typeof (EventState), 11);
            eventValues = NotificationParameters.createNotificationParametersOptional(queue, 12);
        }
    }
}

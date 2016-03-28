using System;
using System.Collections;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetServices.Service.Unconfirmed
{
    class UnconfirmedTextMessageRequest : UnconfirmedRequestService
    {
        public static readonly byte TYPE_ID = 5;

        private static IList classes = new ArrayList()
        {
            typeof (UnsignedInteger),
            typeof (CharacterString)
        };

        private readonly ObjectIdentifier textMessageSourceDevice;
        private Choice messageClass;
        private readonly MessagePriority messagePriority;
        private readonly CharacterString message;

        public UnconfirmedTextMessageRequest(ObjectIdentifier textMessageSourceDevice, UnsignedInteger messageClass,
            MessagePriority messagePriority, CharacterString message)
        {
            this.textMessageSourceDevice = textMessageSourceDevice;
            this.messageClass = new Choice(0, messageClass);
            this.messagePriority = messagePriority;
            this.message = message;
        }

        public UnconfirmedTextMessageRequest(ObjectIdentifier textMessageSourceDevice, CharacterString messageClass,
            MessagePriority messagePriority, CharacterString message)
        {
            this.textMessageSourceDevice = textMessageSourceDevice;
            this.messageClass = new Choice(0, messageClass);
            this.messagePriority = messagePriority;
            this.message = message;
        }

        public UnconfirmedTextMessageRequest(ObjectIdentifier textMessageSourceDevice, MessagePriority messagePriority,
            CharacterString message)
        {
            this.textMessageSourceDevice = textMessageSourceDevice;
            this.messagePriority = messagePriority;
            this.message = message;
        }


        public override byte ChoiceId => TYPE_ID;


        public override void handle(LocalDevice localDevice, Address from, OctetString linkService)
        {
            throw new NotImplementedException();
            /*localDevice.getEventHandler().fireTextMessage(
                localDevice.getRemoteDeviceCreate(textMessageSourceDevice.InstanceNumber, from, linkService),
                messageClass, messagePriority, message);*/
        }


        public override void write(ByteStream queue)
        {
            write(queue, textMessageSourceDevice, 0);
            writeOptional(queue, messageClass, 1);
            write(queue, messagePriority, 2);
            write(queue, message, 3);
        }

        UnconfirmedTextMessageRequest(ByteStream queue)
        {
            textMessageSourceDevice = (ObjectIdentifier) read(queue, typeof (ObjectIdentifier), 0);
            if (readStart(queue) == 1)
                messageClass = new Choice(queue, classes);
            messagePriority = (MessagePriority) read(queue, typeof (MessagePriority), 2);
            message = (CharacterString) read(queue, typeof (CharacterString), 3);
        }
    }
}

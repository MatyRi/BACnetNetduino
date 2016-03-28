using System;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetServices.Service.Acknowledgement
{
    class GetEnrollmentSummaryAck : AcknowledgementService
    {
        public static readonly byte TYPE_ID = 4;

        public GetEnrollmentSummaryAck(SequenceOf values)
        {
            Values = values;
        }

        public override byte ChoiceId => TYPE_ID;

        public override void write(ByteStream queue)
        {
            write(queue, Values);
        }

        internal GetEnrollmentSummaryAck(ByteStream queue)
        {
            Values = readSequenceOf(queue, typeof (EnrollmentSummary));
        }

        public SequenceOf Values { get; } // <EnrollmentSummary>
    }

    public class EnrollmentSummary : BaseType
    {
        public EnrollmentSummary(ObjectIdentifier objectIdentifier, EventType eventType, EventState eventState,
            UnsignedInteger priority, UnsignedInteger notificationClass)
        {
            this.ObjectIdentifier = objectIdentifier;
            this.EventType = eventType;
            this.EventState = eventState;
            this.Priority = priority;
            this.NotificationClass = notificationClass;
        }

        public void write(ByteStream queue)
        {
            write(queue, ObjectIdentifier);
            write(queue, EventType);
            write(queue, EventState);
            write(queue, Priority);
            writeOptional(queue, NotificationClass);
        }

        public EnrollmentSummary(ByteStream queue)
        {
            ObjectIdentifier = (ObjectIdentifier) read(queue, typeof (ObjectIdentifier));
            EventType = (EventType) read(queue, typeof (EventType));
            EventState = (EventState) read(queue, typeof (EventState));
            Priority = (UnsignedInteger) read(queue, typeof (UnsignedInteger));
            if (peekTagNumber(queue) == UnsignedInteger.TYPE_ID)
                NotificationClass = (UnsignedInteger) read(queue, typeof (UnsignedInteger));
            else
                NotificationClass = null;
        }

        public ObjectIdentifier ObjectIdentifier { get; }

        public EventType EventType { get; }

        public EventState EventState { get; }

        public UnsignedInteger Priority { get; }

        public UnsignedInteger NotificationClass { get; }
    }
}

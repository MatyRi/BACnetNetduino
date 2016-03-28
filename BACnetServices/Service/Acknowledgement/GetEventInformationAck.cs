using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;

namespace BACnetServices.Service.Acknowledgement
{
    class GetEventInformationAck : AcknowledgementService
    {
        public static readonly byte TypeId = 29;

        public GetEventInformationAck(SequenceOf listOfEventSummaries, BBoolean moreEvents)
        {
            ListOfEventSummaries = listOfEventSummaries;
            MoreEvents = moreEvents;
        }

        public override byte ChoiceId => TypeId;


        public override void write(ByteStream queue)
        {
            write(queue, ListOfEventSummaries, 0);
            write(queue, MoreEvents, 1);
        }

        internal GetEventInformationAck(ByteStream queue)
        {
            ListOfEventSummaries = readSequenceOf(queue, typeof (EventSummary), 0);
            MoreEvents = (BBoolean) read(queue, typeof (BBoolean), 1);
        }

        public SequenceOf ListOfEventSummaries { get; }

        public BBoolean MoreEvents { get; }
    }

    public class EventSummary : BaseType
    {
        public EventSummary(ObjectIdentifier objectIdentifier, EventState eventState,
            EventTransitionBits acknowledgedTransitions, TimeStamp eventTimeStamp1, TimeStamp eventTimeStamp2,
            TimeStamp eventTimeStamp3, NotifyType notifyType, EventTransitionBits eventEnable,
            UnsignedInteger eventPriorities1, UnsignedInteger eventPriorities2, UnsignedInteger eventPriorities3)
        {
            ObjectIdentifier = objectIdentifier;
            EventState = eventState;
            AcknowledgedTransitions = acknowledgedTransitions;
            EventTimeStamp1 = eventTimeStamp1;
            EventTimeStamp2 = eventTimeStamp2;
            EventTimeStamp3 = eventTimeStamp3;
            NotifyType = notifyType;
            EventEnable = eventEnable;
            EventPriorities1 = eventPriorities1;
            EventPriorities2 = eventPriorities2;
            EventPriorities3 = eventPriorities3;
        }

        public override void write(ByteStream queue)
        {
            ObjectIdentifier.write(queue, 0);
            EventState.write(queue, 1);
            AcknowledgedTransitions.write(queue, 2);
            writeContextTag(queue, 3, true);
            EventTimeStamp1.write(queue);
            EventTimeStamp2.write(queue);
            EventTimeStamp3.write(queue);
            writeContextTag(queue, 3, false);
            NotifyType.write(queue, 4);
            EventEnable.write(queue, 5);
            writeContextTag(queue, 6, true);
            EventPriorities1.write(queue);
            EventPriorities2.write(queue);
            EventPriorities3.write(queue);
            writeContextTag(queue, 6, false);
        }

        public EventSummary(ByteStream queue)
        {
            ObjectIdentifier = (ObjectIdentifier) read(queue, typeof (ObjectIdentifier), 0);
            EventState = (EventState) read(queue, typeof (EventState), 1);
            AcknowledgedTransitions = (EventTransitionBits) read(queue, typeof (EventTransitionBits), 2);
            popStart(queue, 3);
            EventTimeStamp1 = (TimeStamp) read(queue, typeof (TimeStamp));
            EventTimeStamp2 = (TimeStamp) read(queue, typeof (TimeStamp));
            EventTimeStamp3 = (TimeStamp) read(queue, typeof (TimeStamp));
            popEnd(queue, 3);
            NotifyType = (NotifyType) read(queue, typeof (NotifyType), 4);
            EventEnable = (EventTransitionBits) read(queue, typeof (EventTransitionBits), 5);
            popStart(queue, 6);
            EventPriorities1 = (UnsignedInteger) read(queue, typeof (UnsignedInteger));
            EventPriorities2 = (UnsignedInteger) read(queue, typeof (UnsignedInteger));
            EventPriorities3 = (UnsignedInteger) read(queue, typeof (UnsignedInteger));
            popEnd(queue, 6);
        }

        public ObjectIdentifier ObjectIdentifier { get; }

        public EventState EventState { get; }

        public EventTransitionBits AcknowledgedTransitions { get; }

        public TimeStamp EventTimeStamp1 { get; }

        public TimeStamp EventTimeStamp2 { get; }

        public TimeStamp EventTimeStamp3 { get; }

        public NotifyType NotifyType { get; }

        public EventTransitionBits EventEnable { get; }

        public UnsignedInteger EventPriorities1 { get; }

        public UnsignedInteger EventPriorities2 { get; }

        public UnsignedInteger EventPriorities3 { get; }
    }
}

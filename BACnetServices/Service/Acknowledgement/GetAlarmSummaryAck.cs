using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;

namespace BACnetServices.Service.Acknowledgement
{
    class GetAlarmSummaryAck : AcknowledgementService
    {
        public static readonly byte TYPE_ID = 3;

        public GetAlarmSummaryAck(SequenceOf values)
        {
            Values = values;
        }

        public override byte ChoiceId => TYPE_ID;

        public void write(ByteStream queue)
        {
            write(queue, Values);
        }

        internal GetAlarmSummaryAck(ByteStream queue)
        {
            Values = readSequenceOf(queue, typeof (AlarmSummary));
        }

        public SequenceOf Values { get; } //AlarmSummary
    }

    public class AlarmSummary : BaseType
    {
        public AlarmSummary(ObjectIdentifier objectIdentifier, EventState alarmState,
            EventTransitionBits acknowledgedTransitions)
        {
            ObjectIdentifier = objectIdentifier;
            AlarmState = alarmState;
            AcknowledgedTransitions = acknowledgedTransitions;
        }

        public override void write(ByteStream queue)
        {
            ObjectIdentifier.write(queue);
            AlarmState.write(queue);
            AcknowledgedTransitions.write(queue);
        }

        public AlarmSummary(ByteStream queue)
        {
            ObjectIdentifier = (ObjectIdentifier) read(queue, typeof (ObjectIdentifier));
            AlarmState = (EventState) read(queue, typeof (EventState));
            AcknowledgedTransitions = (EventTransitionBits) read(queue, typeof (EventTransitionBits));
        }

        public ObjectIdentifier ObjectIdentifier { get; }

        public EventState AlarmState { get; }

        public EventTransitionBits AcknowledgedTransitions { get; }
    }
}

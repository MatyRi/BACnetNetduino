using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.EventParameter
{
    class ChangeOfLifeSafety : EventParameter
    {
        public static readonly byte TYPE_ID = 8;

        public ChangeOfLifeSafety(UnsignedInteger timeDelay, SequenceOf listOfLifeSafetyAlarmValues,
            SequenceOf listOfAlarmValues, DeviceObjectPropertyReference modePropertyReference)
        {
            TimeDelay = timeDelay;
            ListOfLifeSafetyAlarmValues = listOfLifeSafetyAlarmValues;
            ListOfAlarmValues = listOfAlarmValues;
            ModePropertyReference = modePropertyReference;
        }


        protected override void writeImpl(ByteStream queue)
        {
            write(queue, TimeDelay, 0);
            write(queue, ListOfLifeSafetyAlarmValues, 1);
            write(queue, ListOfAlarmValues, 2);
            write(queue, ModePropertyReference, 3);
        }

        public ChangeOfLifeSafety(ByteStream queue)
        {
            TimeDelay = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 0);
            ListOfLifeSafetyAlarmValues = readSequenceOf(queue, typeof (LifeSafetyState), 1);
            ListOfAlarmValues = readSequenceOf(queue, typeof (LifeSafetyState), 2);
            ModePropertyReference = (DeviceObjectPropertyReference) read(queue, typeof (DeviceObjectPropertyReference), 3);
        }

        protected override int TypeId => TYPE_ID;

        public UnsignedInteger TimeDelay { get; }

        public SequenceOf ListOfLifeSafetyAlarmValues { get; }

        public SequenceOf ListOfAlarmValues { get; }

        public DeviceObjectPropertyReference ModePropertyReference { get; }
    }
}

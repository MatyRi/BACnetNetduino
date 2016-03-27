using System;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetDataTypes.EventParameter
{
    class CommandFailure : EventParameter
    {
        public static readonly byte TYPE_ID = 3;

        public CommandFailure(UnsignedInteger timeDelay, DeviceObjectPropertyReference feedbackPropertyReference)
        {
            TimeDelay = timeDelay;
            FeedbackPropertyReference = feedbackPropertyReference;
        }

        protected override void writeImpl(ByteStream queue)
        {
            write(queue, TimeDelay, 0);
            write(queue, FeedbackPropertyReference, 1);
        }

        public CommandFailure(ByteStream queue)
        {
            TimeDelay = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 0);
            FeedbackPropertyReference = (DeviceObjectPropertyReference) read(queue, typeof (DeviceObjectPropertyReference), 1);
        }

        protected override int TypeId => TYPE_ID;

        public UnsignedInteger TimeDelay { get; }

        public DeviceObjectPropertyReference FeedbackPropertyReference { get; }
    }
}

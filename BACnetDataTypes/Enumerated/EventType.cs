using BACnetDataTypes.NotificationParameter;

namespace BACnetDataTypes.Enumerated
{
    public class EventType : Primitive.Enumerated
    {
        public static readonly EventType ChangeOfBitstring = new EventType(ChangeOfBitString.TYPE_ID);
        public static readonly EventType ChangeOfState = new EventType(NotificationParameter.ChangeOfState.TYPE_ID);
        public static readonly EventType ChangeOfValue = new EventType(NotificationParameter.ChangeOfValue.TYPE_ID);
        public static readonly EventType CommandFailure = new EventType(NotificationParameter.CommandFailure.TYPE_ID);
        public static readonly EventType FloatingLimit = new EventType(NotificationParameter.FloatingLimit.TYPE_ID);
        public static readonly EventType OutOfRange = new EventType(NotificationParameter.OutOfRange.TYPE_ID);
        public static readonly EventType ChangeOfLifeSafety = new EventType(NotificationParameter.ChangeOfLifeSafety.TYPE_ID);
        public static readonly EventType Extended = new EventType(NotificationParameter.Extended.TYPE_ID);
        public static readonly EventType BufferReady = new EventType(NotificationParameter.BufferReady.TYPE_ID);
        public static readonly EventType UnsignedRange = new EventType(NotificationParameter.UnsignedRange.TYPE_ID);

        public static readonly EventType[] All =
        {
            ChangeOfBitstring, ChangeOfState, ChangeOfValue, CommandFailure,
            FloatingLimit, OutOfRange, ChangeOfLifeSafety, Extended, BufferReady, UnsignedRange
        };

        public EventType(uint value) : base(value)
        {
        }

        public EventType(ByteStream queue) : base(queue)
        {
        }
    }
}

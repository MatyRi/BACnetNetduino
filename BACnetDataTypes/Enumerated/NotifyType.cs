namespace BACnetDataTypes.Enumerated
{
    public class NotifyType : Primitive.Enumerated
    {
        public static readonly NotifyType Alarm = new NotifyType(0);
        public static readonly NotifyType Event = new NotifyType(1);
        public static readonly NotifyType AckNotification = new NotifyType(2);

        public static readonly NotifyType[] All = {Alarm, Event, AckNotification};

        public NotifyType(uint value) : base(value)
        {
        }

        public NotifyType(ByteStream queue) : base(queue)
        {
        }
    }
}

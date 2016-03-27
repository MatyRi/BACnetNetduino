namespace BACnetDataTypes.Enumerated
{
    class EventState : Primitive.Enumerated
    {
        public static readonly EventState Normal = new EventState(0);
        public static readonly EventState Fault = new EventState(1);
        public static readonly EventState Offnormal = new EventState(2);
        public static readonly EventState HighLimit = new EventState(3);
        public static readonly EventState LowLimit = new EventState(4);
        public static readonly EventState LifeSafetyAlarm = new EventState(5);

        public static readonly EventState[] All = {Normal, Fault, Offnormal, HighLimit, LowLimit, LifeSafetyAlarm};

        public EventState(uint value) : base(value)
        {
        }

        public EventState(ByteStream queue) : base(queue)
        {
        }

        public override string ToString()
        {
            if (Value == 0)
                return "normal";
            if (Value == 1)
                return "fault";
            if (Value == 2)
                return "off normal";
            if (Value == 3)
                return "high limit";
            if (Value == 4)
                return "low limit";
            if (Value == 5)
                return "life safety alarm";
            return "Unknown";
        }
    }
}

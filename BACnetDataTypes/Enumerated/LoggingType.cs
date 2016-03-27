namespace BACnetDataTypes.Enumerated
{
    class LoggingType : Primitive.Enumerated
    {
        public static readonly LoggingType Polled = new LoggingType(0);
        public static readonly LoggingType Cov = new LoggingType(1);
        public static readonly LoggingType Triggered = new LoggingType(2);

        public static readonly LoggingType[] All = {Polled, Cov, Triggered};

        public LoggingType(uint value) : base(value)
        {
        }

        public LoggingType(ByteStream queue) : base(queue)
        {
        }
    }
}

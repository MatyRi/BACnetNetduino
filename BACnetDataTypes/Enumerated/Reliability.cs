namespace BACnetDataTypes.Enumerated
{
    class Reliability : Primitive.Enumerated
    {
        public static readonly Reliability NoFaultDetected = new Reliability(0);
        public static readonly Reliability NoSensor = new Reliability(1);
        public static readonly Reliability OverRange = new Reliability(2);
        public static readonly Reliability UnderRange = new Reliability(3);
        public static readonly Reliability OpenLoop = new Reliability(4);
        public static readonly Reliability ShortedLoop = new Reliability(5);
        public static readonly Reliability NoOutput = new Reliability(6);
        public static readonly Reliability UnreliableOther = new Reliability(7);
        public static readonly Reliability ProcessError = new Reliability(8);
        public static readonly Reliability MultiStateFault = new Reliability(9);
        public static readonly Reliability ConfigurationError = new Reliability(10);
        public static readonly Reliability CommunicationFailure = new Reliability(12);

        public static readonly Reliability[] All =
        {
            NoFaultDetected, NoSensor, OverRange, UnderRange, OpenLoop, ShortedLoop,
            NoOutput, UnreliableOther, ProcessError, MultiStateFault, ConfigurationError, CommunicationFailure
        };

        public Reliability(uint value) : base(value)
        {
        }

        public Reliability(ByteStream queue) : base(queue)
        {
        }
    }
}

namespace BACnetDataTypes.Enumerated
{
    class ShedState : Primitive.Enumerated
    {
        public static readonly ShedState ShedInactive = new ShedState(0);
        public static readonly ShedState ShedRequestPending = new ShedState(1);
        public static readonly ShedState ShedCompliant = new ShedState(2);
        public static readonly ShedState ShedNonCompliant = new ShedState(3);

        public static readonly ShedState[] All = {ShedInactive, ShedRequestPending, ShedCompliant, ShedNonCompliant,};

        public ShedState(uint value) : base(value)
        {
        }

        public ShedState(ByteStream queue) : base(queue)
        {
        }
    }
}

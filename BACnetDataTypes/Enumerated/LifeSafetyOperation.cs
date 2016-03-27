namespace BACnetDataTypes.Enumerated
{
    class LifeSafetyOperation : Primitive.Enumerated
    {
        public static readonly LifeSafetyOperation None = new LifeSafetyOperation(0);
        public static readonly LifeSafetyOperation Silence = new LifeSafetyOperation(1);
        public static readonly LifeSafetyOperation SilenceAudible = new LifeSafetyOperation(2);
        public static readonly LifeSafetyOperation SilenceVisual = new LifeSafetyOperation(3);
        public static readonly LifeSafetyOperation Reset = new LifeSafetyOperation(4);
        public static readonly LifeSafetyOperation ResetAlarm = new LifeSafetyOperation(5);
        public static readonly LifeSafetyOperation ResetFault = new LifeSafetyOperation(6);
        public static readonly LifeSafetyOperation Unsilence = new LifeSafetyOperation(7);
        public static readonly LifeSafetyOperation UnsilenceAudible = new LifeSafetyOperation(8);
        public static readonly LifeSafetyOperation UnsilenceVisual = new LifeSafetyOperation(9);

        public static readonly LifeSafetyOperation[] All =
        {
            None, Silence, SilenceAudible, SilenceVisual, Reset, ResetAlarm,
            ResetFault, Unsilence, UnsilenceAudible, UnsilenceVisual,
        };

        public LifeSafetyOperation(uint value) : base(value)
        {
        }

        public LifeSafetyOperation(ByteStream queue) : base(queue)
        {
        }
    }
}

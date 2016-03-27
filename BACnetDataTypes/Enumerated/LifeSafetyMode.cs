namespace BACnetDataTypes.Enumerated
{
    class LifeSafetyMode : Primitive.Enumerated
    {
        public static readonly LifeSafetyMode Off = new LifeSafetyMode(0);
        public static readonly LifeSafetyMode On = new LifeSafetyMode(1);
        public static readonly LifeSafetyMode Test = new LifeSafetyMode(2);
        public static readonly LifeSafetyMode Manned = new LifeSafetyMode(3);
        public static readonly LifeSafetyMode Unmanned = new LifeSafetyMode(4);
        public static readonly LifeSafetyMode Armed = new LifeSafetyMode(5);
        public static readonly LifeSafetyMode Disarmed = new LifeSafetyMode(6);
        public static readonly LifeSafetyMode Prearmed = new LifeSafetyMode(7);
        public static readonly LifeSafetyMode Slow = new LifeSafetyMode(8);
        public static readonly LifeSafetyMode Fast = new LifeSafetyMode(9);
        public static readonly LifeSafetyMode Disconnected = new LifeSafetyMode(10);
        public static readonly LifeSafetyMode Enabled = new LifeSafetyMode(11);
        public static readonly LifeSafetyMode Disabled = new LifeSafetyMode(12);
        public static readonly LifeSafetyMode AutomaticReleaseDisabled = new LifeSafetyMode(13);
        public static readonly LifeSafetyMode DefaultMode = new LifeSafetyMode(14);

        public static readonly LifeSafetyMode[] All =
        {
            Off, On, Test, Manned, Unmanned, Armed, Disarmed, Prearmed, Slow,
            Fast, Disconnected, Enabled, Disabled, AutomaticReleaseDisabled, DefaultMode,
        };

        public LifeSafetyMode(uint value) : base(value)
        {
        }

        public LifeSafetyMode(ByteStream queue) : base(queue)
        {
        }
    }
}

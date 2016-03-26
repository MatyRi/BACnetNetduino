namespace BACnetDataTypes.Enumerated
{
    public class RestartReason : Primitive.Enumerated
    {
        public static readonly RestartReason unknown = new RestartReason(0);
        public static readonly RestartReason coldstart = new RestartReason(1);
        public static readonly RestartReason warmstart = new RestartReason(2);
        public static readonly RestartReason detectedPowerLost = new RestartReason(3);
        public static readonly RestartReason detectedPoweredOff = new RestartReason(4);
        public static readonly RestartReason hardwareWatchdog = new RestartReason(5);
        public static readonly RestartReason softwareWatchdog = new RestartReason(6);
        public static readonly RestartReason suspended = new RestartReason(7);

        public static readonly RestartReason[] ALL = { unknown, coldstart, warmstart, detectedPowerLost, detectedPoweredOff,
            hardwareWatchdog, softwareWatchdog, suspended, };

    public RestartReason(uint value) : base(value) { }

    public RestartReason(ByteStream queue) : base(queue) { }
}
}

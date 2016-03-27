namespace BACnetDataTypes.Enumerated
{
    public class RestartReason : Primitive.Enumerated
    {
        public static readonly RestartReason Unknown = new RestartReason(0);
        public static readonly RestartReason Coldstart = new RestartReason(1);
        public static readonly RestartReason Warmstart = new RestartReason(2);
        public static readonly RestartReason DetectedPowerLost = new RestartReason(3);
        public static readonly RestartReason DetectedPoweredOff = new RestartReason(4);
        public static readonly RestartReason HardwareWatchdog = new RestartReason(5);
        public static readonly RestartReason SoftwareWatchdog = new RestartReason(6);
        public static readonly RestartReason Suspended = new RestartReason(7);

        public static readonly RestartReason[] All =
        {
            Unknown, Coldstart, Warmstart, DetectedPowerLost, DetectedPoweredOff,
            HardwareWatchdog, SoftwareWatchdog, Suspended
        };

        public RestartReason(uint value) : base(value)
        {
        }

        public RestartReason(ByteStream queue) : base(queue)
        {
        }
    }
}

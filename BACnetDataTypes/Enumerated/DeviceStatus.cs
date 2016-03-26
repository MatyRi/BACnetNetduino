namespace BACnetDataTypes.Enumerated
{
    public class DeviceStatus : Primitive.Enumerated
    {
        public static readonly DeviceStatus Operational = new DeviceStatus(0);
        public static readonly DeviceStatus OperationalReadOnly = new DeviceStatus(1);
        public static readonly DeviceStatus DownloadRequired = new DeviceStatus(2);
        public static readonly DeviceStatus DownloadInProgress = new DeviceStatus(3);
        public static readonly DeviceStatus NonOperational = new DeviceStatus(4);
        public static readonly DeviceStatus BackupInProgress = new DeviceStatus(5);

        public static readonly DeviceStatus[] All = { Operational, OperationalReadOnly, DownloadRequired, DownloadInProgress,
            NonOperational, BackupInProgress, };

    public DeviceStatus(uint value) : base(value) { }

    public DeviceStatus(ByteStream queue) : base(queue) { }
}
}

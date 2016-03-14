using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Enumerated
{
    class DeviceStatus : Primitive.Enumerated
    {
        public static readonly DeviceStatus operational = new DeviceStatus(0);
        public static readonly DeviceStatus operationalReadOnly = new DeviceStatus(1);
        public static readonly DeviceStatus downloadRequired = new DeviceStatus(2);
        public static readonly DeviceStatus downloadInProgress = new DeviceStatus(3);
        public static readonly DeviceStatus nonOperational = new DeviceStatus(4);
        public static readonly DeviceStatus backupInProgress = new DeviceStatus(5);

        public static readonly DeviceStatus[] ALL = { operational, operationalReadOnly, downloadRequired, downloadInProgress,
            nonOperational, backupInProgress, };

    public DeviceStatus(uint value) : base(value) { }

    public DeviceStatus(ByteStream queue) : base(queue) { }
}
}

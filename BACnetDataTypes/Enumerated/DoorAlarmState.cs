namespace BACnetDataTypes.Enumerated
{
    class DoorAlarmState : Primitive.Enumerated
    {
        public static readonly DoorAlarmState Normal = new DoorAlarmState(0);
        public static readonly DoorAlarmState Alarm = new DoorAlarmState(1);
        public static readonly DoorAlarmState DoorOpenTooLong = new DoorAlarmState(2);
        public static readonly DoorAlarmState ForcedOpen = new DoorAlarmState(3);
        public static readonly DoorAlarmState Tamper = new DoorAlarmState(4);
        public static readonly DoorAlarmState DoorFault = new DoorAlarmState(5);
        public static readonly DoorAlarmState LockDown = new DoorAlarmState(6);
        public static readonly DoorAlarmState FreeAccess = new DoorAlarmState(7);
        public static readonly DoorAlarmState EgressOpen = new DoorAlarmState(8);

        public static readonly DoorAlarmState[] All =
        {
            Normal, Alarm, DoorOpenTooLong, ForcedOpen, Tamper, DoorFault,
            LockDown, FreeAccess, EgressOpen
        };

        public DoorAlarmState(uint value) : base(value)
        {
        }

        public DoorAlarmState(ByteStream queue) : base(queue)
        {
        }
    }
}

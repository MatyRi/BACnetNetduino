namespace BACnetDataTypes.Enumerated
{
    class LifeSafetyState : Primitive.Enumerated
    {
        public static readonly LifeSafetyState Quiet = new LifeSafetyState(0);
        public static readonly LifeSafetyState PreAlarm = new LifeSafetyState(1);
        public static readonly LifeSafetyState Alarm = new LifeSafetyState(2);
        public static readonly LifeSafetyState Fault = new LifeSafetyState(3);
        public static readonly LifeSafetyState FaultPreAlarm = new LifeSafetyState(4);
        public static readonly LifeSafetyState FaultAlarm = new LifeSafetyState(5);
        public static readonly LifeSafetyState NotReady = new LifeSafetyState(6);
        public static readonly LifeSafetyState Active = new LifeSafetyState(7);
        public static readonly LifeSafetyState Tamper = new LifeSafetyState(8);
        public static readonly LifeSafetyState TestAlarm = new LifeSafetyState(9);
        public static readonly LifeSafetyState TestActive = new LifeSafetyState(10);
        public static readonly LifeSafetyState TestFault = new LifeSafetyState(11);
        public static readonly LifeSafetyState TestFaultAlarm = new LifeSafetyState(12);
        public static readonly LifeSafetyState Holdup = new LifeSafetyState(13);
        public static readonly LifeSafetyState Duress = new LifeSafetyState(14);
        public static readonly LifeSafetyState TamperAlarm = new LifeSafetyState(15);
        public static readonly LifeSafetyState Abnormal = new LifeSafetyState(16);
        public static readonly LifeSafetyState EmergencyPower = new LifeSafetyState(17);
        public static readonly LifeSafetyState Delayed = new LifeSafetyState(18);
        public static readonly LifeSafetyState Blocked = new LifeSafetyState(19);
        public static readonly LifeSafetyState LocalAlarm = new LifeSafetyState(20);
        public static readonly LifeSafetyState GeneralAlarm = new LifeSafetyState(21);
        public static readonly LifeSafetyState Basevisory = new LifeSafetyState(22);
        public static readonly LifeSafetyState Testbasevisory = new LifeSafetyState(23);

        public static readonly LifeSafetyState[] All =
        {
            Quiet, PreAlarm, Alarm, Fault, FaultPreAlarm, FaultAlarm, NotReady,
            Active, Tamper, TestAlarm, TestActive, TestFault, TestFaultAlarm, Holdup, Duress, TamperAlarm, Abnormal,
            EmergencyPower, Delayed, Blocked, LocalAlarm, GeneralAlarm, Basevisory, Testbasevisory
        };

        public LifeSafetyState(uint value) : base(value)
        {
        }

        public LifeSafetyState(ByteStream queue) : base(queue)
        {
        }

        public override string ToString()
        {
            uint type = Value;
            if (type == Quiet.Value)
                return "Quiet";
            if (type == PreAlarm.Value)
                return "Pre-alarm";
            if (type == Alarm.Value)
                return "Alarm";
            if (type == Fault.Value)
                return "Fault";
            if (type == FaultPreAlarm.Value)
                return "Fault pre-alarm";
            if (type == FaultAlarm.Value)
                return "Fault alarm";
            if (type == NotReady.Value)
                return "Not ready";
            if (type == Active.Value)
                return "Active";
            if (type == Tamper.Value)
                return "Tamper";
            if (type == TestAlarm.Value)
                return "Test alarm";
            if (type == TestActive.Value)
                return "Test active";
            if (type == TestFault.Value)
                return "Test fault";
            if (type == TestFaultAlarm.Value)
                return "Test fault alarm";
            if (type == Holdup.Value)
                return "Holdup";
            if (type == Duress.Value)
                return "Duress";
            if (type == TamperAlarm.Value)
                return "Tamper alarm";
            if (type == Abnormal.Value)
                return "Abnormal";
            if (type == EmergencyPower.Value)
                return "Emergency power";
            if (type == Delayed.Value)
                return "Delayed";
            if (type == Blocked.Value)
                return "Blocked";
            if (type == LocalAlarm.Value)
                return "Local alarm";
            if (type == GeneralAlarm.Value)
                return "General alarm";
            if (type == Basevisory.Value)
                return "basevisory";
            if (type == Testbasevisory.Value)
                return "Test basevisory";

            return "Unknown: " + type;
        }
    }
}

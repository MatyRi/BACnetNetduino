namespace BACnetDataTypes.Enumerated
{
    public class ObjectType : Primitive.Enumerated
    {
        public static readonly ObjectType AnalogInput = new ObjectType(0);
        public static readonly ObjectType AnalogOutput = new ObjectType(1);
        public static readonly ObjectType AnalogValue = new ObjectType(2);
        public static readonly ObjectType BinaryInput = new ObjectType(3);
        public static readonly ObjectType BinaryOutput = new ObjectType(4);
        public static readonly ObjectType BinaryValue = new ObjectType(5);
        public static readonly ObjectType Calendar = new ObjectType(6);
        public static readonly ObjectType Command = new ObjectType(7);
        public static readonly ObjectType Device = new ObjectType(8);
        public static readonly ObjectType EventEnrollment = new ObjectType(9);
        public static readonly ObjectType File = new ObjectType(10);
        public static readonly ObjectType Group = new ObjectType(11);
        public static readonly ObjectType Loop = new ObjectType(12);
        public static readonly ObjectType MultiStateInput = new ObjectType(13);
        public static readonly ObjectType MultiStateOutput = new ObjectType(14);
        public static readonly ObjectType NotificationClass = new ObjectType(15);
        public static readonly ObjectType Program = new ObjectType(16);
        public static readonly ObjectType Schedule = new ObjectType(17);
        public static readonly ObjectType Averaging = new ObjectType(18);
        public static readonly ObjectType MultiStateValue = new ObjectType(19);
        public static readonly ObjectType TrendLog = new ObjectType(20);
        public static readonly ObjectType LifeSafetyPoint = new ObjectType(21);
        public static readonly ObjectType LifeSafetyZone = new ObjectType(22);
        public static readonly ObjectType Accumulator = new ObjectType(23);
        public static readonly ObjectType PulseConverter = new ObjectType(24);
        public static readonly ObjectType EventLog = new ObjectType(25);

        public static readonly ObjectType GlobalGroup = new ObjectType(26);

        public static readonly ObjectType TrendLogMultiple = new ObjectType(27);
        public static readonly ObjectType LoadControl = new ObjectType(28);
        public static readonly ObjectType StructuredView = new ObjectType(29);
        public static readonly ObjectType AccessDoor = new ObjectType(30);

        public static readonly ObjectType Timer = new ObjectType(31);
        public static readonly ObjectType AccessCredential = new ObjectType(32);
        public static readonly ObjectType AccessPoint = new ObjectType(33);
        public static readonly ObjectType AccessRights = new ObjectType(34);
        public static readonly ObjectType AccessUser = new ObjectType(35);
        public static readonly ObjectType AccessZone = new ObjectType(36);
        public static readonly ObjectType CredentialDataInput = new ObjectType(37);
        public static readonly ObjectType NetworkSecurity = new ObjectType(38);
        public static readonly ObjectType BitStringValue = new ObjectType(39);
        public static readonly ObjectType CharacterStringValue = new ObjectType(40);
        public static readonly ObjectType DatePatternValue = new ObjectType(41);
        public static readonly ObjectType DateValue = new ObjectType(42);
        public static readonly ObjectType DateTimePatternValue = new ObjectType(43);
        public static readonly ObjectType DateTimeValue = new ObjectType(44);
        public static readonly ObjectType IntegerValue = new ObjectType(45);
        public static readonly ObjectType LargeAnalogValue = new ObjectType(46);
        public static readonly ObjectType OctetStringValue = new ObjectType(47);
        public static readonly ObjectType PositiveIntegerValue = new ObjectType(48);
        public static readonly ObjectType TimePatternValue = new ObjectType(49);
        public static readonly ObjectType TimeValue = new ObjectType(50);
        public static readonly ObjectType NotificationForwarder = new ObjectType(51);
        public static readonly ObjectType AlertEnrollment = new ObjectType(52);
        public static readonly ObjectType Channel = new ObjectType(53);
        public static readonly ObjectType LightingOutput = new ObjectType(54);
        public static readonly ObjectType BinaryLightingOutput = new ObjectType(55);
        public static readonly ObjectType NetworkPort = new ObjectType(56);

        public static readonly ObjectType[] All =
        {
            AnalogInput, AnalogOutput, AnalogValue, BinaryInput, BinaryOutput,
            BinaryValue, Calendar, Command, Device, EventEnrollment, File, Group, Loop, MultiStateInput,
            MultiStateOutput, NotificationClass, Program, Schedule, Averaging, MultiStateValue, TrendLog,
            LifeSafetyPoint, LifeSafetyZone, Accumulator, PulseConverter, EventLog, TrendLogMultiple, LoadControl,
            StructuredView, AccessDoor
        };

        public ObjectType(uint value) : base(value)
        {
        }

        public ObjectType(ByteStream queue) : base(queue)
        {
        }

        public override string ToString()
        {
            uint type = Value;
            if (type == AnalogInput.Value)
                return "Analog Input";
            if (type == AnalogOutput.Value)
                return "Analog Output";
            if (type == AnalogValue.Value)
                return "Analog Value";
            if (type == BinaryInput.Value)
                return "Binary Input";
            if (type == BinaryOutput.Value)
                return "Binary Output";
            if (type == BinaryValue.Value)
                return "Binary Value";
            if (type == Calendar.Value)
                return "Calendar";
            if (type == Command.Value)
                return "Command";
            if (type == Device.Value)
                return "Device";
            if (type == EventEnrollment.Value)
                return "Event Enrollment";
            if (type == File.Value)
                return "File";
            if (type == Group.Value)
                return "Group";
            if (type == Loop.Value)
                return "Loop";
            if (type == MultiStateInput.Value)
                return "Multi-state Input";
            if (type == MultiStateOutput.Value)
                return "Multi-state Output";
            if (type == NotificationClass.Value)
                return "Notification Class";
            if (type == Program.Value)
                return "Program";
            if (type == Schedule.Value)
                return "Schedule";
            if (type == Averaging.Value)
                return "Averaging";
            if (type == MultiStateValue.Value)
                return "Multi-state Value";
            if (type == TrendLog.Value)
                return "Trend Log";
            if (type == LifeSafetyPoint.Value)
                return "Life Safety Point";
            if (type == LifeSafetyZone.Value)
                return "Life Safety Zone";
            if (type == Accumulator.Value)
                return "Accumulator";
            if (type == PulseConverter.Value)
                return "Pulse Converter";
            if (type == EventLog.Value)
                return "Event Log";
            if (type == TrendLogMultiple.Value)
                return "Trend Log Multiple";
            if (type == LoadControl.Value)
                return "Load Control";
            if (type == StructuredView.Value)
                return "Structured View";
            if (type == AccessDoor.Value)
                return "Access Door";
            return "Vendor Specific (" + type + ")";
        }
    }
}

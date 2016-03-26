namespace BACnetDataTypes.Enumerated
{
    public class ObjectType : Primitive.Enumerated
    {
        public static readonly ObjectType analogInput = new ObjectType(0);
        public static readonly ObjectType analogOutput = new ObjectType(1);
        public static readonly ObjectType analogValue = new ObjectType(2);
        public static readonly ObjectType binaryInput = new ObjectType(3);
        public static readonly ObjectType binaryOutput = new ObjectType(4);
        public static readonly ObjectType binaryValue = new ObjectType(5);
        public static readonly ObjectType calendar = new ObjectType(6);
        public static readonly ObjectType command = new ObjectType(7);
        public static readonly ObjectType device = new ObjectType(8);
        public static readonly ObjectType eventEnrollment = new ObjectType(9);
        public static readonly ObjectType file = new ObjectType(10);
        public static readonly ObjectType group = new ObjectType(11);
        public static readonly ObjectType loop = new ObjectType(12);
        public static readonly ObjectType multiStateInput = new ObjectType(13);
        public static readonly ObjectType multiStateOutput = new ObjectType(14);
        public static readonly ObjectType notificationClass = new ObjectType(15);
        public static readonly ObjectType program = new ObjectType(16);
        public static readonly ObjectType schedule = new ObjectType(17);
        public static readonly ObjectType averaging = new ObjectType(18);
        public static readonly ObjectType multiStateValue = new ObjectType(19);
        public static readonly ObjectType trendLog = new ObjectType(20);
        public static readonly ObjectType lifeSafetyPoint = new ObjectType(21);
        public static readonly ObjectType lifeSafetyZone = new ObjectType(22);
        public static readonly ObjectType accumulator = new ObjectType(23);
        public static readonly ObjectType pulseConverter = new ObjectType(24);
        public static readonly ObjectType eventLog = new ObjectType(25);

        public static readonly ObjectType globalGroup = new ObjectType(26);

        public static readonly ObjectType trendLogMultiple = new ObjectType(27);
        public static readonly ObjectType loadControl = new ObjectType(28);
        public static readonly ObjectType structuredView = new ObjectType(29);
        public static readonly ObjectType accessDoor = new ObjectType(30);

        public static readonly ObjectType timer = new ObjectType(31);
        public static readonly ObjectType accessCredential = new ObjectType(32);
        public static readonly ObjectType accessPoint = new ObjectType(33);
        public static readonly ObjectType accessRights = new ObjectType(34);
        public static readonly ObjectType accessUser = new ObjectType(35);
        public static readonly ObjectType accessZone = new ObjectType(36);
        public static readonly ObjectType credentialDataInput = new ObjectType(37);
        public static readonly ObjectType networkSecurity = new ObjectType(38);
        public static readonly ObjectType bitStringValue = new ObjectType(39);
        public static readonly ObjectType characterStringValue = new ObjectType(40);
        public static readonly ObjectType datePatternValue = new ObjectType(41);
        public static readonly ObjectType dateValue = new ObjectType(42);
        public static readonly ObjectType dateTimePatternValue = new ObjectType(43);
        public static readonly ObjectType dateTimeValue = new ObjectType(44);
        public static readonly ObjectType integerValue = new ObjectType(45);
        public static readonly ObjectType largeAnalogValue = new ObjectType(46);
        public static readonly ObjectType octetStringValue = new ObjectType(47);
        public static readonly ObjectType positiveIntegerValue = new ObjectType(48);
        public static readonly ObjectType timePatternValue = new ObjectType(49);
        public static readonly ObjectType timeValue = new ObjectType(50);
        public static readonly ObjectType notificationForwarder = new ObjectType(51);
        public static readonly ObjectType alertEnrollment = new ObjectType(52);
        public static readonly ObjectType channel = new ObjectType(53);
        public static readonly ObjectType lightingOutput = new ObjectType(54);
        public static readonly ObjectType binaryLightingOutput = new ObjectType(55);
        public static readonly ObjectType networkPort = new ObjectType(56);

        public static readonly ObjectType[] ALL = { analogInput, analogOutput, analogValue, binaryInput, binaryOutput,
            binaryValue, calendar, command, device, eventEnrollment, file, group, loop, multiStateInput,
            multiStateOutput, notificationClass, program, schedule, averaging, multiStateValue, trendLog,
            lifeSafetyPoint, lifeSafetyZone, accumulator, pulseConverter, eventLog, trendLogMultiple, loadControl,
            structuredView, accessDoor, };

    public ObjectType(uint value) : base(value) { }

    public ObjectType(ByteStream queue) : base(queue) { }

    public override string ToString()
    {
        uint type = intValue();
        if (type == analogInput.intValue())
            return "Analog Input";
        if (type == analogOutput.intValue())
            return "Analog Output";
        if (type == analogValue.intValue())
            return "Analog Value";
        if (type == binaryInput.intValue())
            return "Binary Input";
        if (type == binaryOutput.intValue())
            return "Binary Output";
        if (type == binaryValue.intValue())
            return "Binary Value";
        if (type == calendar.intValue())
            return "Calendar";
        if (type == command.intValue())
            return "Command";
        if (type == device.intValue())
            return "Device";
        if (type == eventEnrollment.intValue())
            return "Event Enrollment";
        if (type == file.intValue())
            return "File";
        if (type == group.intValue())
            return "Group";
        if (type == loop.intValue())
            return "Loop";
        if (type == multiStateInput.intValue())
            return "Multi-state Input";
        if (type == multiStateOutput.intValue())
            return "Multi-state Output";
        if (type == notificationClass.intValue())
            return "Notification Class";
        if (type == program.intValue())
            return "Program";
        if (type == schedule.intValue())
            return "Schedule";
        if (type == averaging.intValue())
            return "Averaging";
        if (type == multiStateValue.intValue())
            return "Multi-state Value";
        if (type == trendLog.intValue())
            return "Trend Log";
        if (type == lifeSafetyPoint.intValue())
            return "Life Safety Point";
        if (type == lifeSafetyZone.intValue())
            return "Life Safety Zone";
        if (type == accumulator.intValue())
            return "Accumulator";
        if (type == pulseConverter.intValue())
            return "Pulse Converter";
        if (type == eventLog.intValue())
            return "Event Log";
        if (type == trendLogMultiple.intValue())
            return "Trend Log Multiple";
        if (type == loadControl.intValue())
            return "Load Control";
        if (type == structuredView.intValue())
            return "Structured View";
        if (type == accessDoor.intValue())
            return "Access Door";
        return "Vendor Specific (" + type + ")";
    }
}
    }

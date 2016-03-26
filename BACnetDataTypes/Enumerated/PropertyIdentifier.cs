using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Enumerated
{
    public class PropertyIdentifier : Primitive.Enumerated
    {
        public static readonly PropertyIdentifier AckedTransitions = new PropertyIdentifier(0);
        public static readonly PropertyIdentifier AckRequired = new PropertyIdentifier(1);
        public static readonly PropertyIdentifier Action = new PropertyIdentifier(2);
        public static readonly PropertyIdentifier ActionText = new PropertyIdentifier(3);
        public static readonly PropertyIdentifier ActiveText = new PropertyIdentifier(4);
        public static readonly PropertyIdentifier ActiveVtSessions = new PropertyIdentifier(5);
        public static readonly PropertyIdentifier AlarmValue = new PropertyIdentifier(6);
        public static readonly PropertyIdentifier AlarmValues = new PropertyIdentifier(7);
        public static readonly PropertyIdentifier all = new PropertyIdentifier(8);
        public static readonly PropertyIdentifier AllWritesSuccessful = new PropertyIdentifier(9);
        public static readonly PropertyIdentifier ApduSegmentTimeout = new PropertyIdentifier(10);
        public static readonly PropertyIdentifier ApduTimeout = new PropertyIdentifier(11);
        public static readonly PropertyIdentifier ApplicationSoftwareVersion = new PropertyIdentifier(12);
        public static readonly PropertyIdentifier Archive = new PropertyIdentifier(13);
        public static readonly PropertyIdentifier Bias = new PropertyIdentifier(14);
        public static readonly PropertyIdentifier ChangeOfStateCount = new PropertyIdentifier(15);
        public static readonly PropertyIdentifier ChangeOfStateTime = new PropertyIdentifier(16);
        public static readonly PropertyIdentifier NotificationClass = new PropertyIdentifier(17);
        public static readonly PropertyIdentifier ControlledVariableReference = new PropertyIdentifier(19);
        public static readonly PropertyIdentifier ControlledVariableUnits = new PropertyIdentifier(20);
        public static readonly PropertyIdentifier ControlledVariableValue = new PropertyIdentifier(21);
        public static readonly PropertyIdentifier CovIncrement = new PropertyIdentifier(22);
        public static readonly PropertyIdentifier DateList = new PropertyIdentifier(23);
        public static readonly PropertyIdentifier DaylightSavingsStatus = new PropertyIdentifier(24);
        public static readonly PropertyIdentifier Deadband = new PropertyIdentifier(25);
        public static readonly PropertyIdentifier DerivativeConstant = new PropertyIdentifier(26);
        public static readonly PropertyIdentifier DerivativeConstantUnits = new PropertyIdentifier(27);
        public static readonly PropertyIdentifier Description = new PropertyIdentifier(28);
        public static readonly PropertyIdentifier DescriptionOfHalt = new PropertyIdentifier(29);
        public static readonly PropertyIdentifier DeviceAddressBinding = new PropertyIdentifier(30);
        public static readonly PropertyIdentifier DeviceType = new PropertyIdentifier(31);
        public static readonly PropertyIdentifier EffectivePeriod = new PropertyIdentifier(32);
        public static readonly PropertyIdentifier ElapsedActiveTime = new PropertyIdentifier(33);
        public static readonly PropertyIdentifier ErrorLimit = new PropertyIdentifier(34);
        public static readonly PropertyIdentifier EventEnable = new PropertyIdentifier(35);
        public static readonly PropertyIdentifier EventState = new PropertyIdentifier(36);
        public static readonly PropertyIdentifier EventType = new PropertyIdentifier(37);
        public static readonly PropertyIdentifier ExceptionSchedule = new PropertyIdentifier(38);
        public static readonly PropertyIdentifier FaultValues = new PropertyIdentifier(39);
        public static readonly PropertyIdentifier FeedbackValue = new PropertyIdentifier(40);
        public static readonly PropertyIdentifier FileAccessMethod = new PropertyIdentifier(41);
        public static readonly PropertyIdentifier FileSize = new PropertyIdentifier(42);
        public static readonly PropertyIdentifier FileType = new PropertyIdentifier(43);
        public static readonly PropertyIdentifier FirmwareRevision = new PropertyIdentifier(44);
        public static readonly PropertyIdentifier HighLimit = new PropertyIdentifier(45);
        public static readonly PropertyIdentifier InactiveText = new PropertyIdentifier(46);
        public static readonly PropertyIdentifier InProcess = new PropertyIdentifier(47);
        public static readonly PropertyIdentifier InstanceOf = new PropertyIdentifier(48);
        public static readonly PropertyIdentifier IntegralConstant = new PropertyIdentifier(49);
        public static readonly PropertyIdentifier IntegralConstantUnits = new PropertyIdentifier(50);
        public static readonly PropertyIdentifier LimitEnable = new PropertyIdentifier(52);
        public static readonly PropertyIdentifier ListOfGroupMembers = new PropertyIdentifier(53);
        public static readonly PropertyIdentifier ListOfObjectPropertyReferences = new PropertyIdentifier(54);
        public static readonly PropertyIdentifier ListOfSessionKeys = new PropertyIdentifier(55);
        public static readonly PropertyIdentifier LocalDate = new PropertyIdentifier(56);
        public static readonly PropertyIdentifier LocalTime = new PropertyIdentifier(57);
        public static readonly PropertyIdentifier Location = new PropertyIdentifier(58);
        public static readonly PropertyIdentifier LowLimit = new PropertyIdentifier(59);
        public static readonly PropertyIdentifier ManipulatedVariableReference = new PropertyIdentifier(60);
        public static readonly PropertyIdentifier MaximumOutput = new PropertyIdentifier(61);
        public static readonly PropertyIdentifier MaxApduLengthAccepted = new PropertyIdentifier(62);
        public static readonly PropertyIdentifier MaxInfoFrames = new PropertyIdentifier(63);
        public static readonly PropertyIdentifier MaxMaster = new PropertyIdentifier(64);
        public static readonly PropertyIdentifier MaxPresValue = new PropertyIdentifier(65);
        public static readonly PropertyIdentifier MinimumOffTime = new PropertyIdentifier(66);
        public static readonly PropertyIdentifier MinimumOnTime = new PropertyIdentifier(67);
        public static readonly PropertyIdentifier MinimumOutput = new PropertyIdentifier(68);
        public static readonly PropertyIdentifier MinPresValue = new PropertyIdentifier(69);
        public static readonly PropertyIdentifier ModelName = new PropertyIdentifier(70);
        public static readonly PropertyIdentifier ModificationDate = new PropertyIdentifier(71);
        public static readonly PropertyIdentifier NotifyType = new PropertyIdentifier(72);
        public static readonly PropertyIdentifier NumberOfApduRetries = new PropertyIdentifier(73);
        public static readonly PropertyIdentifier NumberOfStates = new PropertyIdentifier(74);
        public static readonly PropertyIdentifier ObjectIdentifier = new PropertyIdentifier(75);
        public static readonly PropertyIdentifier ObjectList = new PropertyIdentifier(76);
        public static readonly PropertyIdentifier ObjectName = new PropertyIdentifier(77);
        public static readonly PropertyIdentifier ObjectPropertyReference = new PropertyIdentifier(78);
        public static readonly PropertyIdentifier ObjectType = new PropertyIdentifier(79);
        public static readonly PropertyIdentifier Optional = new PropertyIdentifier(80);
        public static readonly PropertyIdentifier OutOfService = new PropertyIdentifier(81);
        public static readonly PropertyIdentifier OutputUnits = new PropertyIdentifier(82);
        public static readonly PropertyIdentifier EventParameters = new PropertyIdentifier(83);
        public static readonly PropertyIdentifier Polarity = new PropertyIdentifier(84);
        public static readonly PropertyIdentifier PresentValue = new PropertyIdentifier(85);
        public static readonly PropertyIdentifier Priority = new PropertyIdentifier(86);
        public static readonly PropertyIdentifier PriorityArray = new PropertyIdentifier(87);
        public static readonly PropertyIdentifier PriorityForWriting = new PropertyIdentifier(88);
        public static readonly PropertyIdentifier ProcessIdentifier = new PropertyIdentifier(89);
        public static readonly PropertyIdentifier ProgramChange = new PropertyIdentifier(90);
        public static readonly PropertyIdentifier ProgramLocation = new PropertyIdentifier(91);
        public static readonly PropertyIdentifier ProgramState = new PropertyIdentifier(92);
        public static readonly PropertyIdentifier ProportionalConstant = new PropertyIdentifier(93);
        public static readonly PropertyIdentifier ProportionalConstantUnits = new PropertyIdentifier(94);
        public static readonly PropertyIdentifier ProtocolObjectTypesSupported = new PropertyIdentifier(96);
        public static readonly PropertyIdentifier ProtocolServicesSupported = new PropertyIdentifier(97);
        public static readonly PropertyIdentifier ProtocolVersion = new PropertyIdentifier(98);
        public static readonly PropertyIdentifier ReadOnly = new PropertyIdentifier(99);
        public static readonly PropertyIdentifier ReasonForHalt = new PropertyIdentifier(100);
        public static readonly PropertyIdentifier RecipientList = new PropertyIdentifier(102);
        public static readonly PropertyIdentifier Reliability = new PropertyIdentifier(103);
        public static readonly PropertyIdentifier RelinquishDefault = new PropertyIdentifier(104);
        public static readonly PropertyIdentifier Required = new PropertyIdentifier(105);
        public static readonly PropertyIdentifier Resolution = new PropertyIdentifier(106);
        public static readonly PropertyIdentifier SegmentationSupported = new PropertyIdentifier(107);
        public static readonly PropertyIdentifier Setpoint = new PropertyIdentifier(108);
        public static readonly PropertyIdentifier SetpointReference = new PropertyIdentifier(109);
        public static readonly PropertyIdentifier StateText = new PropertyIdentifier(110);
        public static readonly PropertyIdentifier StatusFlags = new PropertyIdentifier(111);
        public static readonly PropertyIdentifier SystemStatus = new PropertyIdentifier(112);
        public static readonly PropertyIdentifier TimeDelay = new PropertyIdentifier(113);
        public static readonly PropertyIdentifier TimeOfActiveTimeReset = new PropertyIdentifier(114);
        public static readonly PropertyIdentifier TimeOfStateCountReset = new PropertyIdentifier(115);
        public static readonly PropertyIdentifier TimeSynchronizationRecipients = new PropertyIdentifier(116);
        public static readonly PropertyIdentifier Units = new PropertyIdentifier(117);
        public static readonly PropertyIdentifier UpdateInterval = new PropertyIdentifier(118);
        public static readonly PropertyIdentifier UtcOffset = new PropertyIdentifier(119);
        public static readonly PropertyIdentifier VendorIdentifier = new PropertyIdentifier(120);
        public static readonly PropertyIdentifier VendorName = new PropertyIdentifier(121);
        public static readonly PropertyIdentifier VtClassesSupported = new PropertyIdentifier(122);
        public static readonly PropertyIdentifier WeeklySchedule = new PropertyIdentifier(123);
        public static readonly PropertyIdentifier AttemptedSamples = new PropertyIdentifier(124);
        public static readonly PropertyIdentifier AverageValue = new PropertyIdentifier(125);
        public static readonly PropertyIdentifier BufferSize = new PropertyIdentifier(126);
        public static readonly PropertyIdentifier ClientCovIncrement = new PropertyIdentifier(127);
        public static readonly PropertyIdentifier CovResubscriptionInterval = new PropertyIdentifier(128);
        public static readonly PropertyIdentifier EventTimeStamps = new PropertyIdentifier(130);
        public static readonly PropertyIdentifier LogBuffer = new PropertyIdentifier(131);
        public static readonly PropertyIdentifier LogDeviceObjectProperty = new PropertyIdentifier(132);
        public static readonly PropertyIdentifier Enable = new PropertyIdentifier(133);
        public static readonly PropertyIdentifier LogInterval = new PropertyIdentifier(134);
        public static readonly PropertyIdentifier MaximumValue = new PropertyIdentifier(135);
        public static readonly PropertyIdentifier MinimumValue = new PropertyIdentifier(136);
        public static readonly PropertyIdentifier NotificationThreshold = new PropertyIdentifier(137);
        public static readonly PropertyIdentifier ProtocolRevision = new PropertyIdentifier(139);
        public static readonly PropertyIdentifier RecordsSinceNotification = new PropertyIdentifier(140);
        public static readonly PropertyIdentifier RecordCount = new PropertyIdentifier(141);
        public static readonly PropertyIdentifier StartTime = new PropertyIdentifier(142);
        public static readonly PropertyIdentifier StopTime = new PropertyIdentifier(143);
        public static readonly PropertyIdentifier StopWhenFull = new PropertyIdentifier(144);
        public static readonly PropertyIdentifier TotalRecordCount = new PropertyIdentifier(145);
        public static readonly PropertyIdentifier ValidSamples = new PropertyIdentifier(146);
        public static readonly PropertyIdentifier WindowInterval = new PropertyIdentifier(147);
        public static readonly PropertyIdentifier WindowSamples = new PropertyIdentifier(148);
        public static readonly PropertyIdentifier MaximumValueTimestamp = new PropertyIdentifier(149);
        public static readonly PropertyIdentifier MinimumValueTimestamp = new PropertyIdentifier(150);
        public static readonly PropertyIdentifier VarianceValue = new PropertyIdentifier(151);
        public static readonly PropertyIdentifier ActiveCovSubscriptions = new PropertyIdentifier(152);
        public static readonly PropertyIdentifier BackupFailureTimeout = new PropertyIdentifier(153);
        public static readonly PropertyIdentifier ConfigurationFiles = new PropertyIdentifier(154);
        public static readonly PropertyIdentifier DatabaseRevision = new PropertyIdentifier(155);
        public static readonly PropertyIdentifier DirectReading = new PropertyIdentifier(156);
        public static readonly PropertyIdentifier LastRestoreTime = new PropertyIdentifier(157);
        public static readonly PropertyIdentifier MaintenanceRequired = new PropertyIdentifier(158);
        public static readonly PropertyIdentifier MemberOf = new PropertyIdentifier(159);
        public static readonly PropertyIdentifier Mode = new PropertyIdentifier(160);
        public static readonly PropertyIdentifier OperationExpected = new PropertyIdentifier(161);
        public static readonly PropertyIdentifier Setting = new PropertyIdentifier(162);
        public static readonly PropertyIdentifier Silenced = new PropertyIdentifier(163);
        public static readonly PropertyIdentifier TrackingValue = new PropertyIdentifier(164);
        public static readonly PropertyIdentifier ZoneMembers = new PropertyIdentifier(165);
        public static readonly PropertyIdentifier LifeSafetyAlarmValues = new PropertyIdentifier(166);
        public static readonly PropertyIdentifier MaxSegmentsAccepted = new PropertyIdentifier(167);
        public static readonly PropertyIdentifier ProfileName = new PropertyIdentifier(168);
        public static readonly PropertyIdentifier AutoSlaveDiscovery = new PropertyIdentifier(169);
        public static readonly PropertyIdentifier ManualSlaveAddressBinding = new PropertyIdentifier(170);
        public static readonly PropertyIdentifier SlaveAddressBinding = new PropertyIdentifier(171);
        public static readonly PropertyIdentifier SlaveProxyEnable = new PropertyIdentifier(172);
        public static readonly PropertyIdentifier LastNotifyRecord = new PropertyIdentifier(173);
        public static readonly PropertyIdentifier ScheduleDefault = new PropertyIdentifier(174);
        public static readonly PropertyIdentifier AcceptedModes = new PropertyIdentifier(175);
        public static readonly PropertyIdentifier AdjustValue = new PropertyIdentifier(176);
        public static readonly PropertyIdentifier Count = new PropertyIdentifier(177);
        public static readonly PropertyIdentifier CountBeforeChange = new PropertyIdentifier(178);
        public static readonly PropertyIdentifier CountChangeTime = new PropertyIdentifier(179);
        public static readonly PropertyIdentifier CovPeriod = new PropertyIdentifier(180);
        public static readonly PropertyIdentifier InputReference = new PropertyIdentifier(181);
        public static readonly PropertyIdentifier LimitMonitoringInterval = new PropertyIdentifier(182);
        public static readonly PropertyIdentifier LoggingObject = new PropertyIdentifier(183);
        public static readonly PropertyIdentifier LoggingRecord = new PropertyIdentifier(184);
        public static readonly PropertyIdentifier Prescale = new PropertyIdentifier(185);
        public static readonly PropertyIdentifier PulseRate = new PropertyIdentifier(186);
        public static readonly PropertyIdentifier Scale = new PropertyIdentifier(187);
        public static readonly PropertyIdentifier ScaleFactor = new PropertyIdentifier(188);
        public static readonly PropertyIdentifier UpdateTime = new PropertyIdentifier(189);
        public static readonly PropertyIdentifier ValueBeforeChange = new PropertyIdentifier(190);
        public static readonly PropertyIdentifier ValueSet = new PropertyIdentifier(191);
        public static readonly PropertyIdentifier ValueChangeTime = new PropertyIdentifier(192);
        public static readonly PropertyIdentifier AlignIntervals = new PropertyIdentifier(193);
        public static readonly PropertyIdentifier IntervalOffset = new PropertyIdentifier(195);
        public static readonly PropertyIdentifier LastRestartReason = new PropertyIdentifier(196);
        public static readonly PropertyIdentifier LoggingType = new PropertyIdentifier(197);
        public static readonly PropertyIdentifier RestartNotificationRecipients = new PropertyIdentifier(202);
        public static readonly PropertyIdentifier TimeOfDeviceRestart = new PropertyIdentifier(203);
        public static readonly PropertyIdentifier TimeSynchronizationInterval = new PropertyIdentifier(204);
        public static readonly PropertyIdentifier Trigger = new PropertyIdentifier(205);
        public static readonly PropertyIdentifier UtcTimeSynchronizationRecipients = new PropertyIdentifier(206);
        public static readonly PropertyIdentifier NodeSubtype = new PropertyIdentifier(207);
        public static readonly PropertyIdentifier NodeType = new PropertyIdentifier(208);
        public static readonly PropertyIdentifier StructuredObjectList = new PropertyIdentifier(209);
        public static readonly PropertyIdentifier SubordinateAnnotations = new PropertyIdentifier(210);
        public static readonly PropertyIdentifier SubordinateList = new PropertyIdentifier(211);
        public static readonly PropertyIdentifier ActualShedLevel = new PropertyIdentifier(212);
        public static readonly PropertyIdentifier DutyWindow = new PropertyIdentifier(213);
        public static readonly PropertyIdentifier ExpectedShedLevel = new PropertyIdentifier(214);
        public static readonly PropertyIdentifier FullDutyBaseline = new PropertyIdentifier(215);
        public static readonly PropertyIdentifier RequestedShedLevel = new PropertyIdentifier(218);
        public static readonly PropertyIdentifier ShedDuration = new PropertyIdentifier(219);
        public static readonly PropertyIdentifier ShedLevelDescriptions = new PropertyIdentifier(220);
        public static readonly PropertyIdentifier ShedLevels = new PropertyIdentifier(221);
        public static readonly PropertyIdentifier StateDescription = new PropertyIdentifier(222);
        public static readonly PropertyIdentifier DoorAlarmState = new PropertyIdentifier(226);
        public static readonly PropertyIdentifier DoorExtendedPulseTime = new PropertyIdentifier(227);
        public static readonly PropertyIdentifier DoorMembers = new PropertyIdentifier(228);
        public static readonly PropertyIdentifier DoorOpenTooLongTime = new PropertyIdentifier(229);
        public static readonly PropertyIdentifier DoorPulseTime = new PropertyIdentifier(230);
        public static readonly PropertyIdentifier DoorStatus = new PropertyIdentifier(231);
        public static readonly PropertyIdentifier DoorUnlockDelayTime = new PropertyIdentifier(232);
        public static readonly PropertyIdentifier LockStatus = new PropertyIdentifier(233);
        public static readonly PropertyIdentifier MaskedAlarmValues = new PropertyIdentifier(234);
        public static readonly PropertyIdentifier SecuredStatus = new PropertyIdentifier(235);
        public static readonly PropertyIdentifier BackupAndRestoreState = new PropertyIdentifier(338);
        public static readonly PropertyIdentifier BackupPreparationTime = new PropertyIdentifier(339);
        public static readonly PropertyIdentifier RestoreCompletionTime = new PropertyIdentifier(340);
        public static readonly PropertyIdentifier RestorePreparationTime = new PropertyIdentifier(341);

        public static readonly PropertyIdentifier[] All = { AckedTransitions, AckRequired, Action, ActionText, ActiveText,
            ActiveVtSessions, AlarmValue, AlarmValues, all, AllWritesSuccessful, ApduSegmentTimeout, ApduTimeout,
            ApplicationSoftwareVersion, Archive, Bias, ChangeOfStateCount, ChangeOfStateTime, NotificationClass,
            ControlledVariableReference, ControlledVariableUnits, ControlledVariableValue, CovIncrement, DateList,
            DaylightSavingsStatus, Deadband, DerivativeConstant, DerivativeConstantUnits, Description,
            DescriptionOfHalt, DeviceAddressBinding, DeviceType, EffectivePeriod, ElapsedActiveTime, ErrorLimit,
            EventEnable, EventState, EventType, ExceptionSchedule, FaultValues, FeedbackValue, FileAccessMethod,
            FileSize, FileType, FirmwareRevision, HighLimit, InactiveText, InProcess, InstanceOf, IntegralConstant,
            IntegralConstantUnits, LimitEnable, ListOfGroupMembers, ListOfObjectPropertyReferences, ListOfSessionKeys,
            LocalDate, LocalTime, Location, LowLimit, ManipulatedVariableReference, MaximumOutput,
            MaxApduLengthAccepted, MaxInfoFrames, MaxMaster, MaxPresValue, MinimumOffTime, MinimumOnTime,
            MinimumOutput, MinPresValue, ModelName, ModificationDate, NotifyType, NumberOfApduRetries, NumberOfStates,
            ObjectIdentifier, ObjectList, ObjectName, ObjectPropertyReference, ObjectType, Optional, OutOfService,
            OutputUnits, EventParameters, Polarity, PresentValue, Priority, PriorityArray, PriorityForWriting,
            ProcessIdentifier, ProgramChange, ProgramLocation, ProgramState, ProportionalConstant,
            ProportionalConstantUnits, ProtocolObjectTypesSupported, ProtocolServicesSupported, ProtocolVersion,
            ReadOnly, ReasonForHalt, RecipientList, Reliability, RelinquishDefault, Required, Resolution,
            SegmentationSupported, Setpoint, SetpointReference, StateText, StatusFlags, SystemStatus, TimeDelay,
            TimeOfActiveTimeReset, TimeOfStateCountReset, TimeSynchronizationRecipients, Units, UpdateInterval,
            UtcOffset, VendorIdentifier, VendorName, VtClassesSupported, WeeklySchedule, AttemptedSamples,
            AverageValue, BufferSize, ClientCovIncrement, CovResubscriptionInterval, EventTimeStamps, LogBuffer,
            LogDeviceObjectProperty, Enable, LogInterval, MaximumValue, MinimumValue, NotificationThreshold,
            ProtocolRevision, RecordsSinceNotification, RecordCount, StartTime, StopTime, StopWhenFull,
            TotalRecordCount, ValidSamples, WindowInterval, WindowSamples, MaximumValueTimestamp,
            MinimumValueTimestamp, VarianceValue, ActiveCovSubscriptions, BackupFailureTimeout, ConfigurationFiles,
            DatabaseRevision, DirectReading, LastRestoreTime, MaintenanceRequired, MemberOf, Mode, OperationExpected,
            Setting, Silenced, TrackingValue, ZoneMembers, LifeSafetyAlarmValues, MaxSegmentsAccepted, ProfileName,
            AutoSlaveDiscovery, ManualSlaveAddressBinding, SlaveAddressBinding, SlaveProxyEnable, LastNotifyRecord,
            ScheduleDefault, AcceptedModes, AdjustValue, Count, CountBeforeChange, CountChangeTime, CovPeriod,
            InputReference, LimitMonitoringInterval, LoggingObject, LoggingRecord, Prescale, PulseRate, Scale,
            ScaleFactor, UpdateTime, ValueBeforeChange, ValueSet, ValueChangeTime, AlignIntervals, IntervalOffset,
            LastRestartReason, LoggingType, RestartNotificationRecipients, TimeOfDeviceRestart,
            TimeSynchronizationInterval, Trigger, UtcTimeSynchronizationRecipients, NodeSubtype, NodeType,
            StructuredObjectList, SubordinateAnnotations, SubordinateList, ActualShedLevel, DutyWindow,
            ExpectedShedLevel, FullDutyBaseline, RequestedShedLevel, ShedDuration, ShedLevelDescriptions, ShedLevels,
            StateDescription, DoorAlarmState, DoorExtendedPulseTime, DoorMembers, DoorOpenTooLongTime, DoorPulseTime,
            DoorStatus, DoorUnlockDelayTime, LockStatus, MaskedAlarmValues, SecuredStatus, BackupAndRestoreState,
            BackupPreparationTime, RestoreCompletionTime, RestorePreparationTime, };

    public PropertyIdentifier(uint value) : base(value) { }

    public PropertyIdentifier(ByteStream queue) : base(queue) { }

        public override string ToString()
    {
        uint type = ((UnsignedInteger) this).Value;
        if (type == ((UnsignedInteger) AckedTransitions).Value)
            return "Acked transitions";
        if (type == ((UnsignedInteger) AckRequired).Value)
            return "Ack required";
        if (type == ((UnsignedInteger) Action).Value)
            return "Action";
        if (type == ((UnsignedInteger) ActionText).Value)
            return "Action text";
        if (type == ((UnsignedInteger) ActiveText).Value)
            return "Active text";
        if (type == ((UnsignedInteger) ActiveVtSessions).Value)
            return "Active VT sessions";
        if (type == ((UnsignedInteger) AlarmValue).Value)
            return "Alarm value";
        if (type == ((UnsignedInteger) AlarmValues).Value)
            return "Alarm values";
        if (type == ((UnsignedInteger) all).Value)
            return "All";
        if (type == ((UnsignedInteger) AllWritesSuccessful).Value)
            return "All writes successful";
        if (type == ((UnsignedInteger) ApduSegmentTimeout).Value)
            return "APDU segment timeout";
        if (type == ((UnsignedInteger) ApduTimeout).Value)
            return "APDU timeout";
        if (type == ((UnsignedInteger) ApplicationSoftwareVersion).Value)
            return "Application software version";
        if (type == ((UnsignedInteger) Archive).Value)
            return "Archive";
        if (type == ((UnsignedInteger) Bias).Value)
            return "Bias";
        if (type == ((UnsignedInteger) ChangeOfStateCount).Value)
            return "Change of state count";
        if (type == ((UnsignedInteger) ChangeOfStateTime).Value)
            return "Change of state time";
        if (type == ((UnsignedInteger) NotificationClass).Value)
            return "Notification class";
        if (type == ((UnsignedInteger) ControlledVariableReference).Value)
            return "Controlled variable reference";
        if (type == ((UnsignedInteger) ControlledVariableUnits).Value)
            return "Controlled variable units";
        if (type == ((UnsignedInteger) ControlledVariableValue).Value)
            return "Controlled variable value";
        if (type == ((UnsignedInteger) CovIncrement).Value)
            return "COV increment";
        if (type == ((UnsignedInteger) DateList).Value)
            return "Date list";
        if (type == ((UnsignedInteger) DaylightSavingsStatus).Value)
            return "Daylight savings status";
        if (type == ((UnsignedInteger) Deadband).Value)
            return "Deadband";
        if (type == ((UnsignedInteger) DerivativeConstant).Value)
            return "Derivative constant";
        if (type == ((UnsignedInteger) DerivativeConstantUnits).Value)
            return "Derivative constant units";
        if (type == ((UnsignedInteger) Description).Value)
            return "Description";
        if (type == ((UnsignedInteger) DescriptionOfHalt).Value)
            return "Description of halt";
        if (type == ((UnsignedInteger) DeviceAddressBinding).Value)
            return "Device address binding";
        if (type == ((UnsignedInteger) DeviceType).Value)
            return "Device type";
        if (type == ((UnsignedInteger) EffectivePeriod).Value)
            return "Effective period";
        if (type == ((UnsignedInteger) ElapsedActiveTime).Value)
            return "Elapsed active time";
        if (type == ((UnsignedInteger) ErrorLimit).Value)
            return "Error limit";
        if (type == ((UnsignedInteger) EventEnable).Value)
            return "Event enable";
        if (type == ((UnsignedInteger) EventState).Value)
            return "Event state";
        if (type == ((UnsignedInteger) EventType).Value)
            return "Event type";
        if (type == ((UnsignedInteger) ExceptionSchedule).Value)
            return "Exception schedule";
        if (type == ((UnsignedInteger) FaultValues).Value)
            return "Fault values";
        if (type == ((UnsignedInteger) FeedbackValue).Value)
            return "Feedback value";
        if (type == ((UnsignedInteger) FileAccessMethod).Value)
            return "File access method";
        if (type == ((UnsignedInteger) FileSize).Value)
            return "File size";
        if (type == ((UnsignedInteger) FileType).Value)
            return "File type";
        if (type == ((UnsignedInteger) FirmwareRevision).Value)
            return "Firmware revision";
        if (type == ((UnsignedInteger) HighLimit).Value)
            return "High limit";
        if (type == ((UnsignedInteger) InactiveText).Value)
            return "Inactive text";
        if (type == ((UnsignedInteger) InProcess).Value)
            return "In process";
        if (type == ((UnsignedInteger) InstanceOf).Value)
            return "Instance of";
        if (type == ((UnsignedInteger) IntegralConstant).Value)
            return "Integral constant";
        if (type == ((UnsignedInteger) IntegralConstantUnits).Value)
            return "Integral constant units";
        if (type == ((UnsignedInteger) LimitEnable).Value)
            return "Limit enable";
        if (type == ((UnsignedInteger) ListOfGroupMembers).Value)
            return "List of group members";
        if (type == ((UnsignedInteger) ListOfObjectPropertyReferences).Value)
            return "List of object property references";
        if (type == ((UnsignedInteger) ListOfSessionKeys).Value)
            return "List of session keys";
        if (type == ((UnsignedInteger) LocalDate).Value)
            return "Local date";
        if (type == ((UnsignedInteger) LocalTime).Value)
            return "Local time";
        if (type == ((UnsignedInteger) Location).Value)
            return "Location";
        if (type == ((UnsignedInteger) LowLimit).Value)
            return "Low limit";
        if (type == ((UnsignedInteger) ManipulatedVariableReference).Value)
            return "Manipulated variable reference";
        if (type == ((UnsignedInteger) MaximumOutput).Value)
            return "Maximum output";
        if (type == ((UnsignedInteger) MaxApduLengthAccepted).Value)
            return "Max APDU length accepted";
        if (type == ((UnsignedInteger) MaxInfoFrames).Value)
            return "Max info frames";
        if (type == ((UnsignedInteger) MaxMaster).Value)
            return "Max master";
        if (type == ((UnsignedInteger) MaxPresValue).Value)
            return "Max pres value";
        if (type == ((UnsignedInteger) MinimumOffTime).Value)
            return "Minimum off time";
        if (type == ((UnsignedInteger) MinimumOnTime).Value)
            return "Minimum on time";
        if (type == ((UnsignedInteger) MinimumOutput).Value)
            return "Minimum output";
        if (type == ((UnsignedInteger) MinPresValue).Value)
            return "Min pres value";
        if (type == ((UnsignedInteger) ModelName).Value)
            return "Model name";
        if (type == ((UnsignedInteger) ModificationDate).Value)
            return "Modification date";
        if (type == ((UnsignedInteger) NotifyType).Value)
            return "Notify type";
        if (type == ((UnsignedInteger) NumberOfApduRetries).Value)
            return "Number of APDU retries";
        if (type == ((UnsignedInteger) NumberOfStates).Value)
            return "Number of states";
        if (type == ((UnsignedInteger) ObjectIdentifier).Value)
            return "Object identifier";
        if (type == ((UnsignedInteger) ObjectList).Value)
            return "Object list";
        if (type == ((UnsignedInteger) ObjectName).Value)
            return "Object name";
        if (type == ((UnsignedInteger) ObjectPropertyReference).Value)
            return "Object property reference";
        if (type == ((UnsignedInteger) ObjectType).Value)
            return "Object type";
        if (type == ((UnsignedInteger) Optional).Value)
            return "Optional";
        if (type == ((UnsignedInteger) OutOfService).Value)
            return "Out of service";
        if (type == ((UnsignedInteger) OutputUnits).Value)
            return "Output units";
        if (type == ((UnsignedInteger) EventParameters).Value)
            return "Event parameters";
        if (type == ((UnsignedInteger) Polarity).Value)
            return "Polarity";
        if (type == ((UnsignedInteger) PresentValue).Value)
            return "Present value";
        if (type == ((UnsignedInteger) Priority).Value)
            return "Priority";
        if (type == ((UnsignedInteger) PriorityArray).Value)
            return "Priority array";
        if (type == ((UnsignedInteger) PriorityForWriting).Value)
            return "Priority for writing";
        if (type == ((UnsignedInteger) ProcessIdentifier).Value)
            return "Process identifier";
        if (type == ((UnsignedInteger) ProgramChange).Value)
            return "Program change";
        if (type == ((UnsignedInteger) ProgramLocation).Value)
            return "Program location";
        if (type == ((UnsignedInteger) ProgramState).Value)
            return "Program state";
        if (type == ((UnsignedInteger) ProportionalConstant).Value)
            return "Proportional constant";
        if (type == ((UnsignedInteger) ProportionalConstantUnits).Value)
            return "Proportional constant units";
        if (type == ((UnsignedInteger) ProtocolObjectTypesSupported).Value)
            return "Protocol object types supported";
        if (type == ((UnsignedInteger) ProtocolServicesSupported).Value)
            return "Protocol services supported";
        if (type == ((UnsignedInteger) ProtocolVersion).Value)
            return "Protocol version";
        if (type == ((UnsignedInteger) ReadOnly).Value)
            return "Read only";
        if (type == ((UnsignedInteger) ReasonForHalt).Value)
            return "Reason for halt";
        if (type == ((UnsignedInteger) RecipientList).Value)
            return "Recipient list";
        if (type == ((UnsignedInteger) Reliability).Value)
            return "Reliability";
        if (type == ((UnsignedInteger) RelinquishDefault).Value)
            return "Relinquish default";
        if (type == ((UnsignedInteger) Required).Value)
            return "Required";
        if (type == ((UnsignedInteger) Resolution).Value)
            return "Resolution";
        if (type == ((UnsignedInteger) SegmentationSupported).Value)
            return "Segmentation supported";
        if (type == ((UnsignedInteger) Setpoint).Value)
            return "Setpoint";
        if (type == ((UnsignedInteger) SetpointReference).Value)
            return "Setpoint reference";
        if (type == ((UnsignedInteger) StateText).Value)
            return "State text";
        if (type == ((UnsignedInteger) StatusFlags).Value)
            return "Status flags";
        if (type == ((UnsignedInteger) SystemStatus).Value)
            return "System status";
        if (type == ((UnsignedInteger) TimeDelay).Value)
            return "Time delay";
        if (type == ((UnsignedInteger) TimeOfActiveTimeReset).Value)
            return "Time of active time reset";
        if (type == ((UnsignedInteger) TimeOfStateCountReset).Value)
            return "Time of state count reset";
        if (type == ((UnsignedInteger) TimeSynchronizationRecipients).Value)
            return "Time synchronization recipients";
        if (type == ((UnsignedInteger) Units).Value)
            return "Units";
        if (type == ((UnsignedInteger) UpdateInterval).Value)
            return "Update interval";
        if (type == ((UnsignedInteger) UtcOffset).Value)
            return "UTC offset";
        if (type == ((UnsignedInteger) VendorIdentifier).Value)
            return "Vendor identifier";
        if (type == ((UnsignedInteger) VendorName).Value)
            return "Vendor name";
        if (type == ((UnsignedInteger) VtClassesSupported).Value)
            return "VT classes supported";
        if (type == ((UnsignedInteger) WeeklySchedule).Value)
            return "Weekly schedule";
        if (type == ((UnsignedInteger) AttemptedSamples).Value)
            return "Attempted samples";
        if (type == ((UnsignedInteger) AverageValue).Value)
            return "Average value";
        if (type == ((UnsignedInteger) BufferSize).Value)
            return "Buffer size";
        if (type == ((UnsignedInteger) ClientCovIncrement).Value)
            return "Client COV increment";
        if (type == ((UnsignedInteger) CovResubscriptionInterval).Value)
            return "COV resubscription interval";
        if (type == ((UnsignedInteger) EventTimeStamps).Value)
            return "Event time stamps";
        if (type == ((UnsignedInteger) LogBuffer).Value)
            return "Log buffer";
        if (type == ((UnsignedInteger) LogDeviceObjectProperty).Value)
            return "Log device object property";
        if (type == ((UnsignedInteger) Enable).Value)
            return "enable";
        if (type == ((UnsignedInteger) LogInterval).Value)
            return "Log interval";
        if (type == ((UnsignedInteger) MaximumValue).Value)
            return "Maximum value";
        if (type == ((UnsignedInteger) MinimumValue).Value)
            return "Minimum value";
        if (type == ((UnsignedInteger) NotificationThreshold).Value)
            return "Notification threshold";
        if (type == ((UnsignedInteger) ProtocolRevision).Value)
            return "Protocol revision";
        if (type == ((UnsignedInteger) RecordsSinceNotification).Value)
            return "Records since notification";
        if (type == ((UnsignedInteger) RecordCount).Value)
            return "Record count";
        if (type == ((UnsignedInteger) StartTime).Value)
            return "Start time";
        if (type == ((UnsignedInteger) StopTime).Value)
            return "Stop time";
        if (type == ((UnsignedInteger) StopWhenFull).Value)
            return "Stop when full";
        if (type == ((UnsignedInteger) TotalRecordCount).Value)
            return "Total record count";
        if (type == ((UnsignedInteger) ValidSamples).Value)
            return "Valid samples";
        if (type == ((UnsignedInteger) WindowInterval).Value)
            return "Window interval";
        if (type == ((UnsignedInteger) WindowSamples).Value)
            return "Window samples";
        if (type == ((UnsignedInteger) MaximumValueTimestamp).Value)
            return "Maximum value timestamp";
        if (type == ((UnsignedInteger) MinimumValueTimestamp).Value)
            return "Minimum value timestamp";
        if (type == ((UnsignedInteger) VarianceValue).Value)
            return "Variance value";
        if (type == ((UnsignedInteger) ActiveCovSubscriptions).Value)
            return "Active COV subscriptions";
        if (type == ((UnsignedInteger) BackupFailureTimeout).Value)
            return "Backup failure timeout";
        if (type == ((UnsignedInteger) ConfigurationFiles).Value)
            return "Configuration files";
        if (type == ((UnsignedInteger) DatabaseRevision).Value)
            return "Database revision";
        if (type == ((UnsignedInteger) DirectReading).Value)
            return "Direct reading";
        if (type == ((UnsignedInteger) LastRestoreTime).Value)
            return "Last restore time";
        if (type == ((UnsignedInteger) MaintenanceRequired).Value)
            return "Maintenance required";
        if (type == ((UnsignedInteger) MemberOf).Value)
            return "Member of";
        if (type == ((UnsignedInteger) Mode).Value)
            return "Mode";
        if (type == ((UnsignedInteger) OperationExpected).Value)
            return "Operation expected";
        if (type == ((UnsignedInteger) Setting).Value)
            return "Setting";
        if (type == ((UnsignedInteger) Silenced).Value)
            return "Silenced";
        if (type == ((UnsignedInteger) TrackingValue).Value)
            return "Tracking value";
        if (type == ((UnsignedInteger) ZoneMembers).Value)
            return "Zone members";
        if (type == ((UnsignedInteger) LifeSafetyAlarmValues).Value)
            return "Life safety alarm values";
        if (type == ((UnsignedInteger) MaxSegmentsAccepted).Value)
            return "Max segments accepted";
        if (type == ((UnsignedInteger) ProfileName).Value)
            return "Profile name";
        if (type == ((UnsignedInteger) AutoSlaveDiscovery).Value)
            return "Auto slave discovery";
        if (type == ((UnsignedInteger) ManualSlaveAddressBinding).Value)
            return "Manual slave address binding";
        if (type == ((UnsignedInteger) SlaveAddressBinding).Value)
            return "Slave address binding";
        if (type == ((UnsignedInteger) SlaveProxyEnable).Value)
            return "Slave proxy enable";
        if (type == ((UnsignedInteger) LastNotifyRecord).Value)
            return "Last notify record";
        if (type == ((UnsignedInteger) ScheduleDefault).Value)
            return "Schedule default";
        if (type == ((UnsignedInteger) AcceptedModes).Value)
            return "Accepted modes";
        if (type == ((UnsignedInteger) AdjustValue).Value)
            return "Adjust value";
        if (type == ((UnsignedInteger) Count).Value)
            return "Count";
        if (type == ((UnsignedInteger) CountBeforeChange).Value)
            return "Count before change";
        if (type == ((UnsignedInteger) CountChangeTime).Value)
            return "Count change time";
        if (type == ((UnsignedInteger) CovPeriod).Value)
            return "COV period";
        if (type == ((UnsignedInteger) InputReference).Value)
            return "Input reference";
        if (type == ((UnsignedInteger) LimitMonitoringInterval).Value)
            return "Limit monitoring interval";
        if (type == ((UnsignedInteger) LoggingObject).Value)
            return "Logging object";
        if (type == ((UnsignedInteger) LoggingRecord).Value)
            return "Logging record";
        if (type == ((UnsignedInteger) Prescale).Value)
            return "Prescale";
        if (type == ((UnsignedInteger) PulseRate).Value)
            return "Pulse rate";
        if (type == ((UnsignedInteger) Scale).Value)
            return "Scale";
        if (type == ((UnsignedInteger) ScaleFactor).Value)
            return "Scale factor";
        if (type == ((UnsignedInteger) UpdateTime).Value)
            return "Update time";
        if (type == ((UnsignedInteger) ValueBeforeChange).Value)
            return "Value before change";
        if (type == ((UnsignedInteger) ValueSet).Value)
            return "Value set";
        if (type == ((UnsignedInteger) ValueChangeTime).Value)
            return "Value change time";
        if (type == ((UnsignedInteger) AlignIntervals).Value)
            return "Align Intervals";
        if (type == ((UnsignedInteger) IntervalOffset).Value)
            return "Interval Offset";
        if (type == ((UnsignedInteger) LastRestartReason).Value)
            return "Last Restart Reason";
        if (type == ((UnsignedInteger) LoggingType).Value)
            return "Logging Type";
        if (type == ((UnsignedInteger) RestartNotificationRecipients).Value)
            return "Restart Notification Recipients";
        if (type == ((UnsignedInteger) TimeOfDeviceRestart).Value)
            return "Time Of Device Restart";
        if (type == ((UnsignedInteger) TimeSynchronizationInterval).Value)
            return "Time Synchronization Interval";
        if (type == ((UnsignedInteger) Trigger).Value)
            return "Trigger";
        if (type == ((UnsignedInteger) UtcTimeSynchronizationRecipients).Value)
            return "UTC Time Synchronization Recipients";
        if (type == ((UnsignedInteger) NodeSubtype).Value)
            return "Node Subtype";
        if (type == ((UnsignedInteger) NodeType).Value)
            return "Node Type";
        if (type == ((UnsignedInteger) StructuredObjectList).Value)
            return "Structured Object List";
        if (type == ((UnsignedInteger) SubordinateAnnotations).Value)
            return "Subordinate Annotations";
        if (type == ((UnsignedInteger) SubordinateList).Value)
            return "Subordinate List";
        if (type == ((UnsignedInteger) ActualShedLevel).Value)
            return "Actual Shed Level";
        if (type == ((UnsignedInteger) DutyWindow).Value)
            return "Duty Window";
        if (type == ((UnsignedInteger) ExpectedShedLevel).Value)
            return "Expected Shed Level";
        if (type == ((UnsignedInteger) FullDutyBaseline).Value)
            return "Full Duty Baseline";
        if (type == ((UnsignedInteger) RequestedShedLevel).Value)
            return "Requested Shed Level";
        if (type == ((UnsignedInteger) ShedDuration).Value)
            return "Shed Duration";
        if (type == ((UnsignedInteger) ShedLevelDescriptions).Value)
            return "Shed Level Descriptions";
        if (type == ((UnsignedInteger) ShedLevels).Value)
            return "Shed Levels";
        if (type == ((UnsignedInteger) StateDescription).Value)
            return "State Description";
        if (type == ((UnsignedInteger) DoorAlarmState).Value)
            return "Door Alarm State";
        if (type == ((UnsignedInteger) DoorExtendedPulseTime).Value)
            return "Door Extended Pulse Time";
        if (type == ((UnsignedInteger) DoorMembers).Value)
            return "Door Members";
        if (type == ((UnsignedInteger) DoorOpenTooLongTime).Value)
            return "Door Open Too Long Time";
        if (type == ((UnsignedInteger) DoorPulseTime).Value)
            return "Door Pulse Time";
        if (type == ((UnsignedInteger) DoorStatus).Value)
            return "Door Status";
        if (type == ((UnsignedInteger) DoorUnlockDelayTime).Value)
            return "Door Unlock Delay Time";
        if (type == ((UnsignedInteger) LockStatus).Value)
            return "Lock Status";
        if (type == ((UnsignedInteger) MaskedAlarmValues).Value)
            return "Masked Alarm Values";
        if (type == ((UnsignedInteger) SecuredStatus).Value)
            return "Secured Status";
        if (type == ((UnsignedInteger) BackupAndRestoreState).Value)
            return "Backup And Restore State";
        if (type == ((UnsignedInteger) BackupPreparationTime).Value)
            return "Backup Preparation Time";
        if (type == ((UnsignedInteger) RestoreCompletionTime).Value)
            return "Restore Completion Time";
        if (type == ((UnsignedInteger) RestorePreparationTime).Value)
            return "Restore Preparation Time";
        return "Unknown: " + type;
    }
}
}

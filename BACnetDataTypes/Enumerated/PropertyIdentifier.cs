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
            BackupPreparationTime, RestoreCompletionTime, RestorePreparationTime };

    public PropertyIdentifier(uint value) : base(value) { }

    public PropertyIdentifier(ByteStream queue) : base(queue) { }

        public override string ToString()
    {
        uint type = Value;
        if (type == AckedTransitions.Value)
            return "Acked transitions";
        if (type == AckRequired.Value)
            return "Ack required";
        if (type == Action.Value)
            return "Action";
        if (type == ActionText.Value)
            return "Action text";
        if (type == ActiveText.Value)
            return "Active text";
        if (type == ActiveVtSessions.Value)
            return "Active VT sessions";
        if (type == AlarmValue.Value)
            return "Alarm value";
        if (type == AlarmValues.Value)
            return "Alarm values";
        if (type == all.Value)
            return "All";
        if (type == AllWritesSuccessful.Value)
            return "All writes successful";
        if (type == ApduSegmentTimeout.Value)
            return "APDU segment timeout";
        if (type == ApduTimeout.Value)
            return "APDU timeout";
        if (type == ApplicationSoftwareVersion.Value)
            return "Application software version";
        if (type == Archive.Value)
            return "Archive";
        if (type == Bias.Value)
            return "Bias";
        if (type == ChangeOfStateCount.Value)
            return "Change of state count";
        if (type == ChangeOfStateTime.Value)
            return "Change of state time";
        if (type == NotificationClass.Value)
            return "Notification class";
        if (type == ControlledVariableReference.Value)
            return "Controlled variable reference";
        if (type == ControlledVariableUnits.Value)
            return "Controlled variable units";
        if (type == ControlledVariableValue.Value)
            return "Controlled variable value";
        if (type == CovIncrement.Value)
            return "COV increment";
        if (type == DateList.Value)
            return "Date list";
        if (type == DaylightSavingsStatus.Value)
            return "Daylight savings status";
        if (type == Deadband.Value)
            return "Deadband";
        if (type == DerivativeConstant.Value)
            return "Derivative constant";
        if (type == DerivativeConstantUnits.Value)
            return "Derivative constant units";
        if (type == Description.Value)
            return "Description";
        if (type == DescriptionOfHalt.Value)
            return "Description of halt";
        if (type == DeviceAddressBinding.Value)
            return "Device address binding";
        if (type == DeviceType.Value)
            return "Device type";
        if (type == EffectivePeriod.Value)
            return "Effective period";
        if (type == ElapsedActiveTime.Value)
            return "Elapsed active time";
        if (type == ErrorLimit.Value)
            return "Error limit";
        if (type == EventEnable.Value)
            return "Event enable";
        if (type == EventState.Value)
            return "Event state";
        if (type == EventType.Value)
            return "Event type";
        if (type == ExceptionSchedule.Value)
            return "Exception schedule";
        if (type == FaultValues.Value)
            return "Fault values";
        if (type == FeedbackValue.Value)
            return "Feedback value";
        if (type == FileAccessMethod.Value)
            return "File access method";
        if (type == FileSize.Value)
            return "File size";
        if (type == FileType.Value)
            return "File type";
        if (type == FirmwareRevision.Value)
            return "Firmware revision";
        if (type == HighLimit.Value)
            return "High limit";
        if (type == InactiveText.Value)
            return "Inactive text";
        if (type == InProcess.Value)
            return "In process";
        if (type == InstanceOf.Value)
            return "Instance of";
        if (type == IntegralConstant.Value)
            return "Integral constant";
        if (type == IntegralConstantUnits.Value)
            return "Integral constant units";
        if (type == LimitEnable.Value)
            return "Limit enable";
        if (type == ListOfGroupMembers.Value)
            return "List of group members";
        if (type == ListOfObjectPropertyReferences.Value)
            return "List of object property references";
        if (type == ListOfSessionKeys.Value)
            return "List of session keys";
        if (type == LocalDate.Value)
            return "Local date";
        if (type == LocalTime.Value)
            return "Local time";
        if (type == Location.Value)
            return "Location";
        if (type == LowLimit.Value)
            return "Low limit";
        if (type == ManipulatedVariableReference.Value)
            return "Manipulated variable reference";
        if (type == MaximumOutput.Value)
            return "Maximum output";
        if (type == MaxApduLengthAccepted.Value)
            return "Max APDU length accepted";
        if (type == MaxInfoFrames.Value)
            return "Max info frames";
        if (type == MaxMaster.Value)
            return "Max master";
        if (type == MaxPresValue.Value)
            return "Max pres value";
        if (type == MinimumOffTime.Value)
            return "Minimum off time";
        if (type == MinimumOnTime.Value)
            return "Minimum on time";
        if (type == MinimumOutput.Value)
            return "Minimum output";
        if (type == MinPresValue.Value)
            return "Min pres value";
        if (type == ModelName.Value)
            return "Model name";
        if (type == ModificationDate.Value)
            return "Modification date";
        if (type == NotifyType.Value)
            return "Notify type";
        if (type == NumberOfApduRetries.Value)
            return "Number of APDU retries";
        if (type == NumberOfStates.Value)
            return "Number of states";
        if (type == ObjectIdentifier.Value)
            return "Object identifier";
        if (type == ObjectList.Value)
            return "Object list";
        if (type == ObjectName.Value)
            return "Object name";
        if (type == ObjectPropertyReference.Value)
            return "Object property reference";
        if (type == ObjectType.Value)
            return "Object type";
        if (type == Optional.Value)
            return "Optional";
        if (type == OutOfService.Value)
            return "Out of service";
        if (type == OutputUnits.Value)
            return "Output units";
        if (type == EventParameters.Value)
            return "Event parameters";
        if (type == Polarity.Value)
            return "Polarity";
        if (type == PresentValue.Value)
            return "Present value";
        if (type == Priority.Value)
            return "Priority";
        if (type == PriorityArray.Value)
            return "Priority array";
        if (type == PriorityForWriting.Value)
            return "Priority for writing";
        if (type == ProcessIdentifier.Value)
            return "Process identifier";
        if (type == ProgramChange.Value)
            return "Program change";
        if (type == ProgramLocation.Value)
            return "Program location";
        if (type == ProgramState.Value)
            return "Program state";
        if (type == ProportionalConstant.Value)
            return "Proportional constant";
        if (type == ProportionalConstantUnits.Value)
            return "Proportional constant units";
        if (type == ProtocolObjectTypesSupported.Value)
            return "Protocol object types supported";
        if (type == ProtocolServicesSupported.Value)
            return "Protocol services supported";
        if (type == ProtocolVersion.Value)
            return "Protocol version";
        if (type == ReadOnly.Value)
            return "Read only";
        if (type == ReasonForHalt.Value)
            return "Reason for halt";
        if (type == RecipientList.Value)
            return "Recipient list";
        if (type == Reliability.Value)
            return "Reliability";
        if (type == RelinquishDefault.Value)
            return "Relinquish default";
        if (type == Required.Value)
            return "Required";
        if (type == Resolution.Value)
            return "Resolution";
        if (type == SegmentationSupported.Value)
            return "Segmentation supported";
        if (type == Setpoint.Value)
            return "Setpoint";
        if (type == SetpointReference.Value)
            return "Setpoint reference";
        if (type == StateText.Value)
            return "State text";
        if (type == StatusFlags.Value)
            return "Status flags";
        if (type == SystemStatus.Value)
            return "System status";
        if (type == TimeDelay.Value)
            return "Time delay";
        if (type == TimeOfActiveTimeReset.Value)
            return "Time of active time reset";
        if (type == TimeOfStateCountReset.Value)
            return "Time of state count reset";
        if (type == TimeSynchronizationRecipients.Value)
            return "Time synchronization recipients";
        if (type == Units.Value)
            return "Units";
        if (type == UpdateInterval.Value)
            return "Update interval";
        if (type == UtcOffset.Value)
            return "UTC offset";
        if (type == VendorIdentifier.Value)
            return "Vendor identifier";
        if (type == VendorName.Value)
            return "Vendor name";
        if (type == VtClassesSupported.Value)
            return "VT classes supported";
        if (type == WeeklySchedule.Value)
            return "Weekly schedule";
        if (type == AttemptedSamples.Value)
            return "Attempted samples";
        if (type == AverageValue.Value)
            return "Average value";
        if (type == BufferSize.Value)
            return "Buffer size";
        if (type == ClientCovIncrement.Value)
            return "Client COV increment";
        if (type == CovResubscriptionInterval.Value)
            return "COV resubscription interval";
        if (type == EventTimeStamps.Value)
            return "Event time stamps";
        if (type == LogBuffer.Value)
            return "Log buffer";
        if (type == LogDeviceObjectProperty.Value)
            return "Log device object property";
        if (type == Enable.Value)
            return "enable";
        if (type == LogInterval.Value)
            return "Log interval";
        if (type == MaximumValue.Value)
            return "Maximum value";
        if (type == MinimumValue.Value)
            return "Minimum value";
        if (type == NotificationThreshold.Value)
            return "Notification threshold";
        if (type == ProtocolRevision.Value)
            return "Protocol revision";
        if (type == RecordsSinceNotification.Value)
            return "Records since notification";
        if (type == RecordCount.Value)
            return "Record count";
        if (type == StartTime.Value)
            return "Start time";
        if (type == StopTime.Value)
            return "Stop time";
        if (type == StopWhenFull.Value)
            return "Stop when full";
        if (type == TotalRecordCount.Value)
            return "Total record count";
        if (type == ValidSamples.Value)
            return "Valid samples";
        if (type == WindowInterval.Value)
            return "Window interval";
        if (type == WindowSamples.Value)
            return "Window samples";
        if (type == MaximumValueTimestamp.Value)
            return "Maximum value timestamp";
        if (type == MinimumValueTimestamp.Value)
            return "Minimum value timestamp";
        if (type == VarianceValue.Value)
            return "Variance value";
        if (type == ActiveCovSubscriptions.Value)
            return "Active COV subscriptions";
        if (type == BackupFailureTimeout.Value)
            return "Backup failure timeout";
        if (type == ConfigurationFiles.Value)
            return "Configuration files";
        if (type == DatabaseRevision.Value)
            return "Database revision";
        if (type == DirectReading.Value)
            return "Direct reading";
        if (type == LastRestoreTime.Value)
            return "Last restore time";
        if (type == MaintenanceRequired.Value)
            return "Maintenance required";
        if (type == MemberOf.Value)
            return "Member of";
        if (type == Mode.Value)
            return "Mode";
        if (type == OperationExpected.Value)
            return "Operation expected";
        if (type == Setting.Value)
            return "Setting";
        if (type == Silenced.Value)
            return "Silenced";
        if (type == TrackingValue.Value)
            return "Tracking value";
        if (type == ZoneMembers.Value)
            return "Zone members";
        if (type == LifeSafetyAlarmValues.Value)
            return "Life safety alarm values";
        if (type == MaxSegmentsAccepted.Value)
            return "Max segments accepted";
        if (type == ProfileName.Value)
            return "Profile name";
        if (type == AutoSlaveDiscovery.Value)
            return "Auto slave discovery";
        if (type == ManualSlaveAddressBinding.Value)
            return "Manual slave address binding";
        if (type == SlaveAddressBinding.Value)
            return "Slave address binding";
        if (type == SlaveProxyEnable.Value)
            return "Slave proxy enable";
        if (type == LastNotifyRecord.Value)
            return "Last notify record";
        if (type == ScheduleDefault.Value)
            return "Schedule default";
        if (type == AcceptedModes.Value)
            return "Accepted modes";
        if (type == AdjustValue.Value)
            return "Adjust value";
        if (type == Count.Value)
            return "Count";
        if (type == CountBeforeChange.Value)
            return "Count before change";
        if (type == CountChangeTime.Value)
            return "Count change time";
        if (type == CovPeriod.Value)
            return "COV period";
        if (type == InputReference.Value)
            return "Input reference";
        if (type == LimitMonitoringInterval.Value)
            return "Limit monitoring interval";
        if (type == LoggingObject.Value)
            return "Logging object";
        if (type == LoggingRecord.Value)
            return "Logging record";
        if (type == Prescale.Value)
            return "Prescale";
        if (type == PulseRate.Value)
            return "Pulse rate";
        if (type == Scale.Value)
            return "Scale";
        if (type == ScaleFactor.Value)
            return "Scale factor";
        if (type == UpdateTime.Value)
            return "Update time";
        if (type == ValueBeforeChange.Value)
            return "Value before change";
        if (type == ValueSet.Value)
            return "Value set";
        if (type == ValueChangeTime.Value)
            return "Value change time";
        if (type == AlignIntervals.Value)
            return "Align Intervals";
        if (type == IntervalOffset.Value)
            return "Interval Offset";
        if (type == LastRestartReason.Value)
            return "Last Restart Reason";
        if (type == LoggingType.Value)
            return "Logging Type";
        if (type == RestartNotificationRecipients.Value)
            return "Restart Notification Recipients";
        if (type == TimeOfDeviceRestart.Value)
            return "Time Of Device Restart";
        if (type == TimeSynchronizationInterval.Value)
            return "Time Synchronization Interval";
        if (type == Trigger.Value)
            return "Trigger";
        if (type == UtcTimeSynchronizationRecipients.Value)
            return "UTC Time Synchronization Recipients";
        if (type == NodeSubtype.Value)
            return "Node Subtype";
        if (type == NodeType.Value)
            return "Node Type";
        if (type == StructuredObjectList.Value)
            return "Structured Object List";
        if (type == SubordinateAnnotations.Value)
            return "Subordinate Annotations";
        if (type == SubordinateList.Value)
            return "Subordinate List";
        if (type == ActualShedLevel.Value)
            return "Actual Shed Level";
        if (type == DutyWindow.Value)
            return "Duty Window";
        if (type == ExpectedShedLevel.Value)
            return "Expected Shed Level";
        if (type == FullDutyBaseline.Value)
            return "Full Duty Baseline";
        if (type == RequestedShedLevel.Value)
            return "Requested Shed Level";
        if (type == ShedDuration.Value)
            return "Shed Duration";
        if (type == ShedLevelDescriptions.Value)
            return "Shed Level Descriptions";
        if (type == ShedLevels.Value)
            return "Shed Levels";
        if (type == StateDescription.Value)
            return "State Description";
        if (type == DoorAlarmState.Value)
            return "Door Alarm State";
        if (type == DoorExtendedPulseTime.Value)
            return "Door Extended Pulse Time";
        if (type == DoorMembers.Value)
            return "Door Members";
        if (type == DoorOpenTooLongTime.Value)
            return "Door Open Too Long Time";
        if (type == DoorPulseTime.Value)
            return "Door Pulse Time";
        if (type == DoorStatus.Value)
            return "Door Status";
        if (type == DoorUnlockDelayTime.Value)
            return "Door Unlock Delay Time";
        if (type == LockStatus.Value)
            return "Lock Status";
        if (type == MaskedAlarmValues.Value)
            return "Masked Alarm Values";
        if (type == SecuredStatus.Value)
            return "Secured Status";
        if (type == BackupAndRestoreState.Value)
            return "Backup And Restore State";
        if (type == BackupPreparationTime.Value)
            return "Backup Preparation Time";
        if (type == RestoreCompletionTime.Value)
            return "Restore Completion Time";
        if (type == RestorePreparationTime.Value)
            return "Restore Preparation Time";
        return "Unknown: " + type;
    }
}
}

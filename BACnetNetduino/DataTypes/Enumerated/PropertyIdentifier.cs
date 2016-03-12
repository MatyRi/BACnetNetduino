using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Enumerated
{
    class PropertyIdentifier : Primitive.Enumerated
    {
        public static readonly PropertyIdentifier ackedTransitions = new PropertyIdentifier(0);
        public static readonly PropertyIdentifier ackRequired = new PropertyIdentifier(1);
        public static readonly PropertyIdentifier action = new PropertyIdentifier(2);
        public static readonly PropertyIdentifier actionText = new PropertyIdentifier(3);
        public static readonly PropertyIdentifier activeText = new PropertyIdentifier(4);
        public static readonly PropertyIdentifier activeVtSessions = new PropertyIdentifier(5);
        public static readonly PropertyIdentifier alarmValue = new PropertyIdentifier(6);
        public static readonly PropertyIdentifier alarmValues = new PropertyIdentifier(7);
        public static readonly PropertyIdentifier all = new PropertyIdentifier(8);
        public static readonly PropertyIdentifier allWritesSuccessful = new PropertyIdentifier(9);
        public static readonly PropertyIdentifier apduSegmentTimeout = new PropertyIdentifier(10);
        public static readonly PropertyIdentifier apduTimeout = new PropertyIdentifier(11);
        public static readonly PropertyIdentifier applicationSoftwareVersion = new PropertyIdentifier(12);
        public static readonly PropertyIdentifier archive = new PropertyIdentifier(13);
        public static readonly PropertyIdentifier bias = new PropertyIdentifier(14);
        public static readonly PropertyIdentifier changeOfStateCount = new PropertyIdentifier(15);
        public static readonly PropertyIdentifier changeOfStateTime = new PropertyIdentifier(16);
        public static readonly PropertyIdentifier notificationClass = new PropertyIdentifier(17);
        public static readonly PropertyIdentifier controlledVariableReference = new PropertyIdentifier(19);
        public static readonly PropertyIdentifier controlledVariableUnits = new PropertyIdentifier(20);
        public static readonly PropertyIdentifier controlledVariableValue = new PropertyIdentifier(21);
        public static readonly PropertyIdentifier covIncrement = new PropertyIdentifier(22);
        public static readonly PropertyIdentifier dateList = new PropertyIdentifier(23);
        public static readonly PropertyIdentifier daylightSavingsStatus = new PropertyIdentifier(24);
        public static readonly PropertyIdentifier deadband = new PropertyIdentifier(25);
        public static readonly PropertyIdentifier derivativeConstant = new PropertyIdentifier(26);
        public static readonly PropertyIdentifier derivativeConstantUnits = new PropertyIdentifier(27);
        public static readonly PropertyIdentifier description = new PropertyIdentifier(28);
        public static readonly PropertyIdentifier descriptionOfHalt = new PropertyIdentifier(29);
        public static readonly PropertyIdentifier deviceAddressBinding = new PropertyIdentifier(30);
        public static readonly PropertyIdentifier deviceType = new PropertyIdentifier(31);
        public static readonly PropertyIdentifier effectivePeriod = new PropertyIdentifier(32);
        public static readonly PropertyIdentifier elapsedActiveTime = new PropertyIdentifier(33);
        public static readonly PropertyIdentifier errorLimit = new PropertyIdentifier(34);
        public static readonly PropertyIdentifier eventEnable = new PropertyIdentifier(35);
        public static readonly PropertyIdentifier eventState = new PropertyIdentifier(36);
        public static readonly PropertyIdentifier eventType = new PropertyIdentifier(37);
        public static readonly PropertyIdentifier exceptionSchedule = new PropertyIdentifier(38);
        public static readonly PropertyIdentifier faultValues = new PropertyIdentifier(39);
        public static readonly PropertyIdentifier feedbackValue = new PropertyIdentifier(40);
        public static readonly PropertyIdentifier fileAccessMethod = new PropertyIdentifier(41);
        public static readonly PropertyIdentifier fileSize = new PropertyIdentifier(42);
        public static readonly PropertyIdentifier fileType = new PropertyIdentifier(43);
        public static readonly PropertyIdentifier firmwareRevision = new PropertyIdentifier(44);
        public static readonly PropertyIdentifier highLimit = new PropertyIdentifier(45);
        public static readonly PropertyIdentifier inactiveText = new PropertyIdentifier(46);
        public static readonly PropertyIdentifier inProcess = new PropertyIdentifier(47);
        public static readonly PropertyIdentifier instanceOf = new PropertyIdentifier(48);
        public static readonly PropertyIdentifier integralConstant = new PropertyIdentifier(49);
        public static readonly PropertyIdentifier integralConstantUnits = new PropertyIdentifier(50);
        public static readonly PropertyIdentifier limitEnable = new PropertyIdentifier(52);
        public static readonly PropertyIdentifier listOfGroupMembers = new PropertyIdentifier(53);
        public static readonly PropertyIdentifier listOfObjectPropertyReferences = new PropertyIdentifier(54);
        public static readonly PropertyIdentifier listOfSessionKeys = new PropertyIdentifier(55);
        public static readonly PropertyIdentifier localDate = new PropertyIdentifier(56);
        public static readonly PropertyIdentifier localTime = new PropertyIdentifier(57);
        public static readonly PropertyIdentifier location = new PropertyIdentifier(58);
        public static readonly PropertyIdentifier lowLimit = new PropertyIdentifier(59);
        public static readonly PropertyIdentifier manipulatedVariableReference = new PropertyIdentifier(60);
        public static readonly PropertyIdentifier maximumOutput = new PropertyIdentifier(61);
        public static readonly PropertyIdentifier maxApduLengthAccepted = new PropertyIdentifier(62);
        public static readonly PropertyIdentifier maxInfoFrames = new PropertyIdentifier(63);
        public static readonly PropertyIdentifier maxMaster = new PropertyIdentifier(64);
        public static readonly PropertyIdentifier maxPresValue = new PropertyIdentifier(65);
        public static readonly PropertyIdentifier minimumOffTime = new PropertyIdentifier(66);
        public static readonly PropertyIdentifier minimumOnTime = new PropertyIdentifier(67);
        public static readonly PropertyIdentifier minimumOutput = new PropertyIdentifier(68);
        public static readonly PropertyIdentifier minPresValue = new PropertyIdentifier(69);
        public static readonly PropertyIdentifier modelName = new PropertyIdentifier(70);
        public static readonly PropertyIdentifier modificationDate = new PropertyIdentifier(71);
        public static readonly PropertyIdentifier notifyType = new PropertyIdentifier(72);
        public static readonly PropertyIdentifier numberOfApduRetries = new PropertyIdentifier(73);
        public static readonly PropertyIdentifier numberOfStates = new PropertyIdentifier(74);
        public static readonly PropertyIdentifier objectIdentifier = new PropertyIdentifier(75);
        public static readonly PropertyIdentifier objectList = new PropertyIdentifier(76);
        public static readonly PropertyIdentifier objectName = new PropertyIdentifier(77);
        public static readonly PropertyIdentifier objectPropertyReference = new PropertyIdentifier(78);
        public static readonly PropertyIdentifier objectType = new PropertyIdentifier(79);
        public static readonly PropertyIdentifier optional = new PropertyIdentifier(80);
        public static readonly PropertyIdentifier outOfService = new PropertyIdentifier(81);
        public static readonly PropertyIdentifier outputUnits = new PropertyIdentifier(82);
        public static readonly PropertyIdentifier eventParameters = new PropertyIdentifier(83);
        public static readonly PropertyIdentifier polarity = new PropertyIdentifier(84);
        public static readonly PropertyIdentifier presentValue = new PropertyIdentifier(85);
        public static readonly PropertyIdentifier priority = new PropertyIdentifier(86);
        public static readonly PropertyIdentifier priorityArray = new PropertyIdentifier(87);
        public static readonly PropertyIdentifier priorityForWriting = new PropertyIdentifier(88);
        public static readonly PropertyIdentifier processIdentifier = new PropertyIdentifier(89);
        public static readonly PropertyIdentifier programChange = new PropertyIdentifier(90);
        public static readonly PropertyIdentifier programLocation = new PropertyIdentifier(91);
        public static readonly PropertyIdentifier programState = new PropertyIdentifier(92);
        public static readonly PropertyIdentifier proportionalConstant = new PropertyIdentifier(93);
        public static readonly PropertyIdentifier proportionalConstantUnits = new PropertyIdentifier(94);
        public static readonly PropertyIdentifier protocolObjectTypesSupported = new PropertyIdentifier(96);
        public static readonly PropertyIdentifier protocolServicesSupported = new PropertyIdentifier(97);
        public static readonly PropertyIdentifier protocolVersion = new PropertyIdentifier(98);
        public static readonly PropertyIdentifier readOnly = new PropertyIdentifier(99);
        public static readonly PropertyIdentifier reasonForHalt = new PropertyIdentifier(100);
        public static readonly PropertyIdentifier recipientList = new PropertyIdentifier(102);
        public static readonly PropertyIdentifier reliability = new PropertyIdentifier(103);
        public static readonly PropertyIdentifier relinquishDefault = new PropertyIdentifier(104);
        public static readonly PropertyIdentifier required = new PropertyIdentifier(105);
        public static readonly PropertyIdentifier resolution = new PropertyIdentifier(106);
        public static readonly PropertyIdentifier segmentationSupported = new PropertyIdentifier(107);
        public static readonly PropertyIdentifier setpoint = new PropertyIdentifier(108);
        public static readonly PropertyIdentifier setpointReference = new PropertyIdentifier(109);
        public static readonly PropertyIdentifier stateText = new PropertyIdentifier(110);
        public static readonly PropertyIdentifier statusFlags = new PropertyIdentifier(111);
        public static readonly PropertyIdentifier systemStatus = new PropertyIdentifier(112);
        public static readonly PropertyIdentifier timeDelay = new PropertyIdentifier(113);
        public static readonly PropertyIdentifier timeOfActiveTimeReset = new PropertyIdentifier(114);
        public static readonly PropertyIdentifier timeOfStateCountReset = new PropertyIdentifier(115);
        public static readonly PropertyIdentifier timeSynchronizationRecipients = new PropertyIdentifier(116);
        public static readonly PropertyIdentifier units = new PropertyIdentifier(117);
        public static readonly PropertyIdentifier updateInterval = new PropertyIdentifier(118);
        public static readonly PropertyIdentifier utcOffset = new PropertyIdentifier(119);
        public static readonly PropertyIdentifier vendorIdentifier = new PropertyIdentifier(120);
        public static readonly PropertyIdentifier vendorName = new PropertyIdentifier(121);
        public static readonly PropertyIdentifier vtClassesSupported = new PropertyIdentifier(122);
        public static readonly PropertyIdentifier weeklySchedule = new PropertyIdentifier(123);
        public static readonly PropertyIdentifier attemptedSamples = new PropertyIdentifier(124);
        public static readonly PropertyIdentifier averageValue = new PropertyIdentifier(125);
        public static readonly PropertyIdentifier bufferSize = new PropertyIdentifier(126);
        public static readonly PropertyIdentifier clientCovIncrement = new PropertyIdentifier(127);
        public static readonly PropertyIdentifier covResubscriptionInterval = new PropertyIdentifier(128);
        public static readonly PropertyIdentifier eventTimeStamps = new PropertyIdentifier(130);
        public static readonly PropertyIdentifier logBuffer = new PropertyIdentifier(131);
        public static readonly PropertyIdentifier logDeviceObjectProperty = new PropertyIdentifier(132);
        public static readonly PropertyIdentifier enable = new PropertyIdentifier(133);
        public static readonly PropertyIdentifier logInterval = new PropertyIdentifier(134);
        public static readonly PropertyIdentifier maximumValue = new PropertyIdentifier(135);
        public static readonly PropertyIdentifier minimumValue = new PropertyIdentifier(136);
        public static readonly PropertyIdentifier notificationThreshold = new PropertyIdentifier(137);
        public static readonly PropertyIdentifier protocolRevision = new PropertyIdentifier(139);
        public static readonly PropertyIdentifier recordsSinceNotification = new PropertyIdentifier(140);
        public static readonly PropertyIdentifier recordCount = new PropertyIdentifier(141);
        public static readonly PropertyIdentifier startTime = new PropertyIdentifier(142);
        public static readonly PropertyIdentifier stopTime = new PropertyIdentifier(143);
        public static readonly PropertyIdentifier stopWhenFull = new PropertyIdentifier(144);
        public static readonly PropertyIdentifier totalRecordCount = new PropertyIdentifier(145);
        public static readonly PropertyIdentifier validSamples = new PropertyIdentifier(146);
        public static readonly PropertyIdentifier windowInterval = new PropertyIdentifier(147);
        public static readonly PropertyIdentifier windowSamples = new PropertyIdentifier(148);
        public static readonly PropertyIdentifier maximumValueTimestamp = new PropertyIdentifier(149);
        public static readonly PropertyIdentifier minimumValueTimestamp = new PropertyIdentifier(150);
        public static readonly PropertyIdentifier varianceValue = new PropertyIdentifier(151);
        public static readonly PropertyIdentifier activeCovSubscriptions = new PropertyIdentifier(152);
        public static readonly PropertyIdentifier backupFailureTimeout = new PropertyIdentifier(153);
        public static readonly PropertyIdentifier configurationFiles = new PropertyIdentifier(154);
        public static readonly PropertyIdentifier databaseRevision = new PropertyIdentifier(155);
        public static readonly PropertyIdentifier directReading = new PropertyIdentifier(156);
        public static readonly PropertyIdentifier lastRestoreTime = new PropertyIdentifier(157);
        public static readonly PropertyIdentifier maintenanceRequired = new PropertyIdentifier(158);
        public static readonly PropertyIdentifier memberOf = new PropertyIdentifier(159);
        public static readonly PropertyIdentifier mode = new PropertyIdentifier(160);
        public static readonly PropertyIdentifier operationExpected = new PropertyIdentifier(161);
        public static readonly PropertyIdentifier setting = new PropertyIdentifier(162);
        public static readonly PropertyIdentifier silenced = new PropertyIdentifier(163);
        public static readonly PropertyIdentifier trackingValue = new PropertyIdentifier(164);
        public static readonly PropertyIdentifier zoneMembers = new PropertyIdentifier(165);
        public static readonly PropertyIdentifier lifeSafetyAlarmValues = new PropertyIdentifier(166);
        public static readonly PropertyIdentifier maxSegmentsAccepted = new PropertyIdentifier(167);
        public static readonly PropertyIdentifier profileName = new PropertyIdentifier(168);
        public static readonly PropertyIdentifier autoSlaveDiscovery = new PropertyIdentifier(169);
        public static readonly PropertyIdentifier manualSlaveAddressBinding = new PropertyIdentifier(170);
        public static readonly PropertyIdentifier slaveAddressBinding = new PropertyIdentifier(171);
        public static readonly PropertyIdentifier slaveProxyEnable = new PropertyIdentifier(172);
        public static readonly PropertyIdentifier lastNotifyRecord = new PropertyIdentifier(173);
        public static readonly PropertyIdentifier scheduleDefault = new PropertyIdentifier(174);
        public static readonly PropertyIdentifier acceptedModes = new PropertyIdentifier(175);
        public static readonly PropertyIdentifier adjustValue = new PropertyIdentifier(176);
        public static readonly PropertyIdentifier count = new PropertyIdentifier(177);
        public static readonly PropertyIdentifier countBeforeChange = new PropertyIdentifier(178);
        public static readonly PropertyIdentifier countChangeTime = new PropertyIdentifier(179);
        public static readonly PropertyIdentifier covPeriod = new PropertyIdentifier(180);
        public static readonly PropertyIdentifier inputReference = new PropertyIdentifier(181);
        public static readonly PropertyIdentifier limitMonitoringInterval = new PropertyIdentifier(182);
        public static readonly PropertyIdentifier loggingObject = new PropertyIdentifier(183);
        public static readonly PropertyIdentifier loggingRecord = new PropertyIdentifier(184);
        public static readonly PropertyIdentifier prescale = new PropertyIdentifier(185);
        public static readonly PropertyIdentifier pulseRate = new PropertyIdentifier(186);
        public static readonly PropertyIdentifier scale = new PropertyIdentifier(187);
        public static readonly PropertyIdentifier scaleFactor = new PropertyIdentifier(188);
        public static readonly PropertyIdentifier updateTime = new PropertyIdentifier(189);
        public static readonly PropertyIdentifier valueBeforeChange = new PropertyIdentifier(190);
        public static readonly PropertyIdentifier valueSet = new PropertyIdentifier(191);
        public static readonly PropertyIdentifier valueChangeTime = new PropertyIdentifier(192);
        public static readonly PropertyIdentifier alignIntervals = new PropertyIdentifier(193);
        public static readonly PropertyIdentifier intervalOffset = new PropertyIdentifier(195);
        public static readonly PropertyIdentifier lastRestartReason = new PropertyIdentifier(196);
        public static readonly PropertyIdentifier loggingType = new PropertyIdentifier(197);
        public static readonly PropertyIdentifier restartNotificationRecipients = new PropertyIdentifier(202);
        public static readonly PropertyIdentifier timeOfDeviceRestart = new PropertyIdentifier(203);
        public static readonly PropertyIdentifier timeSynchronizationInterval = new PropertyIdentifier(204);
        public static readonly PropertyIdentifier trigger = new PropertyIdentifier(205);
        public static readonly PropertyIdentifier utcTimeSynchronizationRecipients = new PropertyIdentifier(206);
        public static readonly PropertyIdentifier nodeSubtype = new PropertyIdentifier(207);
        public static readonly PropertyIdentifier nodeType = new PropertyIdentifier(208);
        public static readonly PropertyIdentifier structuredObjectList = new PropertyIdentifier(209);
        public static readonly PropertyIdentifier subordinateAnnotations = new PropertyIdentifier(210);
        public static readonly PropertyIdentifier subordinateList = new PropertyIdentifier(211);
        public static readonly PropertyIdentifier actualShedLevel = new PropertyIdentifier(212);
        public static readonly PropertyIdentifier dutyWindow = new PropertyIdentifier(213);
        public static readonly PropertyIdentifier expectedShedLevel = new PropertyIdentifier(214);
        public static readonly PropertyIdentifier fullDutyBaseline = new PropertyIdentifier(215);
        public static readonly PropertyIdentifier requestedShedLevel = new PropertyIdentifier(218);
        public static readonly PropertyIdentifier shedDuration = new PropertyIdentifier(219);
        public static readonly PropertyIdentifier shedLevelDescriptions = new PropertyIdentifier(220);
        public static readonly PropertyIdentifier shedLevels = new PropertyIdentifier(221);
        public static readonly PropertyIdentifier stateDescription = new PropertyIdentifier(222);
        public static readonly PropertyIdentifier doorAlarmState = new PropertyIdentifier(226);
        public static readonly PropertyIdentifier doorExtendedPulseTime = new PropertyIdentifier(227);
        public static readonly PropertyIdentifier doorMembers = new PropertyIdentifier(228);
        public static readonly PropertyIdentifier doorOpenTooLongTime = new PropertyIdentifier(229);
        public static readonly PropertyIdentifier doorPulseTime = new PropertyIdentifier(230);
        public static readonly PropertyIdentifier doorStatus = new PropertyIdentifier(231);
        public static readonly PropertyIdentifier doorUnlockDelayTime = new PropertyIdentifier(232);
        public static readonly PropertyIdentifier lockStatus = new PropertyIdentifier(233);
        public static readonly PropertyIdentifier maskedAlarmValues = new PropertyIdentifier(234);
        public static readonly PropertyIdentifier securedStatus = new PropertyIdentifier(235);
        public static readonly PropertyIdentifier backupAndRestoreState = new PropertyIdentifier(338);
        public static readonly PropertyIdentifier backupPreparationTime = new PropertyIdentifier(339);
        public static readonly PropertyIdentifier restoreCompletionTime = new PropertyIdentifier(340);
        public static readonly PropertyIdentifier restorePreparationTime = new PropertyIdentifier(341);

        public static readonly PropertyIdentifier[] ALL = { ackedTransitions, ackRequired, action, actionText, activeText,
            activeVtSessions, alarmValue, alarmValues, all, allWritesSuccessful, apduSegmentTimeout, apduTimeout,
            applicationSoftwareVersion, archive, bias, changeOfStateCount, changeOfStateTime, notificationClass,
            controlledVariableReference, controlledVariableUnits, controlledVariableValue, covIncrement, dateList,
            daylightSavingsStatus, deadband, derivativeConstant, derivativeConstantUnits, description,
            descriptionOfHalt, deviceAddressBinding, deviceType, effectivePeriod, elapsedActiveTime, errorLimit,
            eventEnable, eventState, eventType, exceptionSchedule, faultValues, feedbackValue, fileAccessMethod,
            fileSize, fileType, firmwareRevision, highLimit, inactiveText, inProcess, instanceOf, integralConstant,
            integralConstantUnits, limitEnable, listOfGroupMembers, listOfObjectPropertyReferences, listOfSessionKeys,
            localDate, localTime, location, lowLimit, manipulatedVariableReference, maximumOutput,
            maxApduLengthAccepted, maxInfoFrames, maxMaster, maxPresValue, minimumOffTime, minimumOnTime,
            minimumOutput, minPresValue, modelName, modificationDate, notifyType, numberOfApduRetries, numberOfStates,
            objectIdentifier, objectList, objectName, objectPropertyReference, objectType, optional, outOfService,
            outputUnits, eventParameters, polarity, presentValue, priority, priorityArray, priorityForWriting,
            processIdentifier, programChange, programLocation, programState, proportionalConstant,
            proportionalConstantUnits, protocolObjectTypesSupported, protocolServicesSupported, protocolVersion,
            readOnly, reasonForHalt, recipientList, reliability, relinquishDefault, required, resolution,
            segmentationSupported, setpoint, setpointReference, stateText, statusFlags, systemStatus, timeDelay,
            timeOfActiveTimeReset, timeOfStateCountReset, timeSynchronizationRecipients, units, updateInterval,
            utcOffset, vendorIdentifier, vendorName, vtClassesSupported, weeklySchedule, attemptedSamples,
            averageValue, bufferSize, clientCovIncrement, covResubscriptionInterval, eventTimeStamps, logBuffer,
            logDeviceObjectProperty, enable, logInterval, maximumValue, minimumValue, notificationThreshold,
            protocolRevision, recordsSinceNotification, recordCount, startTime, stopTime, stopWhenFull,
            totalRecordCount, validSamples, windowInterval, windowSamples, maximumValueTimestamp,
            minimumValueTimestamp, varianceValue, activeCovSubscriptions, backupFailureTimeout, configurationFiles,
            databaseRevision, directReading, lastRestoreTime, maintenanceRequired, memberOf, mode, operationExpected,
            setting, silenced, trackingValue, zoneMembers, lifeSafetyAlarmValues, maxSegmentsAccepted, profileName,
            autoSlaveDiscovery, manualSlaveAddressBinding, slaveAddressBinding, slaveProxyEnable, lastNotifyRecord,
            scheduleDefault, acceptedModes, adjustValue, count, countBeforeChange, countChangeTime, covPeriod,
            inputReference, limitMonitoringInterval, loggingObject, loggingRecord, prescale, pulseRate, scale,
            scaleFactor, updateTime, valueBeforeChange, valueSet, valueChangeTime, alignIntervals, intervalOffset,
            lastRestartReason, loggingType, restartNotificationRecipients, timeOfDeviceRestart,
            timeSynchronizationInterval, trigger, utcTimeSynchronizationRecipients, nodeSubtype, nodeType,
            structuredObjectList, subordinateAnnotations, subordinateList, actualShedLevel, dutyWindow,
            expectedShedLevel, fullDutyBaseline, requestedShedLevel, shedDuration, shedLevelDescriptions, shedLevels,
            stateDescription, doorAlarmState, doorExtendedPulseTime, doorMembers, doorOpenTooLongTime, doorPulseTime,
            doorStatus, doorUnlockDelayTime, lockStatus, maskedAlarmValues, securedStatus, backupAndRestoreState,
            backupPreparationTime, restoreCompletionTime, restorePreparationTime, };

    public PropertyIdentifier(uint value) : base(value) { }

    public PropertyIdentifier(ByteStream queue) : base(queue) { }

        public override string ToString()
    {
        uint type = intValue();
        if (type == ackedTransitions.intValue())
            return "Acked transitions";
        if (type == ackRequired.intValue())
            return "Ack required";
        if (type == action.intValue())
            return "Action";
        if (type == actionText.intValue())
            return "Action text";
        if (type == activeText.intValue())
            return "Active text";
        if (type == activeVtSessions.intValue())
            return "Active VT sessions";
        if (type == alarmValue.intValue())
            return "Alarm value";
        if (type == alarmValues.intValue())
            return "Alarm values";
        if (type == all.intValue())
            return "All";
        if (type == allWritesSuccessful.intValue())
            return "All writes successful";
        if (type == apduSegmentTimeout.intValue())
            return "APDU segment timeout";
        if (type == apduTimeout.intValue())
            return "APDU timeout";
        if (type == applicationSoftwareVersion.intValue())
            return "Application software version";
        if (type == archive.intValue())
            return "Archive";
        if (type == bias.intValue())
            return "Bias";
        if (type == changeOfStateCount.intValue())
            return "Change of state count";
        if (type == changeOfStateTime.intValue())
            return "Change of state time";
        if (type == notificationClass.intValue())
            return "Notification class";
        if (type == controlledVariableReference.intValue())
            return "Controlled variable reference";
        if (type == controlledVariableUnits.intValue())
            return "Controlled variable units";
        if (type == controlledVariableValue.intValue())
            return "Controlled variable value";
        if (type == covIncrement.intValue())
            return "COV increment";
        if (type == dateList.intValue())
            return "Date list";
        if (type == daylightSavingsStatus.intValue())
            return "Daylight savings status";
        if (type == deadband.intValue())
            return "Deadband";
        if (type == derivativeConstant.intValue())
            return "Derivative constant";
        if (type == derivativeConstantUnits.intValue())
            return "Derivative constant units";
        if (type == description.intValue())
            return "Description";
        if (type == descriptionOfHalt.intValue())
            return "Description of halt";
        if (type == deviceAddressBinding.intValue())
            return "Device address binding";
        if (type == deviceType.intValue())
            return "Device type";
        if (type == effectivePeriod.intValue())
            return "Effective period";
        if (type == elapsedActiveTime.intValue())
            return "Elapsed active time";
        if (type == errorLimit.intValue())
            return "Error limit";
        if (type == eventEnable.intValue())
            return "Event enable";
        if (type == eventState.intValue())
            return "Event state";
        if (type == eventType.intValue())
            return "Event type";
        if (type == exceptionSchedule.intValue())
            return "Exception schedule";
        if (type == faultValues.intValue())
            return "Fault values";
        if (type == feedbackValue.intValue())
            return "Feedback value";
        if (type == fileAccessMethod.intValue())
            return "File access method";
        if (type == fileSize.intValue())
            return "File size";
        if (type == fileType.intValue())
            return "File type";
        if (type == firmwareRevision.intValue())
            return "Firmware revision";
        if (type == highLimit.intValue())
            return "High limit";
        if (type == inactiveText.intValue())
            return "Inactive text";
        if (type == inProcess.intValue())
            return "In process";
        if (type == instanceOf.intValue())
            return "Instance of";
        if (type == integralConstant.intValue())
            return "Integral constant";
        if (type == integralConstantUnits.intValue())
            return "Integral constant units";
        if (type == limitEnable.intValue())
            return "Limit enable";
        if (type == listOfGroupMembers.intValue())
            return "List of group members";
        if (type == listOfObjectPropertyReferences.intValue())
            return "List of object property references";
        if (type == listOfSessionKeys.intValue())
            return "List of session keys";
        if (type == localDate.intValue())
            return "Local date";
        if (type == localTime.intValue())
            return "Local time";
        if (type == location.intValue())
            return "Location";
        if (type == lowLimit.intValue())
            return "Low limit";
        if (type == manipulatedVariableReference.intValue())
            return "Manipulated variable reference";
        if (type == maximumOutput.intValue())
            return "Maximum output";
        if (type == maxApduLengthAccepted.intValue())
            return "Max APDU length accepted";
        if (type == maxInfoFrames.intValue())
            return "Max info frames";
        if (type == maxMaster.intValue())
            return "Max master";
        if (type == maxPresValue.intValue())
            return "Max pres value";
        if (type == minimumOffTime.intValue())
            return "Minimum off time";
        if (type == minimumOnTime.intValue())
            return "Minimum on time";
        if (type == minimumOutput.intValue())
            return "Minimum output";
        if (type == minPresValue.intValue())
            return "Min pres value";
        if (type == modelName.intValue())
            return "Model name";
        if (type == modificationDate.intValue())
            return "Modification date";
        if (type == notifyType.intValue())
            return "Notify type";
        if (type == numberOfApduRetries.intValue())
            return "Number of APDU retries";
        if (type == numberOfStates.intValue())
            return "Number of states";
        if (type == objectIdentifier.intValue())
            return "Object identifier";
        if (type == objectList.intValue())
            return "Object list";
        if (type == objectName.intValue())
            return "Object name";
        if (type == objectPropertyReference.intValue())
            return "Object property reference";
        if (type == objectType.intValue())
            return "Object type";
        if (type == optional.intValue())
            return "Optional";
        if (type == outOfService.intValue())
            return "Out of service";
        if (type == outputUnits.intValue())
            return "Output units";
        if (type == eventParameters.intValue())
            return "Event parameters";
        if (type == polarity.intValue())
            return "Polarity";
        if (type == presentValue.intValue())
            return "Present value";
        if (type == priority.intValue())
            return "Priority";
        if (type == priorityArray.intValue())
            return "Priority array";
        if (type == priorityForWriting.intValue())
            return "Priority for writing";
        if (type == processIdentifier.intValue())
            return "Process identifier";
        if (type == programChange.intValue())
            return "Program change";
        if (type == programLocation.intValue())
            return "Program location";
        if (type == programState.intValue())
            return "Program state";
        if (type == proportionalConstant.intValue())
            return "Proportional constant";
        if (type == proportionalConstantUnits.intValue())
            return "Proportional constant units";
        if (type == protocolObjectTypesSupported.intValue())
            return "Protocol object types supported";
        if (type == protocolServicesSupported.intValue())
            return "Protocol services supported";
        if (type == protocolVersion.intValue())
            return "Protocol version";
        if (type == readOnly.intValue())
            return "Read only";
        if (type == reasonForHalt.intValue())
            return "Reason for halt";
        if (type == recipientList.intValue())
            return "Recipient list";
        if (type == reliability.intValue())
            return "Reliability";
        if (type == relinquishDefault.intValue())
            return "Relinquish default";
        if (type == required.intValue())
            return "Required";
        if (type == resolution.intValue())
            return "Resolution";
        if (type == segmentationSupported.intValue())
            return "Segmentation supported";
        if (type == setpoint.intValue())
            return "Setpoint";
        if (type == setpointReference.intValue())
            return "Setpoint reference";
        if (type == stateText.intValue())
            return "State text";
        if (type == statusFlags.intValue())
            return "Status flags";
        if (type == systemStatus.intValue())
            return "System status";
        if (type == timeDelay.intValue())
            return "Time delay";
        if (type == timeOfActiveTimeReset.intValue())
            return "Time of active time reset";
        if (type == timeOfStateCountReset.intValue())
            return "Time of state count reset";
        if (type == timeSynchronizationRecipients.intValue())
            return "Time synchronization recipients";
        if (type == units.intValue())
            return "Units";
        if (type == updateInterval.intValue())
            return "Update interval";
        if (type == utcOffset.intValue())
            return "UTC offset";
        if (type == vendorIdentifier.intValue())
            return "Vendor identifier";
        if (type == vendorName.intValue())
            return "Vendor name";
        if (type == vtClassesSupported.intValue())
            return "VT classes supported";
        if (type == weeklySchedule.intValue())
            return "Weekly schedule";
        if (type == attemptedSamples.intValue())
            return "Attempted samples";
        if (type == averageValue.intValue())
            return "Average value";
        if (type == bufferSize.intValue())
            return "Buffer size";
        if (type == clientCovIncrement.intValue())
            return "Client COV increment";
        if (type == covResubscriptionInterval.intValue())
            return "COV resubscription interval";
        if (type == eventTimeStamps.intValue())
            return "Event time stamps";
        if (type == logBuffer.intValue())
            return "Log buffer";
        if (type == logDeviceObjectProperty.intValue())
            return "Log device object property";
        if (type == enable.intValue())
            return "enable";
        if (type == logInterval.intValue())
            return "Log interval";
        if (type == maximumValue.intValue())
            return "Maximum value";
        if (type == minimumValue.intValue())
            return "Minimum value";
        if (type == notificationThreshold.intValue())
            return "Notification threshold";
        if (type == protocolRevision.intValue())
            return "Protocol revision";
        if (type == recordsSinceNotification.intValue())
            return "Records since notification";
        if (type == recordCount.intValue())
            return "Record count";
        if (type == startTime.intValue())
            return "Start time";
        if (type == stopTime.intValue())
            return "Stop time";
        if (type == stopWhenFull.intValue())
            return "Stop when full";
        if (type == totalRecordCount.intValue())
            return "Total record count";
        if (type == validSamples.intValue())
            return "Valid samples";
        if (type == windowInterval.intValue())
            return "Window interval";
        if (type == windowSamples.intValue())
            return "Window samples";
        if (type == maximumValueTimestamp.intValue())
            return "Maximum value timestamp";
        if (type == minimumValueTimestamp.intValue())
            return "Minimum value timestamp";
        if (type == varianceValue.intValue())
            return "Variance value";
        if (type == activeCovSubscriptions.intValue())
            return "Active COV subscriptions";
        if (type == backupFailureTimeout.intValue())
            return "Backup failure timeout";
        if (type == configurationFiles.intValue())
            return "Configuration files";
        if (type == databaseRevision.intValue())
            return "Database revision";
        if (type == directReading.intValue())
            return "Direct reading";
        if (type == lastRestoreTime.intValue())
            return "Last restore time";
        if (type == maintenanceRequired.intValue())
            return "Maintenance required";
        if (type == memberOf.intValue())
            return "Member of";
        if (type == mode.intValue())
            return "Mode";
        if (type == operationExpected.intValue())
            return "Operation expected";
        if (type == setting.intValue())
            return "Setting";
        if (type == silenced.intValue())
            return "Silenced";
        if (type == trackingValue.intValue())
            return "Tracking value";
        if (type == zoneMembers.intValue())
            return "Zone members";
        if (type == lifeSafetyAlarmValues.intValue())
            return "Life safety alarm values";
        if (type == maxSegmentsAccepted.intValue())
            return "Max segments accepted";
        if (type == profileName.intValue())
            return "Profile name";
        if (type == autoSlaveDiscovery.intValue())
            return "Auto slave discovery";
        if (type == manualSlaveAddressBinding.intValue())
            return "Manual slave address binding";
        if (type == slaveAddressBinding.intValue())
            return "Slave address binding";
        if (type == slaveProxyEnable.intValue())
            return "Slave proxy enable";
        if (type == lastNotifyRecord.intValue())
            return "Last notify record";
        if (type == scheduleDefault.intValue())
            return "Schedule default";
        if (type == acceptedModes.intValue())
            return "Accepted modes";
        if (type == adjustValue.intValue())
            return "Adjust value";
        if (type == count.intValue())
            return "Count";
        if (type == countBeforeChange.intValue())
            return "Count before change";
        if (type == countChangeTime.intValue())
            return "Count change time";
        if (type == covPeriod.intValue())
            return "COV period";
        if (type == inputReference.intValue())
            return "Input reference";
        if (type == limitMonitoringInterval.intValue())
            return "Limit monitoring interval";
        if (type == loggingObject.intValue())
            return "Logging object";
        if (type == loggingRecord.intValue())
            return "Logging record";
        if (type == prescale.intValue())
            return "Prescale";
        if (type == pulseRate.intValue())
            return "Pulse rate";
        if (type == scale.intValue())
            return "Scale";
        if (type == scaleFactor.intValue())
            return "Scale factor";
        if (type == updateTime.intValue())
            return "Update time";
        if (type == valueBeforeChange.intValue())
            return "Value before change";
        if (type == valueSet.intValue())
            return "Value set";
        if (type == valueChangeTime.intValue())
            return "Value change time";
        if (type == alignIntervals.intValue())
            return "Align Intervals";
        if (type == intervalOffset.intValue())
            return "Interval Offset";
        if (type == lastRestartReason.intValue())
            return "Last Restart Reason";
        if (type == loggingType.intValue())
            return "Logging Type";
        if (type == restartNotificationRecipients.intValue())
            return "Restart Notification Recipients";
        if (type == timeOfDeviceRestart.intValue())
            return "Time Of Device Restart";
        if (type == timeSynchronizationInterval.intValue())
            return "Time Synchronization Interval";
        if (type == trigger.intValue())
            return "Trigger";
        if (type == utcTimeSynchronizationRecipients.intValue())
            return "UTC Time Synchronization Recipients";
        if (type == nodeSubtype.intValue())
            return "Node Subtype";
        if (type == nodeType.intValue())
            return "Node Type";
        if (type == structuredObjectList.intValue())
            return "Structured Object List";
        if (type == subordinateAnnotations.intValue())
            return "Subordinate Annotations";
        if (type == subordinateList.intValue())
            return "Subordinate List";
        if (type == actualShedLevel.intValue())
            return "Actual Shed Level";
        if (type == dutyWindow.intValue())
            return "Duty Window";
        if (type == expectedShedLevel.intValue())
            return "Expected Shed Level";
        if (type == fullDutyBaseline.intValue())
            return "Full Duty Baseline";
        if (type == requestedShedLevel.intValue())
            return "Requested Shed Level";
        if (type == shedDuration.intValue())
            return "Shed Duration";
        if (type == shedLevelDescriptions.intValue())
            return "Shed Level Descriptions";
        if (type == shedLevels.intValue())
            return "Shed Levels";
        if (type == stateDescription.intValue())
            return "State Description";
        if (type == doorAlarmState.intValue())
            return "Door Alarm State";
        if (type == doorExtendedPulseTime.intValue())
            return "Door Extended Pulse Time";
        if (type == doorMembers.intValue())
            return "Door Members";
        if (type == doorOpenTooLongTime.intValue())
            return "Door Open Too Long Time";
        if (type == doorPulseTime.intValue())
            return "Door Pulse Time";
        if (type == doorStatus.intValue())
            return "Door Status";
        if (type == doorUnlockDelayTime.intValue())
            return "Door Unlock Delay Time";
        if (type == lockStatus.intValue())
            return "Lock Status";
        if (type == maskedAlarmValues.intValue())
            return "Masked Alarm Values";
        if (type == securedStatus.intValue())
            return "Secured Status";
        if (type == backupAndRestoreState.intValue())
            return "Backup And Restore State";
        if (type == backupPreparationTime.intValue())
            return "Backup Preparation Time";
        if (type == restoreCompletionTime.intValue())
            return "Restore Completion Time";
        if (type == restorePreparationTime.intValue())
            return "Restore Preparation Time";
        return "Unknown: " + type;
    }
}
}

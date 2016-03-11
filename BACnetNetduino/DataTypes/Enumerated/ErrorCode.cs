using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Enumerated
{
    class ErrorCode : Primitive.Enumerated
    {
        public static readonly ErrorCode other = new ErrorCode(0);
        public static readonly ErrorCode authenticationFailed = new ErrorCode(1);
        public static readonly ErrorCode configurationInProgress = new ErrorCode(2);
        public static readonly ErrorCode deviceBusy = new ErrorCode(3);
        public static readonly ErrorCode dynamicCreationNotSupported = new ErrorCode(4);
        public static readonly ErrorCode fileAccessDenied = new ErrorCode(5);
        public static readonly ErrorCode incompatibleSecurityLevels = new ErrorCode(6);
        public static readonly ErrorCode inconsistentParameters = new ErrorCode(7);
        public static readonly ErrorCode inconsistentSelectionCriterion = new ErrorCode(8);
        public static readonly ErrorCode invalidDataType = new ErrorCode(9);
        public static readonly ErrorCode invalidFileAccessMethod = new ErrorCode(10);
        public static readonly ErrorCode invalidFileStartPosition = new ErrorCode(11);
        public static readonly ErrorCode invalidOperatorName = new ErrorCode(12);
        public static readonly ErrorCode invalidParameterDataType = new ErrorCode(13);
        public static readonly ErrorCode invalidTimeStamp = new ErrorCode(14);
        public static readonly ErrorCode keyGenerationError = new ErrorCode(15);
        public static readonly ErrorCode missingRequiredParameter = new ErrorCode(16);
        public static readonly ErrorCode noObjectsOfSpecifiedType = new ErrorCode(17);
        public static readonly ErrorCode noSpaceForObject = new ErrorCode(18);
        public static readonly ErrorCode noSpaceToAddListElement = new ErrorCode(19);
        public static readonly ErrorCode noSpaceToWriteProperty = new ErrorCode(20);
        public static readonly ErrorCode noVtSessionsAvailable = new ErrorCode(21);
        public static readonly ErrorCode propertyIsNotAList = new ErrorCode(22);
        public static readonly ErrorCode objectDeletionNotPermitted = new ErrorCode(23);
        public static readonly ErrorCode objectIdentifierAlreadyExists = new ErrorCode(24);
        public static readonly ErrorCode operationalProblem = new ErrorCode(25);
        public static readonly ErrorCode passwordFailure = new ErrorCode(26);
        public static readonly ErrorCode readAccessDenied = new ErrorCode(27);
        public static readonly ErrorCode securityNotSupported = new ErrorCode(28);
        public static readonly ErrorCode serviceRequestDenied = new ErrorCode(29);
        public static readonly ErrorCode timeout = new ErrorCode(30);
        public static readonly ErrorCode unknownObject = new ErrorCode(31);
        public static readonly ErrorCode unknownProperty = new ErrorCode(32);
        public static readonly ErrorCode unknownVtClass = new ErrorCode(34);
        public static readonly ErrorCode unknownVtSession = new ErrorCode(35);
        public static readonly ErrorCode unsupportedObjectType = new ErrorCode(36);
        public static readonly ErrorCode valueOutOfRange = new ErrorCode(37);
        public static readonly ErrorCode vtSessionAlreadyClosed = new ErrorCode(38);
        public static readonly ErrorCode vtSessionTerminationFailure = new ErrorCode(39);
        public static readonly ErrorCode writeAccessDenied = new ErrorCode(40);
        public static readonly ErrorCode characterSetNotSupported = new ErrorCode(41);
        public static readonly ErrorCode invalidArrayIndex = new ErrorCode(42);
        public static readonly ErrorCode covSubscriptionFailed = new ErrorCode(43);
        public static readonly ErrorCode notCovProperty = new ErrorCode(44);
        public static readonly ErrorCode optionalFunctionalityNotSupported = new ErrorCode(45);
        public static readonly ErrorCode invalidConfigurationData = new ErrorCode(46);
        public static readonly ErrorCode datatypeNotSupported = new ErrorCode(47);
        public static readonly ErrorCode duplicateName = new ErrorCode(48);
        public static readonly ErrorCode duplicateObjectId = new ErrorCode(49);
        public static readonly ErrorCode propertyIsNotAnArray = new ErrorCode(50);
        public static readonly ErrorCode abortBufferOverflow = new ErrorCode(51);
        public static readonly ErrorCode abortInvalidApduInThisState = new ErrorCode(52);
        public static readonly ErrorCode abortPreemptedByHigherPriorityTask = new ErrorCode(53);
        public static readonly ErrorCode abortSegmentationNotSupported = new ErrorCode(54);
        public static readonly ErrorCode abortProprietary = new ErrorCode(55);
        public static readonly ErrorCode abortOther = new ErrorCode(56);
        public static readonly ErrorCode invalidTag = new ErrorCode(57);
        public static readonly ErrorCode networkDown = new ErrorCode(58);
        public static readonly ErrorCode rejectBufferOverflow = new ErrorCode(59);
        public static readonly ErrorCode rejectInconsistentParameters = new ErrorCode(60);
        public static readonly ErrorCode rejectInvalidParameterDataType = new ErrorCode(61);
        public static readonly ErrorCode rejectInvalidTag = new ErrorCode(62);
        public static readonly ErrorCode rejectMissingRequiredParameter = new ErrorCode(63);
        public static readonly ErrorCode rejectParameterOutOfRange = new ErrorCode(64);
        public static readonly ErrorCode rejectTooManyArguments = new ErrorCode(65);
        public static readonly ErrorCode rejectUndefinedEnumeration = new ErrorCode(66);
        public static readonly ErrorCode rejectUnrecognizedService = new ErrorCode(67);
        public static readonly ErrorCode rejectProprietary = new ErrorCode(68);
        public static readonly ErrorCode rejectOther = new ErrorCode(69);
        public static readonly ErrorCode unknownDevice = new ErrorCode(70);
        public static readonly ErrorCode unknownRoute = new ErrorCode(71);
        public static readonly ErrorCode valueNotInitialized = new ErrorCode(72);
        public static readonly ErrorCode invalidEventState = new ErrorCode(73);
        public static readonly ErrorCode noAlarmConfigured = new ErrorCode(74);
        public static readonly ErrorCode logBufferFull = new ErrorCode(75);
        public static readonly ErrorCode loggedValuePurged = new ErrorCode(76);
        public static readonly ErrorCode noPropertySpecified = new ErrorCode(77);
        public static readonly ErrorCode notConfiguredForTriggeredLogging = new ErrorCode(78);
        public static readonly ErrorCode communicationDisabled = new ErrorCode(83);
        public static readonly ErrorCode unknownFileSize = new ErrorCode(122);

        public static readonly ErrorCode[] ALL = { other, authenticationFailed, configurationInProgress, deviceBusy,
            dynamicCreationNotSupported, fileAccessDenied, incompatibleSecurityLevels, inconsistentParameters,
            inconsistentSelectionCriterion, invalidDataType, invalidFileAccessMethod, invalidFileStartPosition,
            invalidOperatorName, invalidParameterDataType, invalidTimeStamp, keyGenerationError,
            missingRequiredParameter, noObjectsOfSpecifiedType, noSpaceForObject, noSpaceToAddListElement,
            noSpaceToWriteProperty, noVtSessionsAvailable, propertyIsNotAList, objectDeletionNotPermitted,
            objectIdentifierAlreadyExists, operationalProblem, passwordFailure, readAccessDenied, securityNotSupported,
            serviceRequestDenied, timeout, unknownObject, unknownProperty, unknownVtClass, unknownVtSession,
            unsupportedObjectType, valueOutOfRange, vtSessionAlreadyClosed, vtSessionTerminationFailure,
            writeAccessDenied, characterSetNotSupported, invalidArrayIndex, covSubscriptionFailed, notCovProperty,
            optionalFunctionalityNotSupported, invalidConfigurationData, datatypeNotSupported, duplicateName,
            duplicateObjectId, propertyIsNotAnArray, abortBufferOverflow, abortInvalidApduInThisState,
            abortPreemptedByHigherPriorityTask, abortSegmentationNotSupported, abortProprietary, abortOther,
            invalidTag, networkDown, rejectBufferOverflow, rejectInconsistentParameters,
            rejectInvalidParameterDataType, rejectInvalidTag, rejectMissingRequiredParameter,
            rejectParameterOutOfRange, rejectTooManyArguments, rejectUndefinedEnumeration, rejectUnrecognizedService,
            rejectProprietary, rejectOther, unknownDevice, unknownRoute, valueNotInitialized, invalidEventState,
            noAlarmConfigured, logBufferFull, loggedValuePurged, noPropertySpecified, notConfiguredForTriggeredLogging,
            communicationDisabled, unknownFileSize, };

    public ErrorCode(int value) : base(value) { }

    public ErrorCode(ByteStream queue) : base(queue) { }

        public override string ToString()
    {
        int type = intValue();
        if (type == other.intValue())
            return "Other";
        if (type == authenticationFailed.intValue())
            return "Authentication failed";
        if (type == configurationInProgress.intValue())
            return "Configuration in progress";
        if (type == deviceBusy.intValue())
            return "Device busy";
        if (type == dynamicCreationNotSupported.intValue())
            return "Dynamic creation not supported";
        if (type == fileAccessDenied.intValue())
            return "File access denied";
        if (type == incompatibleSecurityLevels.intValue())
            return "Incompatible security levels";
        if (type == inconsistentParameters.intValue())
            return "Inconsistent parameters";
        if (type == inconsistentSelectionCriterion.intValue())
            return "Inconsistent selection criterion";
        if (type == invalidDataType.intValue())
            return "Invalid data type";
        if (type == invalidFileAccessMethod.intValue())
            return "Invalid file access method";
        if (type == invalidFileStartPosition.intValue())
            return "Invalid file start position";
        if (type == invalidOperatorName.intValue())
            return "Invalid operator name";
        if (type == invalidParameterDataType.intValue())
            return "Invalid parameter data type";
        if (type == invalidTimeStamp.intValue())
            return "Invalid time stamp";
        if (type == keyGenerationError.intValue())
            return "Key generation error";
        if (type == missingRequiredParameter.intValue())
            return "Missing required parameter";
        if (type == noObjectsOfSpecifiedType.intValue())
            return "No objects of specified type";
        if (type == noSpaceForObject.intValue())
            return "No space for object";
        if (type == noSpaceToAddListElement.intValue())
            return "No space to add list element";
        if (type == noSpaceToWriteProperty.intValue())
            return "No space to write property";
        if (type == noVtSessionsAvailable.intValue())
            return "No VT sessions available";
        if (type == propertyIsNotAList.intValue())
            return "Property is not a list";
        if (type == objectDeletionNotPermitted.intValue())
            return "Object deletion not permitted";
        if (type == objectIdentifierAlreadyExists.intValue())
            return "Object identifier already exists";
        if (type == operationalProblem.intValue())
            return "Operational problem";
        if (type == passwordFailure.intValue())
            return "Password failure";
        if (type == readAccessDenied.intValue())
            return "Read access denied";
        if (type == securityNotSupported.intValue())
            return "Security not supported";
        if (type == serviceRequestDenied.intValue())
            return "Service request denied";
        if (type == timeout.intValue())
            return "Timeout";
        if (type == unknownObject.intValue())
            return "Unknown object";
        if (type == unknownProperty.intValue())
            return "Unknown property";
        if (type == unknownVtClass.intValue())
            return "Unknown VT class";
        if (type == unknownVtSession.intValue())
            return "Unknown VT session";
        if (type == unsupportedObjectType.intValue())
            return "Unsupported object type";
        if (type == valueOutOfRange.intValue())
            return "Value out of range";
        if (type == vtSessionAlreadyClosed.intValue())
            return "VT session already closed";
        if (type == vtSessionTerminationFailure.intValue())
            return "VT session termination failure";
        if (type == writeAccessDenied.intValue())
            return "Write access denied";
        if (type == characterSetNotSupported.intValue())
            return "Character set not supported";
        if (type == invalidArrayIndex.intValue())
            return "Invalid array index";
        if (type == covSubscriptionFailed.intValue())
            return "Cov subscription failed";
        if (type == notCovProperty.intValue())
            return "Not COV property";
        if (type == optionalFunctionalityNotSupported.intValue())
            return "Optional functionality not supported";
        if (type == invalidConfigurationData.intValue())
            return "Invalid configuration data";
        if (type == datatypeNotSupported.intValue())
            return "Data type not supported";
        if (type == duplicateName.intValue())
            return "Duplicate name";
        if (type == duplicateObjectId.intValue())
            return "Duplicate object id";
        if (type == propertyIsNotAnArray.intValue())
            return "Property is not an array";
        if (type == abortBufferOverflow.intValue())
            return "Abort Buffer Overflow";
        if (type == abortInvalidApduInThisState.intValue())
            return "Abort Invalid Apdu In This State";
        if (type == abortPreemptedByHigherPriorityTask.intValue())
            return "Abort Preempted By Higher Priority Task";
        if (type == abortSegmentationNotSupported.intValue())
            return "Abort Segmentation Not Supported";
        if (type == abortProprietary.intValue())
            return "Abort Proprietary";
        if (type == abortOther.intValue())
            return "Abort Other";
        if (type == invalidTag.intValue())
            return "Invalid Tag";
        if (type == networkDown.intValue())
            return "Network Down";
        if (type == rejectBufferOverflow.intValue())
            return "Reject Buffer Overflow";
        if (type == rejectInconsistentParameters.intValue())
            return "Reject Inconsistent Parameters";
        if (type == rejectInvalidParameterDataType.intValue())
            return "Reject Invalid Parameter Data Type";
        if (type == rejectInvalidTag.intValue())
            return "Reject Invalid Tag";
        if (type == rejectMissingRequiredParameter.intValue())
            return "Reject Missing Required Parameter";
        if (type == rejectParameterOutOfRange.intValue())
            return "Reject Parameter Out Of Range";
        if (type == rejectTooManyArguments.intValue())
            return "Reject Too Many Arguments";
        if (type == rejectUndefinedEnumeration.intValue())
            return "Reject Undefined Enumeration";
        if (type == rejectUnrecognizedService.intValue())
            return "Reject Unrecognized Service";
        if (type == rejectProprietary.intValue())
            return "Reject Proprietary";
        if (type == rejectOther.intValue())
            return "Reject Other";
        if (type == unknownDevice.intValue())
            return "Unknown Device";
        if (type == unknownRoute.intValue())
            return "Unknown Route";
        if (type == valueNotInitialized.intValue())
            return "Value Not Initialized";
        if (type == invalidEventState.intValue())
            return "Invalid Event State";
        if (type == noAlarmConfigured.intValue())
            return "No Alarm Configured";
        if (type == logBufferFull.intValue())
            return "Log Buffer Full";
        if (type == loggedValuePurged.intValue())
            return "Logged Value Purged";
        if (type == noPropertySpecified.intValue())
            return "No Property Specified";
        if (type == notConfiguredForTriggeredLogging.intValue())
            return "Not Configured For Triggered Logging";
        if (type == communicationDisabled.intValue())
            return "Communication Disabled";
        if (type == unknownFileSize.intValue())
            return "Unknown File Size";
        return "Unknown: " + type;
    }
}
    }
}

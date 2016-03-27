namespace BACnetDataTypes.Enumerated
{
    public class ErrorCode : Primitive.Enumerated
    {
        public static readonly ErrorCode Other = new ErrorCode(0);
        public static readonly ErrorCode AuthenticationFailed = new ErrorCode(1);
        public static readonly ErrorCode ConfigurationInProgress = new ErrorCode(2);
        public static readonly ErrorCode DeviceBusy = new ErrorCode(3);
        public static readonly ErrorCode DynamicCreationNotSupported = new ErrorCode(4);
        public static readonly ErrorCode FileAccessDenied = new ErrorCode(5);
        public static readonly ErrorCode IncompatibleSecurityLevels = new ErrorCode(6);
        public static readonly ErrorCode InconsistentParameters = new ErrorCode(7);
        public static readonly ErrorCode InconsistentSelectionCriterion = new ErrorCode(8);
        public static readonly ErrorCode InvalidDataType = new ErrorCode(9);
        public static readonly ErrorCode InvalidFileAccessMethod = new ErrorCode(10);
        public static readonly ErrorCode InvalidFileStartPosition = new ErrorCode(11);
        public static readonly ErrorCode InvalidOperatorName = new ErrorCode(12);
        public static readonly ErrorCode InvalidParameterDataType = new ErrorCode(13);
        public static readonly ErrorCode InvalidTimeStamp = new ErrorCode(14);
        public static readonly ErrorCode KeyGenerationError = new ErrorCode(15);
        public static readonly ErrorCode MissingRequiredParameter = new ErrorCode(16);
        public static readonly ErrorCode NoObjectsOfSpecifiedType = new ErrorCode(17);
        public static readonly ErrorCode NoSpaceForObject = new ErrorCode(18);
        public static readonly ErrorCode NoSpaceToAddListElement = new ErrorCode(19);
        public static readonly ErrorCode NoSpaceToWriteProperty = new ErrorCode(20);
        public static readonly ErrorCode NoVtSessionsAvailable = new ErrorCode(21);
        public static readonly ErrorCode PropertyIsNotAList = new ErrorCode(22);
        public static readonly ErrorCode ObjectDeletionNotPermitted = new ErrorCode(23);
        public static readonly ErrorCode ObjectIdentifierAlreadyExists = new ErrorCode(24);
        public static readonly ErrorCode OperationalProblem = new ErrorCode(25);
        public static readonly ErrorCode PasswordFailure = new ErrorCode(26);
        public static readonly ErrorCode ReadAccessDenied = new ErrorCode(27);
        public static readonly ErrorCode SecurityNotSupported = new ErrorCode(28);
        public static readonly ErrorCode ServiceRequestDenied = new ErrorCode(29);
        public static readonly ErrorCode Timeout = new ErrorCode(30);
        public static readonly ErrorCode UnknownObject = new ErrorCode(31);
        public static readonly ErrorCode UnknownProperty = new ErrorCode(32);
        public static readonly ErrorCode UnknownVtClass = new ErrorCode(34);
        public static readonly ErrorCode UnknownVtSession = new ErrorCode(35);
        public static readonly ErrorCode UnsupportedObjectType = new ErrorCode(36);
        public static readonly ErrorCode ValueOutOfRange = new ErrorCode(37);
        public static readonly ErrorCode VtSessionAlreadyClosed = new ErrorCode(38);
        public static readonly ErrorCode VtSessionTerminationFailure = new ErrorCode(39);
        public static readonly ErrorCode WriteAccessDenied = new ErrorCode(40);
        public static readonly ErrorCode CharacterSetNotSupported = new ErrorCode(41);
        public static readonly ErrorCode InvalidArrayIndex = new ErrorCode(42);
        public static readonly ErrorCode CovSubscriptionFailed = new ErrorCode(43);
        public static readonly ErrorCode NotCovProperty = new ErrorCode(44);
        public static readonly ErrorCode OptionalFunctionalityNotSupported = new ErrorCode(45);
        public static readonly ErrorCode InvalidConfigurationData = new ErrorCode(46);
        public static readonly ErrorCode DatatypeNotSupported = new ErrorCode(47);
        public static readonly ErrorCode DuplicateName = new ErrorCode(48);
        public static readonly ErrorCode DuplicateObjectId = new ErrorCode(49);
        public static readonly ErrorCode PropertyIsNotAnArray = new ErrorCode(50);
        public static readonly ErrorCode AbortBufferOverflow = new ErrorCode(51);
        public static readonly ErrorCode AbortInvalidApduInThisState = new ErrorCode(52);
        public static readonly ErrorCode AbortPreemptedByHigherPriorityTask = new ErrorCode(53);
        public static readonly ErrorCode AbortSegmentationNotSupported = new ErrorCode(54);
        public static readonly ErrorCode AbortProprietary = new ErrorCode(55);
        public static readonly ErrorCode AbortOther = new ErrorCode(56);
        public static readonly ErrorCode InvalidTag = new ErrorCode(57);
        public static readonly ErrorCode NetworkDown = new ErrorCode(58);
        public static readonly ErrorCode RejectBufferOverflow = new ErrorCode(59);
        public static readonly ErrorCode RejectInconsistentParameters = new ErrorCode(60);
        public static readonly ErrorCode RejectInvalidParameterDataType = new ErrorCode(61);
        public static readonly ErrorCode RejectInvalidTag = new ErrorCode(62);
        public static readonly ErrorCode RejectMissingRequiredParameter = new ErrorCode(63);
        public static readonly ErrorCode RejectParameterOutOfRange = new ErrorCode(64);
        public static readonly ErrorCode RejectTooManyArguments = new ErrorCode(65);
        public static readonly ErrorCode RejectUndefinedEnumeration = new ErrorCode(66);
        public static readonly ErrorCode RejectUnrecognizedService = new ErrorCode(67);
        public static readonly ErrorCode RejectProprietary = new ErrorCode(68);
        public static readonly ErrorCode RejectOther = new ErrorCode(69);
        public static readonly ErrorCode UnknownDevice = new ErrorCode(70);
        public static readonly ErrorCode UnknownRoute = new ErrorCode(71);
        public static readonly ErrorCode ValueNotInitialized = new ErrorCode(72);
        public static readonly ErrorCode InvalidEventState = new ErrorCode(73);
        public static readonly ErrorCode NoAlarmConfigured = new ErrorCode(74);
        public static readonly ErrorCode LogBufferFull = new ErrorCode(75);
        public static readonly ErrorCode LoggedValuePurged = new ErrorCode(76);
        public static readonly ErrorCode NoPropertySpecified = new ErrorCode(77);
        public static readonly ErrorCode NotConfiguredForTriggeredLogging = new ErrorCode(78);
        public static readonly ErrorCode CommunicationDisabled = new ErrorCode(83);
        public static readonly ErrorCode UnknownFileSize = new ErrorCode(122);

        public static readonly ErrorCode[] All =
        {
            Other, AuthenticationFailed, ConfigurationInProgress, DeviceBusy,
            DynamicCreationNotSupported, FileAccessDenied, IncompatibleSecurityLevels, InconsistentParameters,
            InconsistentSelectionCriterion, InvalidDataType, InvalidFileAccessMethod, InvalidFileStartPosition,
            InvalidOperatorName, InvalidParameterDataType, InvalidTimeStamp, KeyGenerationError,
            MissingRequiredParameter, NoObjectsOfSpecifiedType, NoSpaceForObject, NoSpaceToAddListElement,
            NoSpaceToWriteProperty, NoVtSessionsAvailable, PropertyIsNotAList, ObjectDeletionNotPermitted,
            ObjectIdentifierAlreadyExists, OperationalProblem, PasswordFailure, ReadAccessDenied, SecurityNotSupported,
            ServiceRequestDenied, Timeout, UnknownObject, UnknownProperty, UnknownVtClass, UnknownVtSession,
            UnsupportedObjectType, ValueOutOfRange, VtSessionAlreadyClosed, VtSessionTerminationFailure,
            WriteAccessDenied, CharacterSetNotSupported, InvalidArrayIndex, CovSubscriptionFailed, NotCovProperty,
            OptionalFunctionalityNotSupported, InvalidConfigurationData, DatatypeNotSupported, DuplicateName,
            DuplicateObjectId, PropertyIsNotAnArray, AbortBufferOverflow, AbortInvalidApduInThisState,
            AbortPreemptedByHigherPriorityTask, AbortSegmentationNotSupported, AbortProprietary, AbortOther,
            InvalidTag, NetworkDown, RejectBufferOverflow, RejectInconsistentParameters,
            RejectInvalidParameterDataType, RejectInvalidTag, RejectMissingRequiredParameter,
            RejectParameterOutOfRange, RejectTooManyArguments, RejectUndefinedEnumeration, RejectUnrecognizedService,
            RejectProprietary, RejectOther, UnknownDevice, UnknownRoute, ValueNotInitialized, InvalidEventState,
            NoAlarmConfigured, LogBufferFull, LoggedValuePurged, NoPropertySpecified, NotConfiguredForTriggeredLogging,
            CommunicationDisabled, UnknownFileSize
        };

        public ErrorCode(uint value) : base(value)
        {
        }

        public ErrorCode(ByteStream queue) : base(queue)
        {
        }

        public override string ToString()
        {
            uint type = Value;
            if (type == Other.Value)
                return "Other";
            if (type == AuthenticationFailed.Value)
                return "Authentication failed";
            if (type == ConfigurationInProgress.Value)
                return "Configuration in progress";
            if (type == DeviceBusy.Value)
                return "Device busy";
            if (type == DynamicCreationNotSupported.Value)
                return "Dynamic creation not supported";
            if (type == FileAccessDenied.Value)
                return "File access denied";
            if (type == IncompatibleSecurityLevels.Value)
                return "Incompatible security levels";
            if (type == InconsistentParameters.Value)
                return "Inconsistent parameters";
            if (type == InconsistentSelectionCriterion.Value)
                return "Inconsistent selection criterion";
            if (type == InvalidDataType.Value)
                return "Invalid data type";
            if (type == InvalidFileAccessMethod.Value)
                return "Invalid file access method";
            if (type == InvalidFileStartPosition.Value)
                return "Invalid file start position";
            if (type == InvalidOperatorName.Value)
                return "Invalid operator name";
            if (type == InvalidParameterDataType.Value)
                return "Invalid parameter data type";
            if (type == InvalidTimeStamp.Value)
                return "Invalid time stamp";
            if (type == KeyGenerationError.Value)
                return "Key generation error";
            if (type == MissingRequiredParameter.Value)
                return "Missing required parameter";
            if (type == NoObjectsOfSpecifiedType.Value)
                return "No objects of specified type";
            if (type == NoSpaceForObject.Value)
                return "No space for object";
            if (type == NoSpaceToAddListElement.Value)
                return "No space to add list element";
            if (type == NoSpaceToWriteProperty.Value)
                return "No space to write property";
            if (type == NoVtSessionsAvailable.Value)
                return "No VT sessions available";
            if (type == PropertyIsNotAList.Value)
                return "Property is not a list";
            if (type == ObjectDeletionNotPermitted.Value)
                return "Object deletion not permitted";
            if (type == ObjectIdentifierAlreadyExists.Value)
                return "Object identifier already exists";
            if (type == OperationalProblem.Value)
                return "Operational problem";
            if (type == PasswordFailure.Value)
                return "Password failure";
            if (type == ReadAccessDenied.Value)
                return "Read access denied";
            if (type == SecurityNotSupported.Value)
                return "Security not supported";
            if (type == ServiceRequestDenied.Value)
                return "Service request denied";
            if (type == Timeout.Value)
                return "Timeout";
            if (type == UnknownObject.Value)
                return "Unknown object";
            if (type == UnknownProperty.Value)
                return "Unknown property";
            if (type == UnknownVtClass.Value)
                return "Unknown VT class";
            if (type == UnknownVtSession.Value)
                return "Unknown VT session";
            if (type == UnsupportedObjectType.Value)
                return "Unsupported object type";
            if (type == ValueOutOfRange.Value)
                return "Value out of range";
            if (type == VtSessionAlreadyClosed.Value)
                return "VT session already closed";
            if (type == VtSessionTerminationFailure.Value)
                return "VT session termination failure";
            if (type == WriteAccessDenied.Value)
                return "Write access denied";
            if (type == CharacterSetNotSupported.Value)
                return "Character set not supported";
            if (type == InvalidArrayIndex.Value)
                return "Invalid array index";
            if (type == CovSubscriptionFailed.Value)
                return "Cov subscription failed";
            if (type == NotCovProperty.Value)
                return "Not COV property";
            if (type == OptionalFunctionalityNotSupported.Value)
                return "Optional functionality not supported";
            if (type == InvalidConfigurationData.Value)
                return "Invalid configuration data";
            if (type == DatatypeNotSupported.Value)
                return "Data type not supported";
            if (type == DuplicateName.Value)
                return "Duplicate name";
            if (type == DuplicateObjectId.Value)
                return "Duplicate object id";
            if (type == PropertyIsNotAnArray.Value)
                return "Property is not an array";
            if (type == AbortBufferOverflow.Value)
                return "Abort Buffer Overflow";
            if (type == AbortInvalidApduInThisState.Value)
                return "Abort Invalid Apdu In This State";
            if (type == AbortPreemptedByHigherPriorityTask.Value)
                return "Abort Preempted By Higher Priority Task";
            if (type == AbortSegmentationNotSupported.Value)
                return "Abort Segmentation Not Supported";
            if (type == AbortProprietary.Value)
                return "Abort Proprietary";
            if (type == AbortOther.Value)
                return "Abort Other";
            if (type == InvalidTag.Value)
                return "Invalid Tag";
            if (type == NetworkDown.Value)
                return "Network Down";
            if (type == RejectBufferOverflow.Value)
                return "Reject Buffer Overflow";
            if (type == RejectInconsistentParameters.Value)
                return "Reject Inconsistent Parameters";
            if (type == RejectInvalidParameterDataType.Value)
                return "Reject Invalid Parameter Data Type";
            if (type == RejectInvalidTag.Value)
                return "Reject Invalid Tag";
            if (type == RejectMissingRequiredParameter.Value)
                return "Reject Missing Required Parameter";
            if (type == RejectParameterOutOfRange.Value)
                return "Reject Parameter Out Of Range";
            if (type == RejectTooManyArguments.Value)
                return "Reject Too Many Arguments";
            if (type == RejectUndefinedEnumeration.Value)
                return "Reject Undefined Enumeration";
            if (type == RejectUnrecognizedService.Value)
                return "Reject Unrecognized Service";
            if (type == RejectProprietary.Value)
                return "Reject Proprietary";
            if (type == RejectOther.Value)
                return "Reject Other";
            if (type == UnknownDevice.Value)
                return "Unknown Device";
            if (type == UnknownRoute.Value)
                return "Unknown Route";
            if (type == ValueNotInitialized.Value)
                return "Value Not Initialized";
            if (type == InvalidEventState.Value)
                return "Invalid Event State";
            if (type == NoAlarmConfigured.Value)
                return "No Alarm Configured";
            if (type == LogBufferFull.Value)
                return "Log Buffer Full";
            if (type == LoggedValuePurged.Value)
                return "Logged Value Purged";
            if (type == NoPropertySpecified.Value)
                return "No Property Specified";
            if (type == NotConfiguredForTriggeredLogging.Value)
                return "Not Configured For Triggered Logging";
            if (type == CommunicationDisabled.Value)
                return "Communication Disabled";
            if (type == UnknownFileSize.Value)
                return "Unknown File Size";
            return "Unknown: " + type;
        }
    }
}

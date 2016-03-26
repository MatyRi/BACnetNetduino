using BACnetDataTypes.Primitive;

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

        public static readonly ErrorCode[] All = { Other, AuthenticationFailed, ConfigurationInProgress, DeviceBusy,
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
            CommunicationDisabled, UnknownFileSize, };

    public ErrorCode(uint value) : base(value) { }

    public ErrorCode(ByteStream queue) : base(queue) { }

        public override string ToString()
    {
        uint type = ((UnsignedInteger) this).Value;
        if (type == ((UnsignedInteger) Other).Value)
            return "Other";
        if (type == ((UnsignedInteger) AuthenticationFailed).Value)
            return "Authentication failed";
        if (type == ((UnsignedInteger) ConfigurationInProgress).Value)
            return "Configuration in progress";
        if (type == ((UnsignedInteger) DeviceBusy).Value)
            return "Device busy";
        if (type == ((UnsignedInteger) DynamicCreationNotSupported).Value)
            return "Dynamic creation not supported";
        if (type == ((UnsignedInteger) FileAccessDenied).Value)
            return "File access denied";
        if (type == ((UnsignedInteger) IncompatibleSecurityLevels).Value)
            return "Incompatible security levels";
        if (type == ((UnsignedInteger) InconsistentParameters).Value)
            return "Inconsistent parameters";
        if (type == ((UnsignedInteger) InconsistentSelectionCriterion).Value)
            return "Inconsistent selection criterion";
        if (type == ((UnsignedInteger) InvalidDataType).Value)
            return "Invalid data type";
        if (type == ((UnsignedInteger) InvalidFileAccessMethod).Value)
            return "Invalid file access method";
        if (type == ((UnsignedInteger) InvalidFileStartPosition).Value)
            return "Invalid file start position";
        if (type == ((UnsignedInteger) InvalidOperatorName).Value)
            return "Invalid operator name";
        if (type == ((UnsignedInteger) InvalidParameterDataType).Value)
            return "Invalid parameter data type";
        if (type == ((UnsignedInteger) InvalidTimeStamp).Value)
            return "Invalid time stamp";
        if (type == ((UnsignedInteger) KeyGenerationError).Value)
            return "Key generation error";
        if (type == ((UnsignedInteger) MissingRequiredParameter).Value)
            return "Missing required parameter";
        if (type == ((UnsignedInteger) NoObjectsOfSpecifiedType).Value)
            return "No objects of specified type";
        if (type == ((UnsignedInteger) NoSpaceForObject).Value)
            return "No space for object";
        if (type == ((UnsignedInteger) NoSpaceToAddListElement).Value)
            return "No space to add list element";
        if (type == ((UnsignedInteger) NoSpaceToWriteProperty).Value)
            return "No space to write property";
        if (type == ((UnsignedInteger) NoVtSessionsAvailable).Value)
            return "No VT sessions available";
        if (type == ((UnsignedInteger) PropertyIsNotAList).Value)
            return "Property is not a list";
        if (type == ((UnsignedInteger) ObjectDeletionNotPermitted).Value)
            return "Object deletion not permitted";
        if (type == ((UnsignedInteger) ObjectIdentifierAlreadyExists).Value)
            return "Object identifier already exists";
        if (type == ((UnsignedInteger) OperationalProblem).Value)
            return "Operational problem";
        if (type == ((UnsignedInteger) PasswordFailure).Value)
            return "Password failure";
        if (type == ((UnsignedInteger) ReadAccessDenied).Value)
            return "Read access denied";
        if (type == ((UnsignedInteger) SecurityNotSupported).Value)
            return "Security not supported";
        if (type == ((UnsignedInteger) ServiceRequestDenied).Value)
            return "Service request denied";
        if (type == ((UnsignedInteger) Timeout).Value)
            return "Timeout";
        if (type == ((UnsignedInteger) UnknownObject).Value)
            return "Unknown object";
        if (type == ((UnsignedInteger) UnknownProperty).Value)
            return "Unknown property";
        if (type == ((UnsignedInteger) UnknownVtClass).Value)
            return "Unknown VT class";
        if (type == ((UnsignedInteger) UnknownVtSession).Value)
            return "Unknown VT session";
        if (type == ((UnsignedInteger) UnsupportedObjectType).Value)
            return "Unsupported object type";
        if (type == ((UnsignedInteger) ValueOutOfRange).Value)
            return "Value out of range";
        if (type == ((UnsignedInteger) VtSessionAlreadyClosed).Value)
            return "VT session already closed";
        if (type == ((UnsignedInteger) VtSessionTerminationFailure).Value)
            return "VT session termination failure";
        if (type == ((UnsignedInteger) WriteAccessDenied).Value)
            return "Write access denied";
        if (type == ((UnsignedInteger) CharacterSetNotSupported).Value)
            return "Character set not supported";
        if (type == ((UnsignedInteger) InvalidArrayIndex).Value)
            return "Invalid array index";
        if (type == ((UnsignedInteger) CovSubscriptionFailed).Value)
            return "Cov subscription failed";
        if (type == ((UnsignedInteger) NotCovProperty).Value)
            return "Not COV property";
        if (type == ((UnsignedInteger) OptionalFunctionalityNotSupported).Value)
            return "Optional functionality not supported";
        if (type == ((UnsignedInteger) InvalidConfigurationData).Value)
            return "Invalid configuration data";
        if (type == ((UnsignedInteger) DatatypeNotSupported).Value)
            return "Data type not supported";
        if (type == ((UnsignedInteger) DuplicateName).Value)
            return "Duplicate name";
        if (type == ((UnsignedInteger) DuplicateObjectId).Value)
            return "Duplicate object id";
        if (type == ((UnsignedInteger) PropertyIsNotAnArray).Value)
            return "Property is not an array";
        if (type == ((UnsignedInteger) AbortBufferOverflow).Value)
            return "Abort Buffer Overflow";
        if (type == ((UnsignedInteger) AbortInvalidApduInThisState).Value)
            return "Abort Invalid Apdu In This State";
        if (type == ((UnsignedInteger) AbortPreemptedByHigherPriorityTask).Value)
            return "Abort Preempted By Higher Priority Task";
        if (type == ((UnsignedInteger) AbortSegmentationNotSupported).Value)
            return "Abort Segmentation Not Supported";
        if (type == ((UnsignedInteger) AbortProprietary).Value)
            return "Abort Proprietary";
        if (type == ((UnsignedInteger) AbortOther).Value)
            return "Abort Other";
        if (type == ((UnsignedInteger) InvalidTag).Value)
            return "Invalid Tag";
        if (type == ((UnsignedInteger) NetworkDown).Value)
            return "Network Down";
        if (type == ((UnsignedInteger) RejectBufferOverflow).Value)
            return "Reject Buffer Overflow";
        if (type == ((UnsignedInteger) RejectInconsistentParameters).Value)
            return "Reject Inconsistent Parameters";
        if (type == ((UnsignedInteger) RejectInvalidParameterDataType).Value)
            return "Reject Invalid Parameter Data Type";
        if (type == ((UnsignedInteger) RejectInvalidTag).Value)
            return "Reject Invalid Tag";
        if (type == ((UnsignedInteger) RejectMissingRequiredParameter).Value)
            return "Reject Missing Required Parameter";
        if (type == ((UnsignedInteger) RejectParameterOutOfRange).Value)
            return "Reject Parameter Out Of Range";
        if (type == ((UnsignedInteger) RejectTooManyArguments).Value)
            return "Reject Too Many Arguments";
        if (type == ((UnsignedInteger) RejectUndefinedEnumeration).Value)
            return "Reject Undefined Enumeration";
        if (type == ((UnsignedInteger) RejectUnrecognizedService).Value)
            return "Reject Unrecognized Service";
        if (type == ((UnsignedInteger) RejectProprietary).Value)
            return "Reject Proprietary";
        if (type == ((UnsignedInteger) RejectOther).Value)
            return "Reject Other";
        if (type == ((UnsignedInteger) UnknownDevice).Value)
            return "Unknown Device";
        if (type == ((UnsignedInteger) UnknownRoute).Value)
            return "Unknown Route";
        if (type == ((UnsignedInteger) ValueNotInitialized).Value)
            return "Value Not Initialized";
        if (type == ((UnsignedInteger) InvalidEventState).Value)
            return "Invalid Event State";
        if (type == ((UnsignedInteger) NoAlarmConfigured).Value)
            return "No Alarm Configured";
        if (type == ((UnsignedInteger) LogBufferFull).Value)
            return "Log Buffer Full";
        if (type == ((UnsignedInteger) LoggedValuePurged).Value)
            return "Logged Value Purged";
        if (type == ((UnsignedInteger) NoPropertySpecified).Value)
            return "No Property Specified";
        if (type == ((UnsignedInteger) NotConfiguredForTriggeredLogging).Value)
            return "Not Configured For Triggered Logging";
        if (type == ((UnsignedInteger) CommunicationDisabled).Value)
            return "Communication Disabled";
        if (type == ((UnsignedInteger) UnknownFileSize).Value)
            return "Unknown File Size";
        return "Unknown: " + type;
    }
}
    }

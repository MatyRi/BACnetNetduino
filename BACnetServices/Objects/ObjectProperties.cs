using System;
using System.Collections;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;
using BACnetDataTypes.Primitive;

namespace BACnetServices.Objects
{
    class ObjectProperties
    {

        private ObjectProperties INSTANCE = new ObjectProperties();


        //private static readonly Map<typeof(ObjectType, List<PropertyTypeDefinition>> propertyTypes = new HashMap<typeof(ObjectType, List<PropertyTypeDefinition>>();

        private static readonly Hashtable propertyTypes = new Hashtable();


        public static PropertyTypeDefinition getPropertyTypeDefinition(ObjectType objectType, PropertyIdentifier propertyIdentifier)
        {
            IList list = (IList) propertyTypes[objectType];
            if (list == null)
                return null;

            foreach (PropertyTypeDefinition def in list)
            {
                if (def.getPropertyIdentifier().Equals(propertyIdentifier))
                    return def;
            }

            return null;
        }

        public static PropertyTypeDefinition getPropertyTypeDefinitionRequired(ObjectType objectType, PropertyIdentifier propertyIdentifier)
        {
            PropertyTypeDefinition def = getPropertyTypeDefinition(objectType, propertyIdentifier);
            if (def == null)
                throw new BACnetServiceException(ErrorClass.property, ErrorCode.unknownProperty, objectType + "/" + propertyIdentifier);
            return def;
        }

 public static void validateValue(ObjectType objectType, PropertyIdentifier propertyIdentifier, Encodable value)
    {
        PropertyTypeDefinition def = getPropertyTypeDefinitionRequired(objectType, propertyIdentifier);
        if (def.isSequence()) {
            SequenceOf seq = (SequenceOf)value;
            foreach (Encodable e in seq)
            {
                if (!def.getType().IsInstanceOfType(e)) // TODO IsAssignableFrom
                    throw new BACnetServiceException(ErrorClass.property, ErrorCode.invalidDataType, "expected "
                            + def.getType() + ", received=" + value.GetType());
            }
        }
        //else if (!def.getClazz().isAssignableFrom(value.getClass()))
        else if (!def.getType().IsInstanceOfType(value))
                throw new BACnetServiceException(ErrorClass.property, ErrorCode.invalidDataType, "expected "
                    + def.getType() + ", received=" + value.GetType());
    }

public static void validateSequenceValue(ObjectType objectType, PropertyIdentifier propertyIdentifier, Encodable value) 
{
    PropertyTypeDefinition def = getPropertyTypeDefinitionRequired(objectType, propertyIdentifier);
        if (!def.isSequence())
            throw new BACnetServiceException(ErrorClass.property, ErrorCode.propertyIsNotAnArray);
            //if (!def.getClazz().isAssignableFrom(value.getClass()))
            if (!def.getType().IsInstanceOfType(value))
                throw new BACnetServiceException(ErrorClass.property, ErrorCode.invalidDataType);
    }

    public static IList getPropertyTypeDefinitions(ObjectType objectType)
{
    return getPropertyTypeDefinitions(objectType, 0);
}

public static IList getRequiredPropertyTypeDefinitions(ObjectType objectType)
{
    return getPropertyTypeDefinitions(objectType, 1);
}

public static IList getOptionalPropertyTypeDefinitions(ObjectType objectType)
{
    return getPropertyTypeDefinitions(objectType, 2);
}

public static bool isCommandable(ObjectType oType, PropertyIdentifier pid)
{
    if (!pid.Equals(PropertyIdentifier.presentValue))
        return false;
    return oType.Equals(ObjectType.analogOutput) || oType.Equals(ObjectType.analogValue)
            || oType.Equals(ObjectType.binaryOutput) || oType.Equals(ObjectType.binaryValue)
            || oType.Equals(ObjectType.multiStateOutput) || oType.Equals(ObjectType.multiStateValue)
            || oType.Equals(ObjectType.accessDoor);
}

/**
 * @param objectType
 * @param include
 *            0 = all, 1 = required, 2 = optional
 * @return
 */
private static IList getPropertyTypeDefinitions(ObjectType objectType, int include)
{
    IList result = new ArrayList();
    IList list = (IList) propertyTypes[objectType];
    if (list != null)
    {
        foreach (PropertyTypeDefinition def in list)
        {
            if (include == 0 || (include == 1 && def.isRequired()) || (include == 2 && def.isOptional()))
                result.Add(def);
        }
    }
    return result;
}

private static void add(ObjectType oType, PropertyIdentifier pid, Type type, bool sequence, bool required, Encodable defaultValue)
{
    IList list = (IList) propertyTypes[oType];
    if (list == null)
    {
        list = new ArrayList();
        propertyTypes[oType] = list;
    }

    // Check for existing entries.
    foreach (PropertyTypeDefinition def in list)
    {
        if (def.getPropertyIdentifier().Equals(pid))
        {
            list.Remove(def);
            break;
        }
    }

    list.Add(new PropertyTypeDefinition(oType, pid, type, sequence, required, defaultValue));
}

public static void addPropertyTypeDefinition(ObjectType oType, PropertyIdentifier pid, Type type, bool sequence, bool required, Encodable defaultValue)
{
    IList list = (IList) propertyTypes[oType];
    if (list == null)
        throw new System.Exception("ObjectType not found: " + oType);

    // Check for existing entries.
    foreach (PropertyTypeDefinition def in list)
    {
        if (def.getPropertyIdentifier().Equals(pid))
            throw new System.Exception("ObjectType already contains the given PropertyIdentifier");
    }

    list.Add(new PropertyTypeDefinition(oType, pid, type, sequence, required, defaultValue));
}

        private void Init()
        {
            /*
        // Access door
        add(ObjectType.accessDoor, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.accessDoor, 0x3fffff));
        add(ObjectType.accessDoor, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.accessDoor, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.accessDoor);
        add(ObjectType.accessDoor, PropertyIdentifier.presentValue, typeof(DoorValue), false, true, null);
        add(ObjectType.accessDoor, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.accessDoor, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.accessDoor, PropertyIdentifier.reliability, typeof(Reliability), false, true, null);
        add(ObjectType.accessDoor, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.accessDoor, PropertyIdentifier.priorityArray, typeof(PriorityArray), false, true, new PriorityArray());
        add(ObjectType.accessDoor, PropertyIdentifier.relinquishDefault, typeof(DoorValue), false, true, DoorValue.lock);
        add(ObjectType.accessDoor, PropertyIdentifier.doorStatus, typeof(DoorStatus), false, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.lockStatus, typeof(LockStatus), false, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.securedStatus, typeof(DoorSecuredStatus), false, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.doorMembers, typeof(DeviceObjectReference), true, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.doorPulseTime, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.accessDoor, PropertyIdentifier.doorExtendedPulseTime, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.accessDoor, PropertyIdentifier.doorUnlockDelayTime, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.doorOpenTooLongTime, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.accessDoor, PropertyIdentifier.doorAlarmState, typeof(DoorAlarmState), false, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.maskedAlarmValues, typeof(DoorAlarmState), true, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.maintenanceRequired, typeof(Maintenance), false, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.alarmValues, typeof(DoorAlarmState), true, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.faultValues, typeof(DoorAlarmState), true, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.accessDoor, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Accumulator
        add(ObjectType.accumulator, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.accumulator, 0x3fffff));
        add(ObjectType.accumulator, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.accumulator, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.accumulator);
        add(ObjectType.accumulator, PropertyIdentifier.presentValue, typeof(UnsignedInteger), false, true, new UnsignedInteger(0));
        add(ObjectType.accumulator, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.deviceType, typeof(CharacterString), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.accumulator, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.accumulator, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.accumulator, PropertyIdentifier.scale, typeof(Scale), false, true, null);
        add(ObjectType.accumulator, PropertyIdentifier.units, typeof(EngineeringUnits), false, true, EngineeringUnits.noUnits);
        add(ObjectType.accumulator, PropertyIdentifier.prescale, typeof(Prescale), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.maxPresValue, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.accumulator, PropertyIdentifier.valueChangeTime, typeof(typeof(DateTime), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.valueBeforeChange, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.valueSet, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.loggingRecord, typeof(AccumulatorRecord), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.loggingObject, typeof(ObjectIdentifier), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.pulseRate, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.highLimit, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.lowLimit, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.limitMonitoringInterval, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.limitEnable, typeof(LimitEnable), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.accumulator, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Analog input
        add(ObjectType.analogInput, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.analogInput, 0x3fffff));
        add(ObjectType.analogInput, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.analogInput, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.analogInput);
        add(ObjectType.analogInput, PropertyIdentifier.presentValue, typeof(Real), false, true, new Real(0));
        add(ObjectType.analogInput, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.deviceType, typeof(CharacterString), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.analogInput, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.analogInput, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.analogInput, PropertyIdentifier.updateInterval, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.units, typeof(EngineeringUnits), false, true, EngineeringUnits.noUnits);
        add(ObjectType.analogInput, PropertyIdentifier.minPresValue, typeof(Real), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.maxPresValue, typeof(Real), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.resolution, typeof(Real), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.covIncrement, typeof(Real), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.highLimit, typeof(Real), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.lowLimit, typeof(Real), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.deadband, typeof(Real), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.limitEnable, typeof(LimitEnable), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.analogInput, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Analog output
        add(ObjectType.analogOutput, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.analogOutput, 0x3fffff));
        add(ObjectType.analogOutput, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.analogOutput, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.analogOutput);
        add(ObjectType.analogOutput, PropertyIdentifier.presentValue, typeof(Real), false, true, new Real(0));
        add(ObjectType.analogOutput, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.deviceType, typeof(CharacterString), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.analogOutput, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.analogOutput, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.analogOutput, PropertyIdentifier.units, typeof(EngineeringUnits), false, true, EngineeringUnits.noUnits);
        add(ObjectType.analogOutput, PropertyIdentifier.minPresValue, typeof(Real), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.maxPresValue, typeof(Real), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.resolution, typeof(Real), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.priorityArray, typeof(PriorityArray), false, true, new PriorityArray());
        add(ObjectType.analogOutput, PropertyIdentifier.relinquishDefault, typeof(Real), false, true, new Real(0));
        add(ObjectType.analogOutput, PropertyIdentifier.covIncrement, typeof(Real), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.highLimit, typeof(Real), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.lowLimit, typeof(Real), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.deadband, typeof(Real), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.limitEnable, typeof(LimitEnable), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.analogOutput, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Analog value
        add(ObjectType.analogValue, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.analogValue, 0x3fffff));
        add(ObjectType.analogValue, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.analogValue, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.analogValue);
        add(ObjectType.analogValue, PropertyIdentifier.presentValue, typeof(Real), false, true, new Real(0));
        add(ObjectType.analogValue, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.analogValue, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.analogValue, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.analogValue, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);
        add(ObjectType.analogValue, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.analogValue, PropertyIdentifier.units, typeof(EngineeringUnits), false, true, EngineeringUnits.noUnits);
        add(ObjectType.analogValue, PropertyIdentifier.priorityArray, typeof(PriorityArray), false, false, new PriorityArray());
        add(ObjectType.analogValue, PropertyIdentifier.relinquishDefault, typeof(Real), false, false, new Real(0));
        add(ObjectType.analogValue, PropertyIdentifier.covIncrement, typeof(Real), false, false, null);
        add(ObjectType.analogValue, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.analogValue, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.analogValue, PropertyIdentifier.highLimit, typeof(Real), false, false, null);
        add(ObjectType.analogValue, PropertyIdentifier.lowLimit, typeof(Real), false, false, null);
        add(ObjectType.analogValue, PropertyIdentifier.deadband, typeof(Real), false, false, null);
        add(ObjectType.analogValue, PropertyIdentifier.limitEnable, typeof(LimitEnable), false, false, null);
        add(ObjectType.analogValue, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.analogValue, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.analogValue, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.analogValue, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.analogValue, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Averaging
        add(ObjectType.averaging, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true,
                new ObjectIdentifier(ObjectType.averaging, 0x3fffff));
        add(ObjectType.averaging, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.averaging, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.averaging);
        add(ObjectType.averaging, PropertyIdentifier.minimumValue, typeof(Real), false, true, new Real(0));
        add(ObjectType.averaging, PropertyIdentifier.minimumValueTimestamp, typeof(DateTime), false, false, null);
        add(ObjectType.averaging, PropertyIdentifier.averageValue, typeof(Real), false, true, new Real(0));
        add(ObjectType.averaging, PropertyIdentifier.varianceValue, typeof(Real), false, false, null);
        add(ObjectType.averaging, PropertyIdentifier.maximumValue, typeof(Real), false, true, new Real(0));
        add(ObjectType.averaging, PropertyIdentifier.maximumValueTimestamp, typeof(DateTime), false, false, null);
        add(ObjectType.averaging, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.averaging, PropertyIdentifier.attemptedSamples, typeof(UnsignedInteger), false, true, new UnsignedInteger(0));
        add(ObjectType.averaging, PropertyIdentifier.validSamples, typeof(UnsignedInteger), false, true, new UnsignedInteger(0));
        add(ObjectType.averaging, PropertyIdentifier.objectPropertyReference, typeof(DeviceObjectPropertyReference), false, true, null);
        add(ObjectType.averaging, PropertyIdentifier.windowInterval, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.averaging, PropertyIdentifier.windowSamples, typeof(UnsignedInteger), false, true, new UnsignedInteger(0));
        add(ObjectType.averaging, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Binary input
        add(ObjectType.binaryInput, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.binaryInput, 0x3fffff));
        add(ObjectType.binaryInput, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.binaryInput, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.binaryInput);
        add(ObjectType.binaryInput, PropertyIdentifier.presentValue, typeof(BinaryPV), false, true, BinaryPV.inactive);
        add(ObjectType.binaryInput, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.deviceType, typeof(CharacterString), false, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.binaryInput, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.binaryInput, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.binaryInput, PropertyIdentifier.polarity, typeof(Polarity), false, true, Polarity.normal);
        add(ObjectType.binaryInput, PropertyIdentifier.inactiveText, typeof(CharacterString), false, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.activeText, typeof(CharacterString), false, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.changeOfStateTime, typeof(DateTime), false, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.changeOfStateCount, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.timeOfStateCountReset, typeof(DateTime), false, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.elapsedActiveTime, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.timeOfActiveTimeReset, typeof(DateTime), false, false, null);
        //AdK
        add(ObjectType.binaryInput, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.alarmValue, typeof(BinaryPV), false, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.binaryInput, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Binary output
        add(ObjectType.binaryOutput, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.binaryOutput, 0x3fffff));
        add(ObjectType.binaryOutput, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.binaryOutput);
        add(ObjectType.binaryOutput, PropertyIdentifier.presentValue, typeof(BinaryPV), false, true, BinaryPV.inactive);
        add(ObjectType.binaryOutput, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.deviceType, typeof(CharacterString), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.binaryOutput, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.binaryOutput, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.binaryOutput, PropertyIdentifier.polarity, typeof(Polarity), false, true, Polarity.normal);
        add(ObjectType.binaryOutput, PropertyIdentifier.inactiveText, typeof(CharacterString), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.activeText, typeof(CharacterString), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.changeOfStateTime, typeof(DateTime), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.changeOfStateCount, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.timeOfStateCountReset, typeof(DateTime), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.elapsedActiveTime, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.timeOfActiveTimeReset, typeof(DateTime), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.minimumOffTime, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.minimumOnTime, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.priorityArray, typeof(PriorityArray), false, true, new PriorityArray());
        add(ObjectType.binaryOutput, PropertyIdentifier.relinquishDefault, typeof(BinaryPV), false, true, BinaryPV.inactive);
        add(ObjectType.binaryOutput, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.feedbackValue, typeof(BinaryPV), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.binaryOutput, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Binary value
        add(ObjectType.binaryValue, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true,
                new ObjectIdentifier(ObjectType.binaryValue, 0x3fffff));
        add(ObjectType.binaryValue, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.binaryValue, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.binaryValue);
        add(ObjectType.binaryValue, PropertyIdentifier.presentValue, typeof(BinaryPV), false, true, BinaryPV.inactive);
        add(ObjectType.binaryValue, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.binaryValue, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.binaryValue, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.binaryValue, PropertyIdentifier.inactiveText, typeof(CharacterString), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.activeText, typeof(CharacterString), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.changeOfStateTime, typeof(DateTime), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.changeOfStateCount, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.timeOfStateCountReset, typeof(DateTime), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.elapsedActiveTime, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.timeOfActiveTimeReset, typeof(DateTime), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.minimumOffTime, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.minimumOnTime, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.priorityArray, typeof(PriorityArray), false, false, new PriorityArray());
        add(ObjectType.binaryValue, PropertyIdentifier.relinquishDefault, typeof(BinaryPV), false, false, BinaryPV.inactive);
        add(ObjectType.binaryValue, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.alarmValue, typeof(BinaryPV), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.binaryValue, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Calendar
        add(ObjectType.calendar, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.calendar, 0x3fffff));
        add(ObjectType.calendar, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.calendar, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.calendar);
        add(ObjectType.calendar, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.calendar, PropertyIdentifier.presentValue, typeof(BBoolean), false, true, null);
        add(ObjectType.calendar, PropertyIdentifier.dateList, typeof(CalendarEntry), true, true, null);
        add(ObjectType.calendar, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Command
        add(ObjectType.command, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.command, 0x3fffff));
        add(ObjectType.command, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.command, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.command);
        add(ObjectType.command, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.command, PropertyIdentifier.presentValue, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.command, PropertyIdentifier.inProcess, typeof(BBoolean), false, true, null);
        add(ObjectType.command, PropertyIdentifier.allWritesSuccessful, typeof(BBoolean), false, true, null);
        add(ObjectType.command, PropertyIdentifier.action, typeof(ActionList), true, true, null);
        add(ObjectType.command, PropertyIdentifier.actionText, typeof(CharacterString), true, false, null);
        add(ObjectType.command, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

    */

        // Device
        add(ObjectType.device, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.device, 0x3fffff));
        add(ObjectType.device, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.device, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.device);
        add(ObjectType.device, PropertyIdentifier.systemStatus, typeof(DeviceStatus), false, true, null);
        add(ObjectType.device, PropertyIdentifier.vendorName, typeof(CharacterString), false, true, null);
        add(ObjectType.device, PropertyIdentifier.vendorIdentifier, typeof(Unsigned16), false, true, null);
        add(ObjectType.device, PropertyIdentifier.modelName, typeof(CharacterString), false, true, null);
        add(ObjectType.device, PropertyIdentifier.firmwareRevision, typeof(CharacterString), false, true, null);
        add(ObjectType.device, PropertyIdentifier.applicationSoftwareVersion, typeof(CharacterString), false, true, null);
        add(ObjectType.device, PropertyIdentifier.location, typeof(CharacterString), false, false, null);
        add(ObjectType.device, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.device, PropertyIdentifier.protocolVersion, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.device, PropertyIdentifier.protocolRevision, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.device, PropertyIdentifier.protocolServicesSupported, typeof(ServicesSupported), false, true, null);
        add(ObjectType.device, PropertyIdentifier.protocolObjectTypesSupported, typeof(ObjectTypesSupported), false, true, null);
        add(ObjectType.device, PropertyIdentifier.objectList, typeof(ObjectIdentifier), true, true, null);
        add(ObjectType.device, PropertyIdentifier.structuredObjectList, typeof(ObjectIdentifier), true, false, null);
        add(ObjectType.device, PropertyIdentifier.maxApduLengthAccepted, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.device, PropertyIdentifier.segmentationSupported, typeof(Segmentation), false, true, null);
        add(ObjectType.device, PropertyIdentifier.vtClassesSupported, typeof(VtClass), true, false, null);
        add(ObjectType.device, PropertyIdentifier.activeVtSessions, typeof(VtSession), true, false, null);
        add(ObjectType.device, PropertyIdentifier.localTime, typeof(Time), false, false, null);
        add(ObjectType.device, PropertyIdentifier.localDate, typeof(Date), false, false, null);
        add(ObjectType.device, PropertyIdentifier.utcOffset, typeof(SignedInteger), false, false, null);
        add(ObjectType.device, PropertyIdentifier.daylightSavingsStatus, typeof(BBoolean), false, false, null);
        add(ObjectType.device, PropertyIdentifier.apduSegmentTimeout, typeof(UnsignedInteger), false, true, new UnsignedInteger(1000));
        add(ObjectType.device, PropertyIdentifier.apduTimeout, typeof(UnsignedInteger), false, true, new UnsignedInteger(5000));
        add(ObjectType.device, PropertyIdentifier.numberOfApduRetries, typeof(UnsignedInteger), false, true, new UnsignedInteger(2));
        add(ObjectType.device, PropertyIdentifier.listOfSessionKeys, typeof(SessionKey), true, false, null);
        add(ObjectType.device, PropertyIdentifier.timeSynchronizationRecipients, typeof(Recipient), true, false, null);
        add(ObjectType.device, PropertyIdentifier.maxMaster, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.device, PropertyIdentifier.maxInfoFrames, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.device, PropertyIdentifier.deviceAddressBinding, typeof(AddressBinding), true, true, new SequenceOf()); // AddressBinding
        add(ObjectType.device, PropertyIdentifier.databaseRevision, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.device, PropertyIdentifier.configurationFiles, typeof(ObjectIdentifier), true, false, null);
        add(ObjectType.device, PropertyIdentifier.lastRestoreTime, typeof(TimeStamp), false, false, null);
        add(ObjectType.device, PropertyIdentifier.backupFailureTimeout, typeof(Unsigned16), false, false, null);
        add(ObjectType.device, PropertyIdentifier.backupPreparationTime, typeof(Unsigned16), false, false, null);
        add(ObjectType.device, PropertyIdentifier.restorePreparationTime, typeof(Unsigned16), false, false, null);
        add(ObjectType.device, PropertyIdentifier.restoreCompletionTime, typeof(Unsigned16), false, false, null);
        add(ObjectType.device, PropertyIdentifier.backupAndRestoreState, typeof(BackupState), false, true, null);
        add(ObjectType.device, PropertyIdentifier.activeCovSubscriptions, typeof(CovSubscription), true, true, new SequenceOf()); // CovSubscription
        add(ObjectType.device, PropertyIdentifier.maxSegmentsAccepted, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.device, PropertyIdentifier.utcTimeSynchronizationRecipients, typeof(Recipient), true, false, null);
        add(ObjectType.device, PropertyIdentifier.timeSynchronizationInterval, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.device, PropertyIdentifier.alignIntervals, typeof(BBoolean), false, false, null);
        add(ObjectType.device, PropertyIdentifier.intervalOffset, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.device, PropertyIdentifier.slaveProxyEnable, typeof(BBoolean), true, false, null);
        add(ObjectType.device, PropertyIdentifier.autoSlaveDiscovery, typeof(BBoolean), true, false, null);
        add(ObjectType.device, PropertyIdentifier.slaveAddressBinding, typeof(AddressBinding), true, false, null);
        add(ObjectType.device, PropertyIdentifier.manualSlaveAddressBinding, typeof(AddressBinding), true, false, null);
        add(ObjectType.device, PropertyIdentifier.lastRestartReason, typeof(RestartReason), false, false, null);
        add(ObjectType.device, PropertyIdentifier.restartNotificationRecipients, typeof(Recipient), true, false, null);
        add(ObjectType.device, PropertyIdentifier.timeOfDeviceRestart, typeof(TimeStamp), false, false, null);
        add(ObjectType.device, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

            /*
        // Event enrollment
        add(ObjectType.eventEnrollment, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.eventEnrollment, 0x3fffff));
        add(ObjectType.eventEnrollment, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.eventEnrollment, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.eventEnrollment);
        add(ObjectType.eventEnrollment, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.eventEnrollment, PropertyIdentifier.eventType, typeof(EventType), false, true, null);
        add(ObjectType.eventEnrollment, PropertyIdentifier.notifyType, typeof(NotifyType), false, true, null);
        add(ObjectType.eventEnrollment, PropertyIdentifier.eventParameters, typeof(EventParameter), false, true, null);
        add(ObjectType.eventEnrollment, PropertyIdentifier.objectPropertyReference, typeof(DeviceObjectPropertyReference), false, true, null);
        add(ObjectType.eventEnrollment, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.eventEnrollment, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, true, null);
        add(ObjectType.eventEnrollment, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, true, null);
        add(ObjectType.eventEnrollment, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.eventEnrollment, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, true, null);
        add(ObjectType.eventEnrollment, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Event log
        add(ObjectType.eventLog, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.eventLog, 0x3fffff));
        add(ObjectType.eventLog, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.eventLog, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.eventLog);
        add(ObjectType.eventLog, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.eventLog, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.eventLog, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.eventLog, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);
        add(ObjectType.eventLog, PropertyIdentifier.enable, typeof(BBoolean), false, true, null);
        add(ObjectType.eventLog, PropertyIdentifier.startTime, typeof(DateTime), false, false, null);
        add(ObjectType.eventLog, PropertyIdentifier.stopTime, typeof(DateTime), false, false, null);
        add(ObjectType.eventLog, PropertyIdentifier.stopWhenFull, typeof(BBoolean), false, true, null);
        add(ObjectType.eventLog, PropertyIdentifier.bufferSize, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.eventLog, PropertyIdentifier.logBuffer, typeof(EventLogRecord), true, true, new SequenceOf<EventLogRecord>());
        add(ObjectType.eventLog, PropertyIdentifier.recordCount, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.eventLog, PropertyIdentifier.totalRecordCount, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.eventLog, PropertyIdentifier.notificationThreshold, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.eventLog, PropertyIdentifier.recordsSinceNotification, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.eventLog, PropertyIdentifier.lastNotifyRecord, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.eventLog, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.eventLog, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.eventLog, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.eventLog, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.eventLog, PropertyIdentifier.eventTimeStamps, TimeStamp), true, false, null);
        add(ObjectType.eventLog, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // File
        add(ObjectType.file, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.file, 0x3fffff));
        add(ObjectType.file, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.file, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.file);
        add(ObjectType.file, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.file, PropertyIdentifier.fileType, typeof(CharacterString), false, true, null);
        add(ObjectType.file, PropertyIdentifier.fileSize, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.file, PropertyIdentifier.modificationDate, typeof(DateTime), false, true, null);
        add(ObjectType.file, PropertyIdentifier.archive, typeof(BBoolean), false, true, null);
        add(ObjectType.file, PropertyIdentifier.readOnly, typeof(BBoolean), false, true, null);
        add(ObjectType.file, PropertyIdentifier.fileAccessMethod, typeof(FileAccessMethod), false, true, null);
        add(ObjectType.file, PropertyIdentifier.recordCount, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.file, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Group
        add(ObjectType.group, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.group, 0x3fffff));
        add(ObjectType.group, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.group, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.group);
        add(ObjectType.group, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.group, PropertyIdentifier.listOfGroupMembers, typeof(ReadAccessSpecification), true, true, null);
        add(ObjectType.group, PropertyIdentifier.presentValue, typeof(ReadAccessResult), true, true, null);
        add(ObjectType.group, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Life safety point
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.lifeSafetyPoint, 0x3fffff));
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.lifeSafetyPoint);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.presentValue, typeof(LifeSafetyState), false, true, LifeSafetyState.quiet);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.trackingValue, typeof(LifeSafetyState), false, true, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.deviceType, typeof(CharacterString), false, false, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.reliability, typeof(Reliability), false, true, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.mode, typeof(LifeSafetyMode), false, true, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.acceptedModes, typeof(LifeSafetyMode), true, true, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.lifeSafetyAlarmValues, typeof(LifeSafetyState), true, false, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.alarmValues, typeof(LifeSafetyState), true, false, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.faultValues, typeof(LifeSafetyState), true, false, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.silenced, typeof(SilencedState), false, true, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.operationExpected, typeof(LifeSafetyOperation), false, true, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.maintenanceRequired, typeof(Maintenance), false, false, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.setting, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.directReading, typeof(Real), false, false, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.units, typeof(EngineeringUnits), false, true, EngineeringUnits.noUnits);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.memberOf, typeof(DeviceObjectReference), true, false, null);
        add(ObjectType.lifeSafetyPoint, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Life safety zone
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.lifeSafetyZone, 0x3fffff));
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.lifeSafetyZone);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.presentValue, typeof(LifeSafetyState), false, true, LifeSafetyState.quiet);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.trackingValue, typeof(LifeSafetyState), false, true, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.deviceType, typeof(CharacterString), false, false, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.reliability, typeof(Reliability), false, true, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.mode, typeof(LifeSafetyMode), false, true, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.acceptedModes, typeof(LifeSafetyMode), true, true, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.lifeSafetyAlarmValues, typeof(LifeSafetyState), true, false, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.alarmValues, typeof(LifeSafetyState), true, false, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.faultValues, typeof(LifeSafetyState), true, false, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.silenced, typeof(SilencedState), false, true, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.operationExpected, typeof(LifeSafetyOperation), false, true, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.maintenanceRequired, typeof(Maintenance), false, false, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.zoneMembers, typeof(DeviceObjectReference), true, true, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.memberOf, typeof(DeviceObjectReference), true, false, null);
        add(ObjectType.lifeSafetyZone, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Load control
        add(ObjectType.loadControl, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.loadControl, 0x3fffff));
        add(ObjectType.loadControl, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.loadControl, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.loadControl);
        add(ObjectType.loadControl, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.loadControl, PropertyIdentifier.presentValue, typeof(ShedState), false, true, ShedState.shedInactive);
        add(ObjectType.loadControl, PropertyIdentifier.stateDescription, typeof(CharacterString), false, false, null);
        add(ObjectType.loadControl, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.loadControl, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.loadControl, PropertyIdentifier.reliability, typeof(Reliability), false, true, null);
        add(ObjectType.loadControl, PropertyIdentifier.requestedShedLevel, typeof(ShedLevel), false, true, null);
        add(ObjectType.loadControl, PropertyIdentifier.startTime, typeof(DateTime), false, true, null);
        add(ObjectType.loadControl, PropertyIdentifier.shedDuration, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.loadControl, PropertyIdentifier.dutyWindow, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.loadControl, PropertyIdentifier.enable, typeof(BBoolean), false, true, null);
        add(ObjectType.loadControl, PropertyIdentifier.fullDutyBaseline, typeof(Real), false, false, null);
        add(ObjectType.loadControl, PropertyIdentifier.expectedShedLevel, typeof(ShedLevel), false, true, null);
        add(ObjectType.loadControl, PropertyIdentifier.actualShedLevel, typeof(ShedLevel), false, true, null);
        add(ObjectType.loadControl, PropertyIdentifier.shedLevels, typeof(UnsignedInteger), true, true, null);
        add(ObjectType.loadControl, PropertyIdentifier.shedLevelDescriptions, typeof(CharacterString), true, true, null);
        add(ObjectType.loadControl, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.loadControl, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.loadControl, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.loadControl, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.loadControl, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.loadControl, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.loadControl, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Loop
        add(ObjectType.loop, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.loop, 0x3fffff));
        add(ObjectType.loop, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.loop, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.loop);
        add(ObjectType.loop, PropertyIdentifier.presentValue, typeof(Real), false, true, new Real(0));
        add(ObjectType.loop, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.loop, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.loop, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.loop, PropertyIdentifier.updateInterval, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.outputUnits, typeof(EngineeringUnits), false, true, null);
        add(ObjectType.loop, PropertyIdentifier.manipulatedVariableReference, typeof(ObjectPropertyReference), false, true, null);
        add(ObjectType.loop, PropertyIdentifier.controlledVariableReference, typeof(ObjectPropertyReference), false, true, null);
        add(ObjectType.loop, PropertyIdentifier.controlledVariableValue, typeof(Real), false, true, null);
        add(ObjectType.loop, PropertyIdentifier.controlledVariableUnits, typeof(EngineeringUnits), false, true, null);
        add(ObjectType.loop, PropertyIdentifier.setpointReference, typeof(SetpointReference), false, true, null);
        add(ObjectType.loop, PropertyIdentifier.setpoint, typeof(Real), false, true, null);
        add(ObjectType.loop, PropertyIdentifier.action, typeof(Action), false, true, null);
        add(ObjectType.loop, PropertyIdentifier.proportionalConstant, typeof(Real), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.proportionalConstantUnits, typeof(EngineeringUnits), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.integralConstant, typeof(Real), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.integralConstantUnits, typeof(EngineeringUnits), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.derivativeConstant, typeof(Real), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.derivativeConstantUnits, typeof(EngineeringUnits), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.bias, typeof(Real), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.maximumOutput, typeof(Real), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.minimumOutput, typeof(Real), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.priorityForWriting, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.loop, PropertyIdentifier.covIncrement, typeof(Real), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.errorLimit, typeof(Real), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.deadband, typeof(Real), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.loop, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.loop, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Multi state input
        add(ObjectType.multiStateInput, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.multiStateInput, 0x3fffff));
        add(ObjectType.multiStateInput, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.multiStateInput, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.multiStateInput);
        add(ObjectType.multiStateInput, PropertyIdentifier.presentValue, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.multiStateInput, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.multiStateInput, PropertyIdentifier.deviceType, typeof(CharacterString), false, false, null);
        add(ObjectType.multiStateInput, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.multiStateInput, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.multiStateInput, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);
        add(ObjectType.multiStateInput, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.multiStateInput, PropertyIdentifier.numberOfStates, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.multiStateInput, PropertyIdentifier.stateText, typeof(CharacterString), true, false, null);
        add(ObjectType.multiStateInput, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.multiStateInput, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.multiStateInput, PropertyIdentifier.alarmValues, typeof(UnsignedInteger), true, false, null);
        add(ObjectType.multiStateInput, PropertyIdentifier.faultValues, typeof(UnsignedInteger), true, false, null);
        add(ObjectType.multiStateInput, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.multiStateInput, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.multiStateInput, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.multiStateInput, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.multiStateInput, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Multi state output
        add(ObjectType.multiStateOutput, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.multiStateOutput, 0x3fffff));
        add(ObjectType.multiStateOutput, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.multiStateOutput, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.multiStateOutput);
        add(ObjectType.multiStateOutput, PropertyIdentifier.presentValue, typeof(UnsignedInteger), false, true, new UnsignedInteger(0));
        add(ObjectType.multiStateOutput, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.multiStateOutput, PropertyIdentifier.deviceType, typeof(CharacterString), false, false, null);
        add(ObjectType.multiStateOutput, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.multiStateOutput, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.multiStateOutput, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);
        add(ObjectType.multiStateOutput, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.multiStateOutput, PropertyIdentifier.numberOfStates, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.multiStateOutput, PropertyIdentifier.stateText, typeof(CharacterString), true, false, null);
        add(ObjectType.multiStateOutput, PropertyIdentifier.priorityArray, typeof(PriorityArray), false, true, new PriorityArray());
        add(ObjectType.multiStateOutput, PropertyIdentifier.relinquishDefault, typeof(UnsignedInteger), false, true, new UnsignedInteger(0));
        add(ObjectType.multiStateOutput, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.multiStateOutput, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.multiStateOutput, PropertyIdentifier.feedbackValue, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.multiStateOutput, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.multiStateOutput, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.multiStateOutput, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.multiStateOutput, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.multiStateOutput, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Multi state value
        add(ObjectType.multiStateValue, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.multiStateValue, 0x3fffff));
        add(ObjectType.multiStateValue, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.multiStateValue, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.multiStateValue);
        add(ObjectType.multiStateValue, PropertyIdentifier.presentValue, typeof(UnsignedInteger), false, true, new UnsignedInteger(0));
        add(ObjectType.multiStateValue, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.multiStateValue, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.multiStateValue, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.multiStateValue, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);
        add(ObjectType.multiStateValue, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.multiStateValue, PropertyIdentifier.numberOfStates, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.multiStateValue, PropertyIdentifier.stateText, typeof(CharacterString), true, false, null);
        add(ObjectType.multiStateValue, PropertyIdentifier.priorityArray, typeof(PriorityArray), false, false, new PriorityArray());
        add(ObjectType.multiStateValue, PropertyIdentifier.relinquishDefault, typeof(UnsignedInteger), false, false, new UnsignedInteger(0));
        add(ObjectType.multiStateValue, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.multiStateValue, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.multiStateValue, PropertyIdentifier.alarmValues, typeof(UnsignedInteger), true, false, null);
        add(ObjectType.multiStateValue, PropertyIdentifier.faultValues, typeof(UnsignedInteger), true, false, null);
        add(ObjectType.multiStateValue, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.multiStateValue, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.multiStateValue, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.multiStateValue, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.multiStateValue, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Notification class
        add(ObjectType.notificationClass, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.notificationClass, 0x3fffff));
        add(ObjectType.notificationClass, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.notificationClass, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.notificationClass);
        add(ObjectType.notificationClass, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.notificationClass, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.notificationClass, PropertyIdentifier.priority, typeof(UnsignedInteger), true, true, null);
        add(ObjectType.notificationClass, PropertyIdentifier.ackRequired, typeof(EventTransitionBits), false, true, null);
        add(ObjectType.notificationClass, PropertyIdentifier.recipientList, typeof(Destination), true, true, null);
        add(ObjectType.notificationClass, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Program
        add(ObjectType.program, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.program, 0x3fffff));
        add(ObjectType.program, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.program, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.program);
        add(ObjectType.program, PropertyIdentifier.programState, typeof(ProgramState), false, true, null);
        add(ObjectType.program, PropertyIdentifier.programChange, typeof(ProgramRequest), false, true, null);
        add(ObjectType.program, PropertyIdentifier.reasonForHalt, typeof(ProgramError), false, false, null);
        add(ObjectType.program, PropertyIdentifier.descriptionOfHalt, typeof(CharacterString), false, true, null);
        add(ObjectType.program, PropertyIdentifier.programLocation, typeof(CharacterString), false, false, null);
        add(ObjectType.program, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.program, PropertyIdentifier.instanceOf, typeof(CharacterString), false, false, null);
        add(ObjectType.program, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.program, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);
        add(ObjectType.program, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.program, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Pulse converter
        add(ObjectType.pulseConverter, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.pulseConverter, 0x3fffff));
        add(ObjectType.pulseConverter, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.pulseConverter);
        add(ObjectType.pulseConverter, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.presentValue, typeof(Real), false, true, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.inputReference, typeof(ObjectPropertyReference), false, false, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.pulseConverter, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.pulseConverter, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.pulseConverter, PropertyIdentifier.units, typeof(EngineeringUnits), false, true, EngineeringUnits.noUnits);
        add(ObjectType.pulseConverter, PropertyIdentifier.scaleFactor, typeof(Real), false, true, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.adjustValue, typeof(Real), false, true, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.count, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.updateTime, typeof(DateTime), false, true, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.countChangeTime, typeof(DateTime), false, true, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.countBeforeChange, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.covIncrement, typeof(Real), false, false, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.covPeriod, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.timeDelay, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.highLimit, typeof(Real), false, false, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.lowLimit, typeof(Real), false, false, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.deadband, typeof(Real), false, false, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.limitEnable, typeof(LimitEnable), false, false, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.pulseConverter, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Schedule
        add(ObjectType.schedule, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.schedule, 0x3fffff));
        add(ObjectType.schedule, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.schedule, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.schedule);
        add(ObjectType.schedule, PropertyIdentifier.presentValue, typeof(AmbiguousValue), false, true, null);
        add(ObjectType.schedule, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.schedule, PropertyIdentifier.effectivePeriod, typeof(DateRange), false, true, null);
        add(ObjectType.schedule, PropertyIdentifier.weeklySchedule, typeof(DailySchedule), true, false, null);
        add(ObjectType.schedule, PropertyIdentifier.scheduleDefault, typeof(AmbiguousValue), false, true, null);
        add(ObjectType.schedule, PropertyIdentifier.exceptionSchedule, typeof(SpecialEvent), true, false, null);
        add(ObjectType.schedule, PropertyIdentifier.listOfObjectPropertyReferences, typeof(DeviceObjectPropertyReference), true, true, null);
        add(ObjectType.schedule, PropertyIdentifier.priorityForWriting, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.schedule, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.schedule, PropertyIdentifier.reliability, typeof(Reliability), false, true, null);
        add(ObjectType.schedule, PropertyIdentifier.outOfService, typeof(BBoolean), false, true, new BBoolean(true));
        add(ObjectType.schedule, PropertyIdentifier.profileName, typeof(CharacterString), false, true, null);

        // Structured View
        add(ObjectType.structuredView, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.structuredView, 0x3fffff));
        add(ObjectType.structuredView, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.structuredView, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.structuredView);
        add(ObjectType.structuredView, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.structuredView, PropertyIdentifier.nodeType, typeof(NodeType), false, false, null);
        add(ObjectType.structuredView, PropertyIdentifier.nodeSubtype, typeof(CharacterString), false, false, null);
        add(ObjectType.structuredView, PropertyIdentifier.subordinateList, typeof(DeviceObjectReference), true, true, null);
        add(ObjectType.structuredView, PropertyIdentifier.subordinateAnnotations, typeof(CharacterString), true, false, null);
        add(ObjectType.structuredView, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);

        // Trend log
        add(ObjectType.trendLog, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.trendLog, 0x3fffff));
        add(ObjectType.trendLog, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.trendLog, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.trendLog);
        add(ObjectType.trendLog, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.enable, typeof(BBoolean), false, true, null);
        add(ObjectType.trendLog, PropertyIdentifier.startTime, typeof(DateTime), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.stopTime, typeof(DateTime), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.logDeviceObjectProperty, typeof(DeviceObjectPropertyReference), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.logInterval, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.covResubscriptionInterval, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.clientCovIncrement, typeof(ClientCov), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.stopWhenFull, typeof(BBoolean), false, true, null);
        add(ObjectType.trendLog, PropertyIdentifier.bufferSize, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.trendLog, PropertyIdentifier.logBuffer, typeof(LogRecord), true, true, new SequenceOf<LogRecord>());
        add(ObjectType.trendLog, PropertyIdentifier.recordCount, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.trendLog, PropertyIdentifier.totalRecordCount, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.trendLog, PropertyIdentifier.notificationThreshold, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.recordsSinceNotification, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.lastNotifyRecord, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.trendLog, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.loggingType, typeof(LoggingType), false, true, null);
        add(ObjectType.trendLog, PropertyIdentifier.alignIntervals, typeof(BBoolean), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.intervalOffset, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.trigger, typeof(BBoolean), false, false, null);
        add(ObjectType.trendLog, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.trendLog, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);

        // Trend log multiple
        add(ObjectType.trendLogMultiple, PropertyIdentifier.objectIdentifier, typeof(ObjectIdentifier), false, true, new ObjectIdentifier(ObjectType.trendLogMultiple, 0x3fffff));
        add(ObjectType.trendLogMultiple, PropertyIdentifier.objectName, typeof(CharacterString), false, true, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.objectType, typeof(ObjectType), false, true, ObjectType.trendLogMultiple);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.description, typeof(CharacterString), false, false, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.statusFlags, typeof(StatusFlags), false, true, new StatusFlags(false, false, false, true));
        add(ObjectType.trendLogMultiple, PropertyIdentifier.eventState, typeof(EventState), false, true, EventState.normal);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.reliability, typeof(Reliability), false, false, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.enable, typeof(BBoolean), false, true, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.startTime, typeof(DateTime), false, false, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.stopTime, typeof(DateTime), false, false, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.logDeviceObjectProperty, typeof(DeviceObjectPropertyReference), true, true, new SequenceOf<DeviceObjectPropertyReference>());
        add(ObjectType.trendLogMultiple, PropertyIdentifier.loggingType, typeof(LoggingType), false, true, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.logInterval, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.alignIntervals, typeof(BBoolean), false, false, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.intervalOffset, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.trigger, typeof(BBoolean), false, false, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.stopWhenFull, typeof(BBoolean), false, true, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.bufferSize, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.logBuffer, typeof(LogMultipleRecord), true, true, new SequenceOf<LogMultipleRecord>());
        add(ObjectType.trendLogMultiple, PropertyIdentifier.recordCount, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.totalRecordCount, typeof(UnsignedInteger), false, true, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.notificationThreshold, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.recordsSinceNotification, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.lastNotifyRecord, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.notificationClass, typeof(UnsignedInteger), false, false, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.eventEnable, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.ackedTransitions, typeof(EventTransitionBits), false, false, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.notifyType, typeof(NotifyType), false, false, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.eventTimeStamps, typeof(TimeStamp), true, false, null);
        add(ObjectType.trendLogMultiple, PropertyIdentifier.profileName, typeof(CharacterString), false, false, null);
        */
    }
    }
}

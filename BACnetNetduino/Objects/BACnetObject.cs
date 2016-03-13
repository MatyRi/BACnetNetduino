using System;
using BACnetNetduino.DataTypes;
using BACnetNetduino.DataTypes.Constructed;
using BACnetNetduino.DataTypes.Enumerated;
using BACnetNetduino.DataTypes.Primitive;
using BACnetNetduino.Exception;
using Microsoft.SPOT;

namespace BACnetNetduino.Objects
{
    class BACnetObject
    {
        private readonly LocalDevice localDevice;
    private readonly ObjectIdentifier id;
    private readonly Map<PropertyIdentifier, Encodable> properties = new HashMap<PropertyIdentifier, Encodable>();
        private readonly List<ObjectCovSubscription> covSubscriptions = new ArrayList<ObjectCovSubscription>();

        public BACnetObject(LocalDevice localDevice, ObjectIdentifier id)
        {
            this.localDevice = localDevice;
            if (id == null)
                throw new ArgumentException("object id cannot be null");
            this.id = id;

            try
            {
                setProperty(PropertyIdentifier.objectName, new CharacterString(id.toString()));

                // Set any default values.
                List<PropertyTypeDefinition> defs = ObjectProperties.getPropertyTypeDefinitions(id.getObjectType());
                for (PropertyTypeDefinition def : defs)
                {
                    if (def.getDefaultValue() != null)
                        setProperty(def.getPropertyIdentifier(), def.getDefaultValue());
                }
            }
            catch (BACnetServiceException e)
            {
                // Should never happen, but wrap in an unchecked just in case.
                throw new BACnetRuntimeException(e);
            }
        }

        public ObjectIdentifier getId()
        {
            return id;
        }

        public int getInstanceId()
        {
            return id.getInstanceNumber();
        }

        public String getObjectName()
        {
            CharacterString name = getRawObjectName();
            if (name == null)
                return null;
            return name.getValue();
        }

        public CharacterString getRawObjectName()
        {
            return (CharacterString)properties.get(PropertyIdentifier.objectName);
        }

        public String getDescription()
        {
            CharacterString name = (CharacterString)properties.get(PropertyIdentifier.description);
            if (name == null)
                return null;
            return name.getValue();
        }

        //
        //
        // Get property
        //
        public Encodable getProperty(PropertyIdentifier pid)
        {
        if (pid.intValue() == PropertyIdentifier.objectIdentifier.intValue())
            return id;
        if (pid.intValue() == PropertyIdentifier.objectType.intValue())
            return id.getObjectType();

            // Check that the requested property is valid for the object. This will throw an exception if the
            // property doesn't belong.
            ObjectProperties.getPropertyTypeDefinitionRequired(id.getObjectType(), pid);

        // Do some property-specific checking here.
        if (pid.intValue() == PropertyIdentifier.localTime.intValue())
            return new Time();
        if (pid.intValue() == PropertyIdentifier.localDate.intValue())
            return new Date();
        
        // AdK - COV subscriptions
        if(pid.intValue() == PropertyIdentifier.activeCovSubscriptions.intValue()) {
        	List<BACnetObject> objs = localDevice.getLocalObjects();
        SequenceOf<CovSubscription> covS = new SequenceOf<CovSubscription>();

            foreach (BACnetObject obj : objs) {
                    foreach (ObjectCovSubscription s : obj.covSubscriptions)
            	{
            		RemoteDevice d = localDevice.getRemoteDevice(s.getAddress());
        Recipient r = null;
            		if(d != null) {
            			r = new Recipient(d.getObjectIdentifier());
            		} else {
            			r = new Recipient(s.getAddress());
            		}
covS.add(new CovSubscription(new RecipientProcess(r, s.getSubscriberProcessIdentifier()),
            				new ObjectPropertyReference(obj.id, PropertyIdentifier.presentValue), new Boolean(s.isIssueConfirmedNotifications()),
            				new UnsignedInteger(s.getTimeRemaining(System.currentTimeMillis())), obj.getCovIncrement() 
            				));
            	}
            }
            return covS;
        }
        
        
        return properties.get(pid);
    }

    public Encodable getPropertyRequired(PropertyIdentifier pid) throws BACnetServiceException
{
    Encodable p = getProperty(pid);
        if (p == null)
            throw new BACnetServiceException(ErrorClass.property, ErrorCode.unknownProperty);
        return p;
    }

    public Encodable getProperty(PropertyIdentifier pid, UnsignedInteger propertyArrayIndex)
{
    Encodable result = getProperty(pid);
        if (propertyArrayIndex == null)
            return result;

        if (!(result instanceof SequenceOf<?>))
            throw new BACnetServiceException(ErrorClass.property, ErrorCode.propertyIsNotAnArray);

SequenceOf<?> array = (SequenceOf <?>) result;
        int index = propertyArrayIndex.intValue();
        if (index == 0)
            return new UnsignedInteger(array.getCount());

        if (index > array.getCount())
            throw new BACnetServiceException(ErrorClass.property, ErrorCode.invalidArrayIndex);

        return array.get(index);
    }

    public Encodable getPropertyRequired(PropertyIdentifier pid, UnsignedInteger propertyArrayIndex)
{
    Encodable p = getProperty(pid, propertyArrayIndex);
        if (p == null)
            throw new BACnetServiceException(ErrorClass.property, ErrorCode.unknownProperty);
        return p;
    }

    //
    //
    // Set property
    //
    public void setProperty(PropertyIdentifier pid, Encodable value)
{
    ObjectProperties.validateValue(id.getObjectType(), pid, value);
    setPropertyImpl(pid, value);

        // If the relinquish default was set, make sure the present value gets updated as necessary.
        if (pid.equals(PropertyIdentifier.relinquishDefault))
            setCommandableImpl((PriorityArray) getProperty(PropertyIdentifier.priorityArray));
}

    public void setProperty(PropertyIdentifier pid, int indexBase1, Encodable value)
{
    ObjectProperties.validateSequenceValue(id.getObjectType(), pid, value);
    SequenceOf<Encodable> list = (SequenceOf<Encodable>) properties.get(pid);
    if (list == null)
    {
        list = new SequenceOf<Encodable>();
        setPropertyImpl(pid, list);
    }
    list.set(indexBase1, value);
    }

    public void setProperty(PropertyValue value)
{
    PropertyIdentifier pid = value.getPropertyIdentifier();

        if (pid.intValue() == PropertyIdentifier.objectIdentifier.intValue())
            throw new BACnetServiceException(ErrorClass.property, ErrorCode.writeAccessDenied);
        if (pid.intValue() == PropertyIdentifier.objectType.intValue())
            throw new BACnetServiceException(ErrorClass.property, ErrorCode.writeAccessDenied);
        if (pid.intValue() == PropertyIdentifier.priorityArray.intValue())
            throw new BACnetServiceException(ErrorClass.property, ErrorCode.writeAccessDenied);
        //        if (pid.intValue() == PropertyIdentifier.relinquishDefault.intValue())
        //            throw new BACnetServiceException(ErrorClass.property, ErrorCode.writeAccessDenied);

        if (ObjectProperties.isCommandable((ObjectType) getProperty(PropertyIdentifier.objectType), pid))
            setCommandable(value.getValue(), value.getPriority());
        else if (value.getValue() == null) {
            if (value.getPropertyArrayIndex() == null)
                removeProperty(value.getPropertyIdentifier());
            else
                removeProperty(value.getPropertyIdentifier(), value.getPropertyArrayIndex());
        }
        else {
            if (value.getPropertyArrayIndex() != null)
                setProperty(pid, value.getPropertyArrayIndex().intValue(), value.getValue());
            else
                setProperty(pid, value.getValue());
        }
    }

    public void setCommandable(Encodable value, UnsignedInteger priority)
{
        int pri = 16;
        if (priority != null)
            pri = priority.intValue();

    PriorityArray priorityArray = (PriorityArray) getProperty(PropertyIdentifier.priorityArray);
    priorityArray.set(pri, createCommandValue(value));
    setCommandableImpl(priorityArray);
    }

    private void setCommandableImpl(PriorityArray priorityArray)
{
    PriorityValue priorityValue = null;
        for (PriorityValue priv : priorityArray) {
        if (!priv.isNull())
        {
            priorityValue = priv;
            break;
        }
    }

    Encodable newValue = getProperty(PropertyIdentifier.relinquishDefault);
        if (priorityValue != null)
            newValue = priorityValue.getValue();

    setPropertyImpl(PropertyIdentifier.presentValue, newValue);
}

private void setPropertyImpl(PropertyIdentifier pid, Encodable value)
{
    Encodable oldValue = properties.get(pid);
    properties.put(pid, value);

    if (!ObjectUtils.equals(value, oldValue))
    {
        // Check for subscriptions.
        if (ObjectCovSubscription.sendCovNotification(id.getObjectType(), pid, this.getCovIncrement()))
        {
            synchronized(covSubscriptions) {
                long now = System.currentTimeMillis();
                ObjectCovSubscription sub;
                for (int i = covSubscriptions.size() - 1; i >= 0; i--)
                {
                    sub = covSubscriptions.get(i);
                    if (sub.hasExpired(now))
                        covSubscriptions.remove(i);
                    else if (sub.isNotificationRequired(pid, value))
                        sendCovNotification(sub, now);
                }
            }
        }
    }
}

private PriorityValue createCommandValue(Encodable value)
{
        if (value instanceof Null)
            return new PriorityValue((Null) value);

        ObjectType type = (ObjectType)getProperty(PropertyIdentifier.objectType);
        if (type.equals(ObjectType.accessDoor))
            return new PriorityValue((BaseType) value);
        if (type.equals(ObjectType.analogOutput) || type.equals(ObjectType.analogValue))
            return new PriorityValue((Real) value);
        if (type.equals(ObjectType.binaryOutput) || type.equals(ObjectType.binaryValue))
            return new PriorityValue((BinaryPV) value);
        return new PriorityValue((UnsignedInteger) value);
    }

    /**
     * return all implemented properties
     * 
     * @return
     */
    public List<PropertyIdentifier> getProperties()
{
    ArrayList<PropertyIdentifier> list = new ArrayList<PropertyIdentifier>();
    for (PropertyIdentifier pid : properties.keySet())
        list.add(pid);
    return list;
}

//
//
// COV subscriptions
//
public void addCovSubscription(Address from, OctetString linkService, UnsignedInteger subscriberProcessIdentifier,
        Boolean issueConfirmedNotifications, UnsignedInteger lifetime)
{
    synchronized (covSubscriptions) {
        ObjectCovSubscription sub = findCovSubscription(from, subscriberProcessIdentifier);
        boolean confirmed = issueConfirmedNotifications.booleanValue();

        if (sub == null)
        {
            // Ensure that this object is valid for COV notifications.
            if (!ObjectCovSubscription.sendCovNotification(id.getObjectType(), null, this.getCovIncrement()))
                throw new BACnetServiceException(ErrorClass.services, ErrorCode.covSubscriptionFailed,
                        "Object is invalid for COV notifications");

            if (confirmed)
            {
                // If the peer wants confirmed notifications, it must be in the remote device list.
                RemoteDevice d = localDevice.getRemoteDevice(from);
                if (d == null)
                    throw new BACnetServiceException(ErrorClass.services, ErrorCode.covSubscriptionFailed,
                            "From address not found in remote device list. Cannot send confirmed notifications");
            }

            sub = new ObjectCovSubscription(from, linkService, subscriberProcessIdentifier, this.getCovIncrement());
            covSubscriptions.add(sub);
        }

        sub.setIssueConfirmedNotifications(issueConfirmedNotifications.booleanValue());
        sub.setExpiryTime(lifetime.intValue());
    }
}

public Real getCovIncrement()
{
    return (Real)properties.get(PropertyIdentifier.covIncrement);
}

public void removeCovSubscription(Address from, UnsignedInteger subscriberProcessIdentifier)
{
    synchronized(covSubscriptions) {
        ObjectCovSubscription sub = findCovSubscription(from, subscriberProcessIdentifier);
        if (sub != null)
            covSubscriptions.remove(sub);
    }
}

private ObjectCovSubscription findCovSubscription(Address from, UnsignedInteger subscriberProcessIdentifier)
{
    foreach (ObjectCovSubscription sub : covSubscriptions)
    {
        if (sub.getAddress().equals(from)
                && sub.getSubscriberProcessIdentifier().equals(subscriberProcessIdentifier))
            return sub;
    }
    return null;
}

private void sendCovNotification(ObjectCovSubscription sub, long now)
{
    try
    {
        UnsignedInteger timeLeft = new UnsignedInteger(sub.getTimeRemaining(now));
        SequenceOf<PropertyValue> values = new SequenceOf<PropertyValue>(ObjectCovSubscription.getValues(this));

        if (sub.isIssueConfirmedNotifications())
        {
            // Confirmed
            ConfirmedCovNotificationRequest req = new ConfirmedCovNotificationRequest(
                    sub.getSubscriberProcessIdentifier(), localDevice.getConfiguration().getId(), id, timeLeft,
                    values);
            RemoteDevice d = localDevice.getRemoteDevice(sub.getAddress());
            localDevice.send(d, req);
        }
        else {
            // Unconfirmed
            UnconfirmedCovNotificationRequest req = new UnconfirmedCovNotificationRequest(
                    sub.getSubscriberProcessIdentifier(), localDevice.getConfiguration().getId(), id, timeLeft,
                    values);
            localDevice.sendUnconfirmed(sub.getAddress(), sub.getLinkService(), req);
        }
    }
    catch (BACnetException e)
    {
        ExceptionDispatch.fireReceivedException(e);
    }
}

public void validate()
{
    // Ensure that all required properties have values.
    List<PropertyTypeDefinition> defs = ObjectProperties.getRequiredPropertyTypeDefinitions(id.getObjectType());
        for (PropertyTypeDefinition def : defs) {
        if (getProperty(def.getPropertyIdentifier()) == null)
            throw new BACnetServiceException(ErrorClass.property, ErrorCode.other, "Required property not set: "
                    + def.getPropertyIdentifier());
    }
}

public void removeProperty(PropertyIdentifier pid)
{
    PropertyTypeDefinition def = ObjectProperties.getPropertyTypeDefinitionRequired(id.getObjectType(), pid);
        if (def.isRequired())
            throw new BACnetServiceException(ErrorClass.property, ErrorCode.writeAccessDenied);
properties.remove(pid);
    }

    public void removeProperty(PropertyIdentifier pid, UnsignedInteger propertyArrayIndex)
            throws BACnetServiceException
{
    PropertyTypeDefinition def = ObjectProperties.getPropertyTypeDefinitionRequired(id.getObjectType(), pid);
        if (!def.isSequence())
            throw new BACnetServiceException(ErrorClass.property, ErrorCode.invalidArrayIndex);
SequenceOf<?> sequence = (SequenceOf <?>) properties.get(pid);
        if (sequence != null)
            sequence.remove(propertyArrayIndex.intValue());
    }

public void distributeUpdate(Object arg)
{
    this.setChanged();
    notifyObservers(arg);
}
    }
}

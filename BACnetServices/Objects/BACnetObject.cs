using System;
using System.Collections;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;
using BACnetDataTypes.Primitive;

namespace BACnetServices.Objects
{
    public class BACnetObject
    {
        private readonly LocalDevice localDevice;
        private readonly ObjectIdentifier id;
        private readonly Hashtable properties = new Hashtable();
        //private readonly Map<PropertyIdentifier, Encodable> properties = new HashMap<PropertyIdentifier, Encodable>();
        //private readonly List<ObjectCovSubscription> covSubscriptions = new ArrayList<ObjectCovSubscription>();

        public BACnetObject(LocalDevice localDevice, ObjectIdentifier id)
        {
            this.localDevice = localDevice;
            if (id == null)
                throw new ArgumentException("object id cannot be null");
            this.id = id;

            try
            {
                setProperty(PropertyIdentifier.ObjectName, new CharacterString(id.ToString()));

                // Set any default values.
                /* TODO List<PropertyTypeDefinition> defs = ObjectProperties.getPropertyTypeDefinitions(id.getObjectType());
                for (PropertyTypeDefinition def : defs)
                {
                    if (def.getDefaultValue() != null)
                        setProperty(def.getPropertyIdentifier(), def.getDefaultValue());
                }*/
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

        public uint getInstanceId()
        {
            return id.InstanceNumber;
        }

        public string getObjectName()
        {
            CharacterString name = getRawObjectName();
            if (name == null)
                return null;
            return name.Value;
        }

        public CharacterString getRawObjectName()
        {
            return (CharacterString) properties[PropertyIdentifier.ObjectName];
        }

        public string getDescription()
        {
            CharacterString name = (CharacterString) properties[PropertyIdentifier.Description];
            if (name == null)
                return null;
            return name.Value;
        }

        //
        //
        // Get property
        //
        public Encodable getProperty(PropertyIdentifier pid)
        {
            if (((UnsignedInteger) pid).Value== ((UnsignedInteger) PropertyIdentifier.ObjectIdentifier).Value)
                return id;
            if (((UnsignedInteger) pid).Value== ((UnsignedInteger) PropertyIdentifier.ObjectType).Value)
                return id.ObjectType;

            // Check that the requested property is valid for the object. This will throw an exception if the
            // property doesn't belong.
            // TODO ObjectProperties.getPropertyTypeDefinitionRequired(id.getObjectType(), pid);

            // Do some property-specific checking here.
            if (((UnsignedInteger) pid).Value== ((UnsignedInteger) PropertyIdentifier.LocalTime).Value)
                return new Time();
            if (((UnsignedInteger) pid).Value== ((UnsignedInteger) PropertyIdentifier.LocalDate).Value)
                return new Date();

            // AdK - COV subscriptions
            /*if(pid.intValue() == PropertyIdentifier.activeCovSubscriptions.intValue()) {
        	List<BACnetObject> objs = localDevice.getLocalObjects();
        SequenceOf<CovSubscription> covS = new SequenceOf<CovSubscription>();

            foreach (BACnetObject obj : objs) {
                    foreach (ObjectCovSubscription s : obj.covSubscriptions)
            	{
            		RemoteDevice d = localDevice.getRemoteDevice(s.getAddress());
        Recipient r = null;
            		if(d != null) {
            			r = new Recipient(d.ObjectIdentifier());
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
        }*/


            return (Encodable) properties[pid];
        }

        public Encodable getPropertyRequired(PropertyIdentifier pid)
        {
            Encodable p = getProperty(pid);
            if (p == null)
                throw new BACnetServiceException(ErrorClass.Property, ErrorCode.UnknownProperty);
            return p;
        }

        public Encodable getProperty(PropertyIdentifier pid, UnsignedInteger propertyArrayIndex)
        {
            Encodable result = getProperty(pid);
            if (propertyArrayIndex == null)
                return result;

            return null; // TODO 
            /*if (!(result instanceof SequenceOf<?>))
            throw new BACnetServiceException(ErrorClass.property, ErrorCode.propertyIsNotAnArray);

SequenceOf<?> array = (SequenceOf <?>) result;
        int index = propertyArrayIndex.intValue();
        if (index == 0)
            return new UnsignedInteger(array.getCount());

        if (index > array.getCount())
            throw new BACnetServiceException(ErrorClass.property, ErrorCode.invalidArrayIndex);

        return array.get(index);*/
        }

        public Encodable getPropertyRequired(PropertyIdentifier pid, UnsignedInteger propertyArrayIndex)
        {
            Encodable p = getProperty(pid, propertyArrayIndex);
            if (p == null)
                throw new BACnetServiceException(ErrorClass.Property, ErrorCode.UnknownProperty);
            return p;
        }

        //
        //
        // Set property
        //
        public void setProperty(PropertyIdentifier pid, Encodable value)
        {
            // TODO ObjectProperties.validateValue(id.getObjectType(), pid, value);
            setPropertyImpl(pid, value);

            // If the relinquish default was set, make sure the present value gets updated as necessary.
            // TODO if (pid.Equals(PropertyIdentifier.relinquishDefault))
            //    setCommandableImpl((PriorityArray) getProperty(PropertyIdentifier.priorityArray));
        }

        public void setProperty(PropertyIdentifier pid, uint indexBase1, Encodable value)
        {
            /*ObjectProperties.validateSequenceValue(id.getObjectType(), pid, value);
    SequenceOf<Encodable> list = (SequenceOf<Encodable>) properties.get(pid);
    if (list == null)
    {
        list = new SequenceOf<Encodable>();
        setPropertyImpl(pid, list);
    }
    list.set(indexBase1, value);*/
        }

        public void setProperty(PropertyValue value)
        {
            PropertyIdentifier pid = value.PropertyIdentifier;

            if (((UnsignedInteger) pid).Value== ((UnsignedInteger) PropertyIdentifier.ObjectIdentifier).Value)
                throw new BACnetServiceException(ErrorClass.Property, ErrorCode.WriteAccessDenied);
            if (((UnsignedInteger) pid).Value== ((UnsignedInteger) PropertyIdentifier.ObjectType).Value)
                throw new BACnetServiceException(ErrorClass.Property, ErrorCode.WriteAccessDenied);
            if (((UnsignedInteger) pid).Value== ((UnsignedInteger) PropertyIdentifier.PriorityArray).Value)
                throw new BACnetServiceException(ErrorClass.Property, ErrorCode.WriteAccessDenied);
            //        if (pid.intValue() == PropertyIdentifier.relinquishDefault.intValue())
            //            throw new BACnetServiceException(ErrorClass.property, ErrorCode.writeAccessDenied);

            if (ObjectProperties.isCommandable((ObjectType) getProperty(PropertyIdentifier.ObjectType), pid))
                setCommandable(value.Value, value.Priority);
            else if (value.Value== null)
            {
                if (value.PropertyArrayIndex== null)
                    removeProperty(value.PropertyIdentifier);
                else
                    removeProperty(value.PropertyIdentifier, value.PropertyArrayIndex);
            }
            else
            {
                if (value.PropertyArrayIndex!= null)
                    setProperty(pid, value.PropertyArrayIndex.Value, value.Value);
                else
                    setProperty(pid, value.Value);
            }
        }

        public void setCommandable(Encodable value, UnsignedInteger priority)
        {
            uint pri = 16;
            if (priority != null)
                pri = priority.Value;

            PriorityArray priorityArray = (PriorityArray) getProperty(PropertyIdentifier.PriorityArray);
            priorityArray.set((int) pri, createCommandValue(value));
            setCommandableImpl(priorityArray);
        }

        private void setCommandableImpl(PriorityArray priorityArray)
        {
            PriorityValue priorityValue = null;
            foreach (PriorityValue priv in priorityArray)
            {
                if (!priv.IsNull)
                {
                    priorityValue = priv;
                    break;
                }
            }

            Encodable newValue = getProperty(PropertyIdentifier.RelinquishDefault);
            if (priorityValue != null)
                newValue = priorityValue.Value;

            setPropertyImpl(PropertyIdentifier.PresentValue, newValue);
        }

        private void setPropertyImpl(PropertyIdentifier pid, Encodable value)
        {
            Encodable oldValue = (Encodable) properties[pid];
            properties[pid] = value;
            //properties.Add(pid, value);

            /*if (!ObjectUtils.equals(value, oldValue))
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
    }*/
        }

        private PriorityValue createCommandValue(Encodable value)
        {
            if (value is Null)
                return new PriorityValue((Null) value);

            ObjectType type = (ObjectType) getProperty(PropertyIdentifier.ObjectType);
            if (type.Equals(ObjectType.AccessDoor))
                return new PriorityValue((BaseType) value);
            if (type.Equals(ObjectType.AnalogOutput) || type.Equals(ObjectType.AnalogValue))
                return new PriorityValue((Real) value);
            if (type.Equals(ObjectType.BinaryOutput) || type.Equals(ObjectType.BinaryValue))
                return new PriorityValue((BinaryPV) value);
            return new PriorityValue((UnsignedInteger) value);
        }

        /**
     * return all implemented properties
     * 
     * @return
     */

        public IList getProperties()
        {
            IList list = new ArrayList();
            foreach (PropertyIdentifier pid in properties.Keys)
                list.Add(pid);
            return list;
        }

//
//
// COV subscriptions
//
/*
public void addCovSubscription(Address from, OctetString linkService, UnsignedInteger subscriberProcessIdentifier,
        BBoolean issueConfirmedNotifications, UnsignedInteger lifetime)
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
    return (Real)properties[PropertyIdentifier.covIncrement];
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
    foreach (ObjectCovSubscription sub in covSubscriptions)
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
        */

        public void validate()
        {
            // Ensure that all required properties have values.
            IList defs = ObjectProperties.getRequiredPropertyTypeDefinitions(id.ObjectType);
            foreach (PropertyTypeDefinition def in defs)
            {
                if (getProperty(def.getPropertyIdentifier()) == null)
                    throw new BACnetServiceException(ErrorClass.Property, ErrorCode.Other, "Required property not set: " + def.getPropertyIdentifier());
            }
        }

        public void removeProperty(PropertyIdentifier pid)
        {
            PropertyTypeDefinition def = ObjectProperties.getPropertyTypeDefinitionRequired(id.ObjectType, pid);
            if (def.isRequired())
                throw new BACnetServiceException(ErrorClass.Property, ErrorCode.WriteAccessDenied);
            properties.Remove(pid);
        }

        public void removeProperty(PropertyIdentifier pid, UnsignedInteger propertyArrayIndex)
        {
            PropertyTypeDefinition def = ObjectProperties.getPropertyTypeDefinitionRequired(id.ObjectType, pid);
            if (!def.isSequence())
                throw new BACnetServiceException(ErrorClass.Property, ErrorCode.InvalidArrayIndex);
            SequenceOf sequence = (SequenceOf) properties[pid];
            if (sequence != null)
                sequence.remove((int) propertyArrayIndex.Value);
        }
    }
}

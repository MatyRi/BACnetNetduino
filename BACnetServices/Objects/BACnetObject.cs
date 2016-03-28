using System;
using System.Collections;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;
using BACnetDataTypes.Objects;
using BACnetDataTypes.Primitive;
using BACnetServices.Service.Confirmed;
using BACnetServices.Service.Unconfirmed;

namespace BACnetServices.Objects
{
    public class BACnetObject
    {
        private readonly LocalDevice localDevice;
        private readonly Hashtable properties = new Hashtable();
        private readonly IList covSubscriptions = new ArrayList();
        //private readonly Map<PropertyIdentifier, Encodable> properties = new HashMap<PropertyIdentifier, Encodable>();
        //private readonly List<ObjectCovSubscription> covSubscriptions = new ArrayList<ObjectCovSubscription>();

        public BACnetObject(LocalDevice localDevice, ObjectIdentifier id)
        {
            this.localDevice = localDevice;
            if (id == null)
                throw new ArgumentException("object id cannot be null");
            Id = id;

            try
            {
                setProperty(PropertyIdentifier.ObjectName, new CharacterString(id.ToString()));

                // Set any default values.
                IList defs = ObjectProperties.getPropertyTypeDefinitions(id.ObjectType);
                foreach (PropertyTypeDefinition def in defs)
                {
                    if (def.DefaultValue != null)
                        setProperty(def.PropertyIdentifier, def.DefaultValue);
                }
            }
            catch (BACnetServiceException e)
            {
                // Should never happen, but wrap in an unchecked just in case.
                throw new BACnetRuntimeException(e);
            }
        }

        public ObjectIdentifier Id { get; }

        public uint InstanceId => Id.InstanceNumber;

        public string ObjectName
        {
            get
            {
                CharacterString name = RawObjectName;
                if (name == null)
                    return null;
                return name.Value;
            }
        }

        public CharacterString RawObjectName => (CharacterString) properties[PropertyIdentifier.ObjectName];

        public string Description
        {
            get
            {
                CharacterString name = (CharacterString) properties[PropertyIdentifier.Description];
                if (name == null)
                    return null;
                return name.Value;
            }
        }

        //
        //
        // Get property
        //
        public Encodable getProperty(PropertyIdentifier pid)
        {
            if (pid.Value == PropertyIdentifier.ObjectIdentifier.Value)
                return Id;
            if (pid.Value == PropertyIdentifier.ObjectType.Value)
                return Id.ObjectType;

            // Check that the requested property is valid for the object. This will throw an exception if the
            // property doesn't belong.
            ObjectProperties.getPropertyTypeDefinitionRequired(Id.ObjectType, pid);

            // Do some property-specific checking here.
            if (pid.Value == PropertyIdentifier.LocalTime.Value)
                return new Time();
            if (pid.Value == PropertyIdentifier.LocalDate.Value)
                return new Date();

            // AdK - COV subscriptions
            if (pid.Value == PropertyIdentifier.ActiveCovSubscriptions.Value)
            {
                IList objs = localDevice.LocalObjects;
                SequenceOf covS = new SequenceOf(); // CovSubscriptions

                foreach (BACnetObject obj in objs)
                {
                    foreach (ObjectCovSubscription s in obj.covSubscriptions)
                    {
                        RemoteDevice d = localDevice.getRemoteDevice(s.Address);
                        Recipient r = null;
                        if (d != null)
                        {
                            r = new Recipient(d.ObjectIdentifier);
                        }
                        else
                        {
                            r = new Recipient(s.Address);
                        }
                        covS.add(new CovSubscription(new RecipientProcess(r, s.SubscriberProcessIdentifier),
                            new ObjectPropertyReference(obj.Id, PropertyIdentifier.PresentValue),
                            new BBoolean(s.IsIssueConfirmedNotifications),
                            new UnsignedInteger(s.GetTimeRemaining(System.DateTime.Now.Ticks)), obj.getCovIncrement()
                            ));
                    }
                }
                return covS;
            }

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

            if (!(result is SequenceOf))
            throw new BACnetServiceException(ErrorClass.Property, ErrorCode.PropertyIsNotAnArray);

        SequenceOf array = (SequenceOf ) result;
        uint index = propertyArrayIndex.Value;
        if (index == 0)
            return new UnsignedInteger((uint) array.Count);

        if (index > array.getCount())
            throw new BACnetServiceException(ErrorClass.Property, ErrorCode.InvalidArrayIndex);

        return array.Get((int) index);
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
            ObjectProperties.validateValue(Id.ObjectType, pid, value);
            setPropertyImpl(pid, value);

            // If the relinquish default was set, make sure the present value gets updated as necessary.
            if (pid.Equals(PropertyIdentifier.RelinquishDefault))
                setCommandableImpl((PriorityArray) getProperty(PropertyIdentifier.PriorityArray));
        }

        public void setProperty(PropertyIdentifier pid, uint indexBase1, Encodable value)
        {
            ObjectProperties.validateSequenceValue(Id.ObjectType, pid, value);
    SequenceOf list = (SequenceOf) properties[pid];
    if (list == null)
    {
        list = new SequenceOf();
        setPropertyImpl(pid, list);
    }
    list.set((int) indexBase1, value);
        }

        public void setProperty(PropertyValue value)
        {
            PropertyIdentifier pid = value.PropertyIdentifier;

            if (pid.Value== PropertyIdentifier.ObjectIdentifier.Value)
                throw new BACnetServiceException(ErrorClass.Property, ErrorCode.WriteAccessDenied);
            if (pid.Value== PropertyIdentifier.ObjectType.Value)
                throw new BACnetServiceException(ErrorClass.Property, ErrorCode.WriteAccessDenied);
            if (pid.Value== PropertyIdentifier.PriorityArray.Value)
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

            if (!value.Equals(oldValue))
    {
        // Check for subscriptions.
        if (ObjectCovSubscription.SendCovNotification(Id.ObjectType, pid, this.getCovIncrement()))
        {
            //synchronized(covSubscriptions) {
            long now = System.DateTime.Now.Ticks;
            ObjectCovSubscription sub;
            for (int i = covSubscriptions.Count - 1; i >= 0; i--)
            {
                sub = (ObjectCovSubscription) covSubscriptions[i];
                if (sub.HasExpired(now))
                    covSubscriptions.RemoveAt(i);
                else if (sub.IsNotificationRequired(pid, value))
                   sendCovNotification(sub, now);
            }
            //}
        }
    }
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

public void addCovSubscription(Address from, OctetString linkService, UnsignedInteger subscriberProcessIdentifier,
        BBoolean issueConfirmedNotifications, UnsignedInteger lifetime)
{
    //synchronized (covSubscriptions) {
        ObjectCovSubscription sub = findCovSubscription(from, subscriberProcessIdentifier);
    bool confirmed = issueConfirmedNotifications.Value;

        if (sub == null)
        {
            // Ensure that this object is valid for COV notifications.
            if (!ObjectCovSubscription.SendCovNotification(Id.ObjectType, null, this.getCovIncrement()))
                throw new BACnetServiceException(ErrorClass.Services, ErrorCode.CovSubscriptionFailed,
                        "Object is invalid for COV notifications");

            if (confirmed)
            {
                // If the peer wants confirmed notifications, it must be in the remote device list.
                RemoteDevice d = localDevice.getRemoteDevice(from);
                if (d == null)
                    throw new BACnetServiceException(ErrorClass.Services, ErrorCode.CovSubscriptionFailed,
                            "From address not found in remote device list. Cannot send confirmed notifications");
            }

            sub = new ObjectCovSubscription(from, linkService, subscriberProcessIdentifier, this.getCovIncrement());
            covSubscriptions.Add(sub);
        }

        sub.SetIssueConfirmedNotifications(issueConfirmedNotifications.Value);
        sub.SetExpiryTime((int) lifetime.Value);
   // }
}

public Real getCovIncrement()
{
    return (Real)properties[PropertyIdentifier.CovIncrement];
}

public void removeCovSubscription(Address from, UnsignedInteger subscriberProcessIdentifier)
{
    //synchronized(covSubscriptions) {
        ObjectCovSubscription sub = findCovSubscription(from, subscriberProcessIdentifier);
        if (sub != null)
            covSubscriptions.Remove(sub);
    //}
}

private ObjectCovSubscription findCovSubscription(Address from, UnsignedInteger subscriberProcessIdentifier)
{
    foreach (ObjectCovSubscription sub in covSubscriptions)
    {
        if (sub.Address.Equals(from)
                && sub.SubscriberProcessIdentifier.Equals(subscriberProcessIdentifier))
            return sub;
    }
    return null;
}

private void sendCovNotification(ObjectCovSubscription sub, long now)
{
    try
    {
        UnsignedInteger timeLeft = new UnsignedInteger(sub.GetTimeRemaining(now));
        SequenceOf values = new SequenceOf(ObjectCovSubscription.GetValues(this));

        if (sub.IsIssueConfirmedNotifications)
        {
            // Confirmed
            ConfirmedCovNotificationRequest req = new ConfirmedCovNotificationRequest(
                    sub.SubscriberProcessIdentifier, localDevice.Configuration.Id, Id, timeLeft,
                    values);
            RemoteDevice d = localDevice.getRemoteDevice(sub.Address);
            localDevice.send(d, req);
        }
        else {
            // Unconfirmed
            UnconfirmedCovNotificationRequest req = new UnconfirmedCovNotificationRequest(
                    sub.SubscriberProcessIdentifier, localDevice.Configuration.Id, Id, timeLeft,
                    values);
            localDevice.sendUnconfirmed(sub.Address, sub.LinkService, req);
        }
    }
    catch (BACnetException e)
    {
        throw e;
        //ExceptionDispatch.fireReceivedException(e);
    }
}
        
        public void validate()
        {
            // Ensure that all required properties have values.
            IList defs = ObjectProperties.getRequiredPropertyTypeDefinitions(Id.ObjectType);
            foreach (PropertyTypeDefinition def in defs)
            {
                if (getProperty(def.PropertyIdentifier) == null)
                    throw new BACnetServiceException(ErrorClass.Property, ErrorCode.Other, "Required property not set: " + def.PropertyIdentifier);
            }
        }

        public void removeProperty(PropertyIdentifier pid)
        {
            PropertyTypeDefinition def = ObjectProperties.getPropertyTypeDefinitionRequired(Id.ObjectType, pid);
            if (def.IsRequired)
                throw new BACnetServiceException(ErrorClass.Property, ErrorCode.WriteAccessDenied);
            properties.Remove(pid);
        }

        public void removeProperty(PropertyIdentifier pid, UnsignedInteger propertyArrayIndex)
        {
            PropertyTypeDefinition def = ObjectProperties.getPropertyTypeDefinitionRequired(Id.ObjectType, pid);
            if (!def.IsSequence)
                throw new BACnetServiceException(ErrorClass.Property, ErrorCode.InvalidArrayIndex);
            SequenceOf sequence = (SequenceOf) properties[pid];
            if (sequence != null)
                sequence.remove((int) propertyArrayIndex.Value);
        }
    }
}

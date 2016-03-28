using System.Collections;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;
using BACnetDataTypes.Objects;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;
using Math = System.Math;

namespace BACnetServices.Objects
{
    class ObjectCovSubscription
    {
        private static IList supportedObjectTypes = new ArrayList()
        {
            ObjectType.AccessDoor,
            ObjectType.Accumulator,
            ObjectType.AnalogInput,
            ObjectType.AnalogOutput,
            ObjectType.AnalogValue,
            ObjectType.BinaryInput,
            ObjectType.BinaryOutput,
            ObjectType.BinaryValue,
            ObjectType.LifeSafetyPoint,
            ObjectType.Loop,
            ObjectType.MultiStateInput,
            ObjectType.MultiStateOutput,
            ObjectType.MultiStateValue,
            ObjectType.PulseConverter
        };

        private static IList supportedPropertyIdentifiers = new ArrayList()
        {
            PropertyIdentifier.PresentValue,
            PropertyIdentifier.StatusFlags,
            PropertyIdentifier.DoorAlarmState
        };

        /** These types require a COV threshold, before any subscriptions are allowed */

        private static IList covThresholdRequired = new ArrayList()
        {
            ObjectType.AnalogInput,
            ObjectType.AnalogOutput,
            ObjectType.AnalogValue,
            ObjectType.Loop,
            ObjectType.PulseConverter
        };

        public static void AddSupportedObjectType(ObjectType objectType)
        {
            supportedObjectTypes.Add(objectType);
        }

        public static void AddSupportedPropertyIdentifier(PropertyIdentifier propertyIdentifier)
        {
            supportedPropertyIdentifiers.Add(propertyIdentifier);
        }

        public static bool SupportedObjectType(ObjectType objectType)
        {
            return supportedObjectTypes.Contains(objectType);
        }

        public static bool SendCovNotification(ObjectType objectType, PropertyIdentifier pid, Real covThresholdValue)
        {
            if (!SupportedObjectType(objectType))
                return false;

            if (pid != null && !supportedPropertyIdentifiers.Contains(pid))
                return false;

            // Don't allow COV notifications when there is no threshold for Objects that require thresholds.
            if (covThresholdRequired.Contains(objectType) && covThresholdValue == null)
                return false;

            return true;
        }

        public static IList GetValues(BACnetObject obj)
        {
            IList values = new ArrayList();
            foreach (PropertyIdentifier pid in supportedPropertyIdentifiers)
                AddValue(obj, values, pid);
            return values;
        }

        private static void AddValue(BACnetObject obj, IList values, PropertyIdentifier pid)
        {
            try
            {
                // Ensure that the obj has the given property. The addition of doorAlarmState requires this.
                if (ObjectProperties.getPropertyTypeDefinition(obj.Id.ObjectType, pid) != null)
                {
                    Encodable value = obj.getProperty(pid);
                    if (value != null)
                        values.Add(new PropertyValue(pid, value));
                }
            }
            catch (BACnetServiceException e)
            {
                // Should never happen, so wrap in a RuntimeException
                throw e;
            }
        }

        private long expiryTime;

        /**
     * The increment/threshold at which COV notifications should be sent out. Only applies to property identifiers that
     * are {@link Real}'s
     * and {@link ObjectType}'s mentioned in {@link ObjectCovSubscription#covThresholdRequired}.
     */
        private readonly Real covIncrement;

        /**
     * Contains the last sent values per property identifier. It is used to determine if a COV notification should be
     * sent.
     */
        private readonly Hashtable lastSentValues = new Hashtable();

        public ObjectCovSubscription(Address address, OctetString linkService,
            UnsignedInteger subscriberProcessIdentifier,
            Real covIncrement)
        {
            this.Address = address;
            this.LinkService = linkService;
            this.SubscriberProcessIdentifier = subscriberProcessIdentifier;
            this.covIncrement = covIncrement;
        }

        public Address Address { get; }

        public OctetString LinkService { get; }

        public bool IsIssueConfirmedNotifications { get; private set; }

        public UnsignedInteger SubscriberProcessIdentifier { get; }

        public void SetIssueConfirmedNotifications(bool issueConfirmedNotifications)
            => this.IsIssueConfirmedNotifications = issueConfirmedNotifications;

        public void SetExpiryTime(int seconds)
        {
            if (seconds == 0)
                expiryTime = -1;
            else
                expiryTime = System.DateTime.Now.Ticks + seconds*1000;
        }

        public bool HasExpired(long now)
        {
            if (expiryTime == -1)
                return false;
            return expiryTime < now;
        }

        public uint GetTimeRemaining(long now)
        {
            if (expiryTime == -1)
                return 0;
            uint left = (uint) ((expiryTime - now)/1000);
            if (left < 1)
                return 1;
            return left;
        }

        /**
     * Determine if a notification needs to be sent out based on the Threshold if relevant.
     * 
     * @param pid
     *            The {@link PropertyIdentifier} being updated
     * @param value
     *            The new value
     * @return true if a COV notification should be sent out, false otherwise.
     */

        public bool IsNotificationRequired(PropertyIdentifier pid, Encodable value)
        {
            Encodable lastSentValue = (Encodable) lastSentValues[pid];

            bool notificationRequired = ThresholdCalculator.IsValueOutsideOfThreshold(this.covIncrement,
                lastSentValue,
                value);

            if (notificationRequired)
            {
                lastSentValues[pid] = value;
            }

            return notificationRequired;
        }
    }

/**
* Utility Class to determine whether COV thresholds/increments have been surpassed.
* 
* @author japearson
* 
*/

    public static class ThresholdCalculator
    {
        /**
         * Convert the given encodable value to a {@link Float} if possible.
         * 
         * @param value
         *            The value to attempt to convert to a {@link Float}.
         * @return A {@link Float} value if the {@link Encodable} can be converted, otherwise null.
         */

        private static float ConvertEncodableToFloat(Encodable value)
        {
            float floatValue = float.MinValue; // TODO

            if (value is Real)
            {
                floatValue = ((Real) value).Value;
            }

            return floatValue;
        }

        /**
         * Determine if the newValue has surpassed the threshold value compared with the original value.
         * <p>
         * When the originalValue is null, it is automatically assumed to be outside the threshold, because it means the
         * property hasn't been seen before.
         * <p>
         * If any of the parameters cannot be converted to a {@link Float}, then this method returns true when the
         * original and new value are not equal and false otherwise.
         * 
         * @param threshold
         *            The threshold value
         * @param originalValue
         *            The original or last sent value
         * @param newValue
         *            The new value to check
         * @return true if the new value is outside the threshold or false otherwise.
         */

        public static bool IsValueOutsideOfThreshold(Real threshold, Encodable originalValue, Encodable newValue)
        {
            float floatThreshold = ConvertEncodableToFloat(threshold);
            float floatOriginal = ConvertEncodableToFloat(originalValue);
            float floatNewValue = ConvertEncodableToFloat(newValue);

            // This property hasn't been seen before, so a notification is required
            if (originalValue == null)
            {
                return true;
            }
            // Handle types that can't do threshold comparisons
            else if (floatThreshold == float.MinValue || floatOriginal == float.MinValue ||
                     floatNewValue == float.MinValue)
            {
                return !originalValue.Equals(newValue);
            }
            else
            {
                // Due to floating point maths, it's possible that where the difference should be equal to the threshold
                // and not be outside the threshold actually evaluates to true due to precision errors.  However since
                // this threshold is calculated only for use in deciding whether to trigger a COV notification, small
                // margins of error on boundary cases are acceptable.
                return Math.Abs(floatNewValue - floatOriginal) > floatThreshold;
            }
        }
    }
}

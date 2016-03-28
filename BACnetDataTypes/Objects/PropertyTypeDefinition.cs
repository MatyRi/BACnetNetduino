using System;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;

namespace BACnetDataTypes.Objects
{
    public class PropertyTypeDefinition
    {
        internal PropertyTypeDefinition(ObjectType objectType, PropertyIdentifier propertyIdentifier, Type type, bool sequence, bool required, Encodable defaultValue)
        {
            ObjectType = objectType;
            PropertyIdentifier = propertyIdentifier;
            Type = type;
            IsSequence = sequence;
            IsRequired = required;
            DefaultValue = defaultValue;
        }

        public ObjectType ObjectType { get; }

        public PropertyIdentifier PropertyIdentifier { get; }

        public Type Type { get; }

        public bool IsSequence { get; }

        public bool IsRequired { get; }

        public bool IsOptional => !IsRequired;

        public Encodable DefaultValue { get; }

        public Type InnerType
        {
            get
            {
                if (Type == typeof(PriorityArray))
                {
                    return typeof(PriorityValue);
                }

                return null;
            }
        }
    }
}

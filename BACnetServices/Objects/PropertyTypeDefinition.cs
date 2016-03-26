using System;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;

namespace BACnetServices.Objects
{
    internal class PropertyTypeDefinition
    {
        private readonly ObjectType objectType;
        private readonly PropertyIdentifier propertyIdentifier;
        private readonly Type type;
        private readonly bool sequence;
        private readonly bool required;
        private readonly Encodable defaultValue;

        internal PropertyTypeDefinition(ObjectType objectType, PropertyIdentifier propertyIdentifier, Type type, bool sequence, bool required, Encodable defaultValue)
        {
            this.objectType = objectType;
            this.propertyIdentifier = propertyIdentifier;
            this.type = type;
            this.sequence = sequence;
            this.required = required;
            this.defaultValue = defaultValue;
        }

        public ObjectType getObjectType()
        {
            return objectType;
        }

        public PropertyIdentifier getPropertyIdentifier()
        {
            return propertyIdentifier;
        }

        public Type getType() // extends Encodable
        {
            return type;
        }

        public bool isSequence()
        {
            return sequence;
        }

        public bool isRequired()
        {
            return required;
        }

        public bool isOptional()
        {
            return !required;
        }

        public Encodable getDefaultValue()
        {
            return defaultValue;
        }

        public Type getInnerType() // extends Encodable
        {
            if (type == typeof (PriorityArray))
            {
                return typeof (PriorityValue);
            }

            return null;
        }
    }
}

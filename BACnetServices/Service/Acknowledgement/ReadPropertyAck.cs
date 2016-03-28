using System;
using BACnetDataTypes;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetServices.Service.Acknowledgement
{
    class ReadPropertyAck : AcknowledgementService
    {
        public static readonly byte TYPE_ID = 12;

        public ReadPropertyAck(ObjectIdentifier eventObjectIdentifier, PropertyIdentifier propertyIdentifier,
            UnsignedInteger propertyArrayIndex, Encodable value)
        {
            EventObjectIdentifier = eventObjectIdentifier;
            PropertyIdentifier = propertyIdentifier;
            PropertyArrayIndex = propertyArrayIndex;
            Value = value;
        }

        public override byte ChoiceId => TYPE_ID;

        public override string ToString() => "ReadPropertyAck(" + Value + ")";

        public ObjectIdentifier EventObjectIdentifier { get; }

        public UnsignedInteger PropertyArrayIndex { get; }

        public PropertyIdentifier PropertyIdentifier { get; }

        public Encodable Value { get; }

        public override void write(ByteStream queue)
        {
            write(queue, EventObjectIdentifier, 0);
            write(queue, PropertyIdentifier, 1);
            writeOptional(queue, PropertyArrayIndex, 2);
            writeEncodable(queue, Value, 3);
        }

        internal ReadPropertyAck(ByteStream queue)
        {
            EventObjectIdentifier = (ObjectIdentifier) read(queue, typeof (ObjectIdentifier), 0);
            PropertyIdentifier = (PropertyIdentifier) read(queue, typeof (PropertyIdentifier), 1);
            PropertyArrayIndex = (UnsignedInteger) readOptional(queue, typeof (UnsignedInteger), 2);
            Value = readEncodable(queue, EventObjectIdentifier.ObjectType, PropertyIdentifier, PropertyArrayIndex, 3);
        }
    }
}

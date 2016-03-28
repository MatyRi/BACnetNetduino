using System;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetServices.Service.Acknowledgement
{
    class ReadRangeAck : AcknowledgementService
    {
        public static readonly byte TYPE_ID = 26;

        public ReadRangeAck(ObjectIdentifier objectIdentifier, PropertyIdentifier propertyIdentifier,
            UnsignedInteger propertyArrayIndex, ResultFlags resultFlags, UnsignedInteger itemCount,
            SequenceOf itemData, UnsignedInteger firstSequenceNumber)
        {
            ObjectIdentifier = objectIdentifier;
            PropertyIdentifier = propertyIdentifier;
            PropertyArrayIndex = propertyArrayIndex;
            ResultFlags = resultFlags;
            ItemCount = itemCount;
            ItemData = itemData;
            FirstSequenceNumber = firstSequenceNumber;
        }

        public override byte ChoiceId => TYPE_ID;

        public override void write(ByteStream queue)
        {
            write(queue, ObjectIdentifier, 0);
            write(queue, PropertyIdentifier, 1);
            writeOptional(queue, PropertyArrayIndex, 2);
            write(queue, ResultFlags, 3);
            write(queue, ItemCount, 4);
            write(queue, ItemData, 5);
            writeOptional(queue, FirstSequenceNumber, 6);
        }

        internal ReadRangeAck(ByteStream queue)
        {
            ObjectIdentifier = (ObjectIdentifier) read(queue, typeof (ObjectIdentifier), 0);
            PropertyIdentifier = (PropertyIdentifier) read(queue, typeof (PropertyIdentifier), 1);
            PropertyArrayIndex = (UnsignedInteger) readOptional(queue, typeof (UnsignedInteger), 2);
            ResultFlags = (ResultFlags) read(queue, typeof (ResultFlags), 3);
            ItemCount = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 4);
            ItemData = readSequenceOfEncodable(queue, ObjectIdentifier.ObjectType, PropertyIdentifier, 5);
            FirstSequenceNumber = (UnsignedInteger) readOptional(queue, typeof (UnsignedInteger), 6);
        }

        public ObjectIdentifier ObjectIdentifier { get; }

        public PropertyIdentifier PropertyIdentifier { get; }

        public UnsignedInteger PropertyArrayIndex { get; }

        public ResultFlags ResultFlags { get; }

        public UnsignedInteger ItemCount { get; }

        public SequenceOf ItemData { get; }

        public UnsignedInteger FirstSequenceNumber { get; }
    }
}

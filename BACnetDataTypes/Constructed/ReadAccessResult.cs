using System;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetDataTypes.Constructed
{
    public class ReadAccessResult : BaseType
    {
        public ReadAccessResult(ObjectIdentifier objectIdentifier, SequenceOf listOfResults)
        {
            ObjectIdentifier = objectIdentifier;
            ListOfResults = listOfResults;
        }

        public override void write(ByteStream queue)
        {
            write(queue, ObjectIdentifier, 0);
            writeOptional(queue, ListOfResults, 1);
        }

        public override string ToString() => "ReadAccessResult(oid=" + ObjectIdentifier + ", results=" + ListOfResults + ")";

        public SequenceOf ListOfResults { get; }

        public ObjectIdentifier ObjectIdentifier { get; }

        public ReadAccessResult(ByteStream queue)
        {
            ObjectIdentifier = (ObjectIdentifier) read(queue, typeof (ObjectIdentifier), 0);
            try
            {
                ThreadLocalObjectTypeStack.set(ObjectIdentifier.ObjectType);
                ListOfResults = readOptionalSequenceOf(queue, typeof (Result), 1);
            }
            finally
            {
                ThreadLocalObjectTypeStack.remove();
            }
        }
    }

    public class Result : BaseType
    {
        public Result(PropertyIdentifier propertyIdentifier, UnsignedInteger propertyArrayIndex, Encodable readResult)
        {
            this.PropertyIdentifier = propertyIdentifier;
            this.PropertyArrayIndex = propertyArrayIndex;
            this.ReadResult = new Choice(4, readResult);
        }

        public Result(PropertyIdentifier propertyIdentifier, UnsignedInteger propertyArrayIndex, BACnetError readResult)
        {
            this.PropertyIdentifier = propertyIdentifier;
            this.PropertyArrayIndex = propertyArrayIndex;
            this.ReadResult = new Choice(5, readResult);
        }

        public UnsignedInteger PropertyArrayIndex { get; }

        public PropertyIdentifier PropertyIdentifier { get; }

        public bool IsError => ReadResult.ContextId == 5;

        public Choice ReadResult { get; }

        public override string ToString() => "Result(pid=" + PropertyIdentifier
                                             + (PropertyArrayIndex == null ? "" : ", pin=" + PropertyArrayIndex) + ", value=" + ReadResult + ")";


        public override void write(ByteStream queue)
        {
            write(queue, PropertyIdentifier, 2);
            writeOptional(queue, PropertyArrayIndex, 3);
            if (ReadResult.ContextId == 4)
                writeEncodable(queue, ReadResult.Data, 4);
            else
                write(queue, ReadResult.Data, 5);
        }

        public Result(ByteStream queue)
        {
            PropertyIdentifier = (PropertyIdentifier) read(queue, typeof (PropertyIdentifier), 2);
            PropertyArrayIndex = (UnsignedInteger) readOptional(queue, typeof (UnsignedInteger), 3);
            int contextId = peekTagNumber(queue);
            if (contextId == 4)
                ReadResult = new Choice(4, readEncodable(queue, ThreadLocalObjectTypeStack.get(), PropertyIdentifier,
                    PropertyArrayIndex, 4));
            else
                ReadResult = new Choice(5, read(queue, typeof (BACnetError), 5));
        }
    }
}

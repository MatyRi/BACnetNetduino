using System;
using BACnetNetduino.DataTypes.Enumerated;
using BACnetNetduino.Exception;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes
{
    internal abstract class Encodable
    {
        //TODO public abstract void write(ByteStream source);
        public virtual void write(ByteStream source)
        {
            throw new NotImplementedException();
        }

        //TODO public abstract void write(ByteStream source, int contextId);
        public virtual void write(ByteStream source, int contextId)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Encodable(" + this.GetType().Name + ")";
        }

        protected static void popTagData(ByteStream source, TagData tagData)
        {
            peekTagData(source, tagData);
            source.pop(tagData.tagLength);
        }

        protected static void peekTagData(ByteStream source, TagData tagData)
        {
            long peekIndexStart = source.Position;
            byte b = source.ReadByte();
            tagData.tagNumber = (b & 0xff) >> 4;
            tagData.contextSpecific = (b & 8) != 0;
            tagData.length = (b & 7);

            if (tagData.tagNumber == 0xf)
                // Extended tag.
                tagData.tagNumber = BACnetUtils.toInt(source.ReadByte());

            if (tagData.length == 5)
            {
                tagData.length = BACnetUtils.toInt(source.ReadByte());
                if (tagData.length == 254)
                    tagData.length = (BACnetUtils.toInt(source.ReadByte()) << 8)
                            | BACnetUtils.toInt(source.ReadByte());
                else if (tagData.length == 255)
                    tagData.length = (BACnetUtils.toLong(source.ReadByte()) << 24)
                            | (BACnetUtils.toLong(source.ReadByte()) << 16)
                            | (BACnetUtils.toLong(source.ReadByte()) << 8)
                            | BACnetUtils.toLong(source.ReadByte());
            }

            tagData.tagLength = (int) (source.Position - peekIndexStart);
            source.Position = peekIndexStart;
        }

        protected static int peekTagNumber(ByteStream source)
        {
            if (source.Length == 0)
                return -1;

            byte[] peekTag = new byte[2];
            source.Peek(peekTag); // Might throw exception if only one byte

            // Take a peek at the tag number.
            int tagNumber = (peekTag[0] & 0xff) >> 4;
            if (tagNumber == 15)
                tagNumber = peekTag[1] & 0xff;

            return tagNumber;
        }

        //
        // Write context tags for base types.
        protected void writeContextTag(ByteStream source, int contextId, bool start)
        {
            if (contextId <= 14)
                source.WriteByte((byte) ((contextId << 4) | (start ? 0xe : 0xf)));
            else {
                source.WriteByte((byte) (start ? 0xfe : 0xff));
                source.WriteByte((byte) contextId);
            }
        }

        //
        // Read start tags.
        protected static int readStart(ByteStream source)
        {
            if (source.Length == 0)
                return -1;

            byte[] startBytes = new byte[2];
            source.Peek(startBytes);

            int b = startBytes[0] & 0xff;
            if ((b & 0xf) != 0xe)
                return -1;
            if ((b & 0xf0) == 0xf0)
                return startBytes[1];
            return b >> 4;
        }

        protected static int popStart(ByteStream source)
        {
            int contextId = readStart(source);
            if (contextId != -1)
            {
                source.ReadByte();
                if (contextId > 14)
                    source.ReadByte();
            }
            return contextId;
        }

        protected static void popStart(ByteStream source, int contextId) //throws BACnetErrorException
        {
        if (popStart(source) != contextId)
            throw new BACnetErrorException(ErrorClass.property, ErrorCode.missingRequiredParameter);
    }

    //
    // Read end tags.
    protected static int readEnd(ByteStream source)
    {
        if (source.Length == 0)
            return -1;
        int b = source.PeekFromHere(0) & 0xff;
        if ((b & 0xf) != 0xf)
            return -1;
        if ((b & 0xf0) == 0xf0)
            return source.PeekFromHere(1);
        return b >> 4;
    }

    protected static void popEnd(ByteStream source, int contextId) //throws BACnetErrorException
    {
        if (readEnd(source) != contextId)
        {
                throw new BACnetErrorException(ErrorClass.property, ErrorCode.missingRequiredParameter);
        }
        source.ReadByte();
        if (contextId > 14)
            source.ReadByte();
    }

    private static bool matchContextId(ByteStream source, int contextId)
    {
        return peekTagNumber(source) == contextId;
    }

    protected static bool matchStartTag(ByteStream source, int contextId)
    {
        return matchContextId(source, contextId) && (source.PeekFromHere(0) & 0xf) == 0xe;
    }

    protected static bool matchEndTag(ByteStream source, int contextId)
    {
        return matchContextId(source, contextId) && (source.PeekFromHere(0) & 0xf) == 0xf;
    }

    protected static bool matchNonEndTag(ByteStream source, int contextId)
    {
        return matchContextId(source, contextId) && (source.PeekFromHere(0) & 0xf) != 0xf;
    }

    //
    // Basic read and write. Pretty trivial.
    protected static void write(ByteStream source, Encodable type)
    {
        type.write(source);
    }

        protected static Encodable read(ByteStream source, Type type) //throws BACnetException
        {
            if (type.IsSubclassOf(typeof (Primitive.Primitive)))
            {
                return Primitive.Primitive.createPrimitive(source);
            }

            var constructor = type.GetConstructor(new Type[] {typeof (ByteStream)});
            Encodable obj = (Encodable) constructor.Invoke(new object[] {source});

            return obj;
        }

    //
    // Read and write with context id.
    protected static Encodable read(ByteStream source, Type type, int contextId)
    {
        if (!matchNonEndTag(source, contextId))
            throw new BACnetErrorException(ErrorClass.property, ErrorCode.missingRequiredParameter);

        if (type.IsInstanceOfType(typeof (Primitive.Primitive)))
            return read(source, type);
        return readWrapped(source, type, contextId);
    }

    /* TODO protected static void write(ByteStream source, Encodable type, int contextId)
    {
        type.write(source, contextId);
    }*/

    //
    // Optional read and write.
    /* TODO protected static void writeOptional(ByteStream source, Encodable type)
    {
        if (type == null)
            return;
        write(source, type);
    }*/

    /* TODO protected static void writeOptional(ByteStream source, Encodable type, int contextId)
    {
        if (type == null)
            return;
        write(source, type, contextId);
     }*/

    /*protected static <T extends Encodable> T readOptional(ByteStream source, Class<T> clazz, int contextId)
               // throws BACnetException
    {
            if (!matchNonEndTag(source, contextId))
                return null;
            return read(source, clazz, contextId);
    }*/

    //
    // Read lists
    /*protected static <T extends Encodable> SequenceOf<T> readSequenceOf(ByteStream source, Class<T> clazz)
               // throws BACnetException
    {
            return new SequenceOf<T>(source, clazz);
        }*/

        /*protected static <T extends Encodable> SequenceOf<T> readSequenceOf(ByteStream source, int count, Class<T> clazz)
                //throws BACnetException
    {
            return new SequenceOf<T>(source, count, clazz);
        }*/

        /*protected static <T extends Encodable> SequenceOf<T> readSequenceOf(ByteStream source, Class<T> clazz, int contextId)
                //throws BACnetException
    {
        popStart(source, contextId);
        SequenceOf<T> result = new SequenceOf<T>(source, clazz, contextId);
        popEnd(source, contextId);
        return result;
    }*/

    /*protected static <T extends Encodable> T readSequenceType(ByteStream source, Class<T> clazz, int contextId)
            //throws BACnetException
{
    popStart(source, contextId);
    T result;
        try {
        result = clazz.getConstructor(new Class[] { ByteStream.class, Integer.TYPE }).newInstance(
                    new Object[] { source, contextId });
        }
        catch (Exception e) {
            throw new BACnetException(e);
        }
        popEnd(source, contextId);
        return result;
    }*/

    /*protected static SequenceOf<Choice> readSequenceOfChoice(ByteStream source, List<Class<? extends Encodable>> classes,
            int contextId) //throws BACnetException
{
    popStart(source, contextId);
    SequenceOf<Choice> result = new SequenceOf<Choice>();
        while (readEnd(source) != contextId)
            result.add(new Choice(source, classes));
        popEnd(source, contextId);
        return result;
    }*/

    /*protected static <T extends Encodable> SequenceOf<T> readOptionalSequenceOf(ByteStream source, Class<T> clazz,
            int contextId)// throws BACnetException
{
        if (readStart(source) != contextId)
            return null;
        return readSequenceOf(source, clazz, contextId);
}*/

// Read and write encodable
/*protected static void writeEncodable(ByteStream source, Encodable type, int contextId)
{
    if (Primitive.class.isAssignableFrom(type.getClass()))
            ((Primitive) type).writeEncodable(source, contextId);
        else
            type.write(source, contextId);
    }*/

    /*protected static Encodable readEncodable(ByteStream source, ObjectType objectType,
            PropertyIdentifier propertyIdentifier, UnsignedInteger propertyArrayIndex, int contextId)
            //throws BACnetException
{
        // A property array index of 0 indicates a request for the Length of an array.
        if (propertyArrayIndex != null && propertyArrayIndex.intValue() == 0)
            return readWrapped(source, UnsignedInteger.class, contextId);

        if (!matchNonEndTag(source, contextId))
            throw new BACnetErrorException(ErrorClass.property, ErrorCode.missingRequiredParameter);

PropertyTypeDefinition def = ObjectProperties.getPropertyTypeDefinition(objectType, propertyIdentifier);
        if (def == null)
            return new AmbiguousValue(source, contextId);

        if (ObjectProperties.isCommandable(objectType, propertyIdentifier)) {
            // If the object is commandable, it could be set to Null, so we need to treat it as ambiguous.
            AmbiguousValue amb = new AmbiguousValue(source, contextId);

            if (amb.isNull())
                return new Null();

            // Try converting to the definition value.
            return amb.convertTo(def.getClazz());
        }

        if (propertyArrayIndex != null) {
            if (!def.isSequence() && !SequenceOf.class.isAssignableFrom(def.getClazz()))
                throw new BACnetErrorException(ErrorClass.property, ErrorCode.propertyIsNotAList);
            if (SequenceOf.class.isAssignableFrom(def.getClazz()))
                return readWrapped(source, def.getInnerType(), contextId);
        }
        else {
            if (def.isSequence())
                return readSequenceOf(source, def.getClazz(), contextId);
            if (SequenceOf.class.isAssignableFrom(def.getClazz()))
                return readSequenceType(source, def.getClazz(), contextId);
        }

        return readWrapped(source, def.getClazz(), contextId);
    }*/

    /*protected static Encodable readOptionalEncodable(ByteStream source, ObjectType objectType,
            PropertyIdentifier propertyIdentifier, int contextId)// throws BACnetException
{
        if (readStart(source) != contextId)
            return null;
        return readEncodable(source, objectType, propertyIdentifier, null, contextId);
}*/

/*protected static SequenceOf<? extends Encodable> readSequenceOfEncodable(ByteStream source, ObjectType objectType,
        PropertyIdentifier propertyIdentifier, int contextId) //throws BACnetException
{
    PropertyTypeDefinition def = ObjectProperties.getPropertyTypeDefinition(objectType, propertyIdentifier);
        if (def == null)
            return readSequenceOf(source, AmbiguousValue.class, contextId);
        return readSequenceOf(source, def.getClazz(), contextId);
    }*/

    // Read vendor-specific
    /*protected static Sequence readVendorSpecific(ByteStream source, UnsignedInteger vendorId,
            UnsignedInteger serviceNumber, Map<VendorServiceKey, SequenceDefinition> resolutions, int contextId)
           // throws BACnetException
{
        if (readStart(source) != contextId)
            return null;

    VendorServiceKey key = new VendorServiceKey(vendorId, serviceNumber);
SequenceDefinition def = resolutions.get(key);
        if (def == null) {
            ExceptionDispatch.fireUnimplementedVendorService(vendorId, serviceNumber, source);
            return null;
        }

        return new Sequence(def, source, contextId);
    }*/

    private static Encodable readWrapped(ByteStream source, Type type, int contextId)
    {
        popStart(source, contextId);
        Encodable result = read(source, type);
        popEnd(source, contextId);
            return result;
    }
    }
}

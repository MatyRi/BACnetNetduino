using System;
using System.Collections;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;
using BACnetDataTypes.Objects;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes
{
    public abstract class Encodable
    {
        public virtual void write(ByteStream source)
        {
            // TODO Abstract
            throw new NotImplementedException();
        }

        public virtual void write(ByteStream source, int contextId)
        {
            // TODO Abstract
            throw new NotImplementedException();
        }

        public override string ToString() => "Encodable(" + GetType().Name + ")";

        protected static void popTagData(ByteStream source, TagData tagData)
        {
            peekTagData(source, tagData);
            source.pop(tagData.TagLength);
        }

        protected static void peekTagData(ByteStream source, TagData tagData)
        {
            long peekIndexStart = source.Position;
            byte b = source.ReadByte();
            tagData.TagNumber = (b & 0xff) >> 4;
            tagData.ContextSpecific = (b & 8) != 0;
            tagData.Length = (b & 7);

            if (tagData.TagNumber == 0xf)
                // Extended tag.
                tagData.TagNumber = BACnetUtils.toInt(source.ReadByte());

            if (tagData.Length == 5)
            {
                tagData.Length = BACnetUtils.toInt(source.ReadByte());
                if (tagData.Length == 254)
                    tagData.Length = (BACnetUtils.toInt(source.ReadByte()) << 8)
                                     | BACnetUtils.toInt(source.ReadByte());
                else if (tagData.Length == 255)
                    tagData.Length = (BACnetUtils.toLong(source.ReadByte()) << 24)
                                     | (BACnetUtils.toLong(source.ReadByte()) << 16)
                                     | (BACnetUtils.toLong(source.ReadByte()) << 8)
                                     | BACnetUtils.toLong(source.ReadByte());
            }

            tagData.TagLength = (int) (source.Position - peekIndexStart);
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
            else
            {
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

        protected static void popStart(ByteStream source, int contextId)
        {
            if (popStart(source) != contextId)
                throw new BACnetErrorException(ErrorClass.Property, ErrorCode.MissingRequiredParameter);
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

        protected static void popEnd(ByteStream source, int contextId)
        {
            if (readEnd(source) != contextId)
            {
                throw new BACnetErrorException(ErrorClass.Property, ErrorCode.MissingRequiredParameter);
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

        protected static Encodable read(ByteStream source, Type type)
        {
            if (type.IsSubclassOf(typeof (Primitive.Primitive)))
            {
                return Primitive.Primitive.CreatePrimitive(source);
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
                throw new BACnetErrorException(ErrorClass.Property, ErrorCode.MissingRequiredParameter);

            if (type.IsSubclassOf(typeof (Primitive.Primitive)))
                return read(source, type);
            return readWrapped(source, type, contextId);
        }

        protected static void write(ByteStream source, Encodable type, int contextId)
        {
            type.write(source, contextId);
        }

        //
        // Optional read and write.
        protected static void writeOptional(ByteStream source, Encodable type)
        {
            if (type == null)
                return;
            write(source, type);
        }

        protected static void writeOptional(ByteStream source, Encodable type, int contextId)
        {
            if (type == null)
                return;
            write(source, type, contextId);
        }

        protected static Encodable readOptional(ByteStream source, Type type, int contextId)
        {
            if (!matchNonEndTag(source, contextId))
                return null;
            return read(source, type, contextId);
        }

        //
        // Read lists
        protected static SequenceOf readSequenceOf(ByteStream source, Type type)
        {
            return new SequenceOf(source, type);
        }

        protected static SequenceOf readSequenceOf(ByteStream source, int count, Type type)
        {
            return new SequenceOf(source, count, type);
        }

        protected static SequenceOf readSequenceOf(ByteStream source, Type type, int contextId)
        {
            popStart(source, contextId);
            SequenceOf result = new SequenceOf(source, type, contextId);
            popEnd(source, contextId);
            return result;
        }

        protected static Encodable readSequenceType(ByteStream source, Type type, int contextId)
        {
            popStart(source, contextId);
            Encodable result = null;
            try
            {
                var constructor = type.GetConstructor(new Type[] {typeof (ByteStream), typeof (int)});
                result = (Encodable) constructor.Invoke(new object[] {source, contextId});
            }
            catch (System.Exception e)
            {
                throw new BACnetException(e);
            }
            popEnd(source, contextId);
            return result;
        }

        // SequenceOf<Choice>
        protected static SequenceOf readSequenceOfChoice(ByteStream source, IList types, int contextId)
        {
            popStart(source, contextId);
            SequenceOf result = new SequenceOf(typeof (Choice));
            while (readEnd(source) != contextId)
                result.add(new Choice(source, types));
            popEnd(source, contextId);
            return result;
        }

        protected static SequenceOf readOptionalSequenceOf(ByteStream source, Type type, int contextId)
        {
            if (readStart(source) != contextId)
                return null;
            return readSequenceOf(source, type, contextId);
        }

        // Read and write encodable
        protected static void writeEncodable(ByteStream source, Encodable type, int contextId)
        {
            if (type.GetType().IsSubclassOf(typeof (Primitive.Primitive)))
                ((Primitive.Primitive) type).WriteEncodable(source, contextId);
            else
                type.write(source, contextId);
        }

        protected static Encodable readEncodable(ByteStream source, ObjectType objectType,
            PropertyIdentifier propertyIdentifier, UnsignedInteger propertyArrayIndex, int contextId)
        {
            // A property array index of 0 indicates a request for the Length of an array.
            if (propertyArrayIndex != null && propertyArrayIndex.Value == 0)
                return readWrapped(source, typeof (UnsignedInteger), contextId);

            if (!matchNonEndTag(source, contextId))
                throw new BACnetErrorException(ErrorClass.Property, ErrorCode.MissingRequiredParameter);

            PropertyTypeDefinition def = ObjectProperties.getPropertyTypeDefinition(objectType, propertyIdentifier);
            if (def == null)
                return new AmbiguousValue(source, contextId);

            if (ObjectProperties.isCommandable(objectType, propertyIdentifier))
            {
                // If the object is commandable, it could be set to Null, so we need to treat it as ambiguous.
                AmbiguousValue amb = new AmbiguousValue(source, contextId);

                if (amb.IsNull)
                    return new Null();

                // Try converting to the definition value.
                return (Encodable) amb.ConvertTo(def.getType());
            }

            if (propertyArrayIndex != null)
            {
                if (!def.isSequence() && !def.getType().IsSubclassOf(typeof (SequenceOf)))
                    throw new BACnetErrorException(ErrorClass.Property, ErrorCode.PropertyIsNotAList);
                if (def.getType().IsSubclassOf(typeof (SequenceOf)))
                    return readWrapped(source, def.getInnerType(), contextId);
            }
            else
            {
                if (def.isSequence())
                    return readSequenceOf(source, def.getType(), contextId);
                if (def.getType().IsSubclassOf(typeof (SequenceOf)))
                    return readSequenceType(source, def.getType(), contextId);
            }

            return readWrapped(source, def.getType(), contextId);
        }

        protected static Encodable readOptionalEncodable(ByteStream source, ObjectType objectType,
            PropertyIdentifier propertyIdentifier, int contextId)
        {
            if (readStart(source) != contextId)
                return null;
            return readEncodable(source, objectType, propertyIdentifier, null, contextId);
        }

        protected static SequenceOf readSequenceOfEncodable(ByteStream source, ObjectType objectType,
            PropertyIdentifier propertyIdentifier, int contextId)
        {
            PropertyTypeDefinition def = ObjectProperties.getPropertyTypeDefinition(objectType, propertyIdentifier);
            if (def == null)
                return readSequenceOf(source, typeof (AmbiguousValue), contextId);
            return readSequenceOf(source, def.getType(), contextId);
        }

        // Read vendor-specific // Map<VendorServiceKey, SequenceDefinition>
        protected static Sequence readVendorSpecific(ByteStream source, UnsignedInteger vendorId,
            UnsignedInteger serviceNumber, Hashtable resolutions, int contextId)
        {
            if (readStart(source) != contextId)
                return null;

            VendorServiceKey key = new VendorServiceKey(vendorId, serviceNumber);
            SequenceDefinition def = (SequenceDefinition) resolutions[key];
            if (def == null)
            {
                // TODO ExceptionDispatch.fireUnimplementedVendorService(vendorId, serviceNumber, source);
                return null;
            }

            return new Sequence(def, source, contextId);
        }

        private static Encodable readWrapped(ByteStream source, Type type, int contextId)
        {
            popStart(source, contextId);
            Encodable result = read(source, type);
            popEnd(source, contextId);
            return result;
        }
    }
}

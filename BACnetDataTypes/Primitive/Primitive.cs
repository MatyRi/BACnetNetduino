using System;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;

namespace BACnetDataTypes.Primitive
{
    public abstract class Primitive : Encodable
    {
        public static Primitive createPrimitive(ByteStream queue) //throws BACnetErrorException
        {
            // Get the first byte. The 4 high-order bits will tell us what the data type is.
            byte type = queue.PeekFromHere(0);
            type = (byte) ((type & 0xff) >> 4);
            return createPrimitive(type, queue);
        }

        public static Primitive createPrimitive(ByteStream queue, int contextId, int typeId)
            // throws BACnetErrorException
        {
            int tagNumber = peekTagNumber(queue);

            // Check if the tag number matches the context id. If they match, then create the context-specific parameter,
            // otherwise return null.
            if (tagNumber != contextId)
                return null;

            return createPrimitive(typeId, queue);
        }

        private static Primitive createPrimitive(int typeId, ByteStream queue) // throws BACnetErrorException
        {
            if (typeId == Null.TYPE_ID)
                return new Null(queue);
            if (typeId == BBoolean.TYPE_ID)
                return new BBoolean(queue);
            if (typeId == UnsignedInteger.TYPE_ID)
                return new UnsignedInteger(queue);
            if (typeId == SignedInteger.TYPE_ID)
                return new SignedInteger(queue);
            if (typeId == Real.TYPE_ID)
                return new Real(queue);
            if (typeId == BDouble.TYPE_ID)
                return new BDouble(queue);
            if (typeId == OctetString.TYPE_ID)
                return new OctetString(queue);
            if (typeId == CharacterString.TYPE_ID)
                return new CharacterString(queue);
            if (typeId == BitString.TYPE_ID)
                return new BitString(queue);
            if (typeId == Enumerated.TYPE_ID)
                return new Enumerated(queue);
            if (typeId == Date.TYPE_ID)
                return new Date(queue);
            if (typeId == Time.TYPE_ID)
                return new Time(queue);
            if (typeId == ObjectIdentifier.TYPE_ID)
                return new ObjectIdentifier(queue);

            throw new BACnetErrorException(ErrorClass.Property, ErrorCode.InvalidParameterDataType);
        }

/**
 * This field is maintained specifically for boolean types, since their encoding differs depending on whether the
 * type is context specific or not.
 */
        protected bool contextSpecific;

        public override void write(ByteStream queue)
        {
            writeTag(queue, TypeId, false, Length);
            writeImpl(queue);
        }

        public override void write(ByteStream queue, int contextId)
        {
            contextSpecific = true;
            writeTag(queue, contextId, true, Length);
            writeImpl(queue);
        }

        public void writeEncodable(ByteStream queue, int contextId)
        {
            writeContextTag(queue, contextId, true);
            write(queue);
            writeContextTag(queue, contextId, false);
        }

        protected virtual void writeImpl(ByteStream queue)
        {
            throw new NotImplementedException();
        }

        protected abstract long Length { get; }

        protected abstract byte TypeId { get; }

        private void writeTag(ByteStream queue, int tagNumber, bool classTag, long length)
        {
            int classValue = classTag ? 8 : 0;

            if (length < 0 || length > 0x100000000l) // TODO MATY Check
                throw new ArgumentException("Invalid length: " + length);

            bool extendedTag = tagNumber > 14;

            if (length < 5)
            {
                if (extendedTag)
                {
                    queue.WriteByte((byte) (0xf0 | classValue | length));
                    queue.WriteByte((byte) tagNumber);
                }
                else
                    queue.WriteByte((byte) ((tagNumber << 4) | classValue | length));
            }
            else
            {
                if (extendedTag)
                {
                    queue.WriteByte((byte) (0xf5 | classValue));
                    queue.WriteByte((byte) tagNumber);
                }
                else
                    queue.WriteByte((byte) ((tagNumber << 4) | classValue | 0x5));

                if (length < 254)
                    queue.WriteByte((byte) length);
                else if (length < ushort.MaxValue)
                {
                    queue.WriteByte(254);
                    queue.WriteShort((ushort) length);
                }
                else
                {
                    queue.WriteByte(255);
                    queue.WriteInt((int) length);
                }
            }
        }

        protected long readTag(ByteStream queue)
        {
            byte b = queue.ReadByte();
            int tagNumber = (b & 0xff) >> 4;
            contextSpecific = (b & 8) != 0;
            long length = (b & 7);

            if (tagNumber == 0xf)
                // Extended tag.
                tagNumber = queue.popU1B();

            if (length == 5)
            {
                length = queue.popU1B();
                if (length == 254)
                    length = queue.popU2B();
                else if (length == 255)
                    length = queue.popU4B();
            }

            return length;
        }
    }
}

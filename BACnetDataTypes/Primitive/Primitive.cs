using System;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Exception;

namespace BACnetDataTypes.Primitive
{
    public abstract class Primitive : Encodable
    {
        public static Primitive CreatePrimitive(ByteStream queue)
        {
            // Get the first byte. The 4 high-order bits will tell us what the data type is.
            byte type = queue.PeekFromHere(0);
            type = (byte) ((type & 0xff) >> 4);
            return CreatePrimitive(type, queue);
        }

        public static Primitive CreatePrimitive(ByteStream queue, int contextId, int typeId)
        {
            int tagNumber = peekTagNumber(queue);

            // Check if the tag number matches the context id. If they match, then create the context-specific parameter,
            // otherwise return null.
            if (tagNumber != contextId)
                return null;

            return CreatePrimitive(typeId, queue);
        }

        private static Primitive CreatePrimitive(int typeId, ByteStream queue)
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
        protected bool ContextSpecific;

        public override void write(ByteStream queue)
        {
            writeTag(queue, TypeId, false, Length);
            WriteImpl(queue);
        }

        public override void write(ByteStream queue, int contextId)
        {
            ContextSpecific = true;
            writeTag(queue, contextId, true, Length);
            WriteImpl(queue);
        }

        public void WriteEncodable(ByteStream queue, int contextId)
        {
            writeContextTag(queue, contextId, true);
            write(queue);
            writeContextTag(queue, contextId, false);
        }

        protected abstract void WriteImpl(ByteStream queue);

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
            ContextSpecific = (b & 8) != 0;
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

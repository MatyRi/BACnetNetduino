using System;
using System.IO;
using BACnetNetduino.Exception;
using Microsoft.SPOT;

namespace BACnetNetduino.APDU
{
    internal abstract class APDU
    {
        public static APDU Parse(ByteStream source)
        {
            // Get the first byte. The 4 high-order bits will tell us the type of PDU this is.
            byte type = source.PeekByte();
            type = (byte)((type & 0xff) >> 4);

            if (type == ConfirmedRequest.TYPE_ID)
                return ConfirmedRequest.Parse(source);
            if (type == UnconfirmedRequest.TYPE_ID)
                return UnconfirmedRequest.Parse(source);
            if (type == SimpleACK.TYPE_ID)
                return SimpleACK.Parse(source);
            if (type == ComplexACK.TYPE_ID)
                return ComplexACK.Parse(source);
            if (type == SegmentACK.TYPE_ID)
                return SegmentACK.Parse(source);
            if (type == Error.TYPE_ID)
                return Error.Parse(source);
            if (type == Reject.TYPE_ID)
                return Reject.Parse(source);
            if (type == Abort.TYPE_ID)
                return Abort.Parse(source);
            throw new IllegalPduTypeException("Unknown APDU Type: " + BitConverter.ToString(new[] {type}));
        }

        public abstract byte getPduType();

        //public abstract void write(ByteStream queue);

        protected int getShiftedTypeId(byte typeId)
        {
            return typeId << 4;
        }

        public abstract bool expectsReply();

    }
}

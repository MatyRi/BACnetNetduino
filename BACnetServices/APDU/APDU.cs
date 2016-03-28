using System;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Exception;
using BACnetNetwork;

namespace BACnetServices.APDU
{
    public abstract class APDU : IAPDU
    {
        public static APDU Parse(ByteStream source)
        {
            // Get the first byte. The 4 high-order bits will tell us the type of PDU this is.
            byte type = source.PeekByte();
            type = (byte)((type & 0xff) >> 4);

            if (type == ConfirmedRequest.TYPE_ID)
                return new ConfirmedRequest((ServicesSupported)null, source);
            if (type == UnconfirmedRequest.TYPE_ID)
                return new UnconfirmedRequest((ServicesSupported)null, source);
            if (type == SimpleACK.TYPE_ID)
                return new SimpleACK(source);
            if (type == ComplexACK.TYPE_ID)
                return new ComplexACK(source);
            if (type == SegmentACK.TYPE_ID)
                return new SegmentACK(source);
            if (type == Error.TYPE_ID)
                return new Error(source);
            if (type == Reject.TYPE_ID)
                return new Reject(source);
            if (type == Abort.TYPE_ID)
                return new Abort(source);
            throw new IllegalPduTypeException("Unknown APDU Type: " + BitConverter.ToString(new[] {type}));
        }

        public abstract byte PduType { get; }

        //public abstract void write(ByteStream queue);
        public virtual void write(ByteStream queue)
        {
            throw new NotImplementedException();
        }

        protected byte GetShiftedTypeId(byte typeId) => (byte) (typeId << 4);

        public abstract bool expectsReply { get; protected set; }
    }
}

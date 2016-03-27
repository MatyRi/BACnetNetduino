using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.NotificationParameter
{
    class ChangeOfBitString : NotificationParameters
    {
        public static readonly byte TYPE_ID = 0;

        public ChangeOfBitString(BitString referencedBitstring, StatusFlags statusFlags)
        {
            ReferencedBitstring = referencedBitstring;
            StatusFlags = statusFlags;
        }


        protected override void WriteImpl(ByteStream queue)
        {
            write(queue, ReferencedBitstring, 0);
            write(queue, StatusFlags, 1);
        }

        public ChangeOfBitString(ByteStream queue)
        {
            ReferencedBitstring = (BitString) read(queue, typeof (BitString), 0);
            StatusFlags = (StatusFlags) read(queue, typeof (StatusFlags), 1);
        }


        protected override int TypeId => TYPE_ID;

        public BitString ReferencedBitstring { get; }

        public StatusFlags StatusFlags { get; }
    }
}

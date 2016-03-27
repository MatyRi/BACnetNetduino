using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.NotificationParameter
{
    class UnsignedRange : NotificationParameters
    {
        public static readonly byte TYPE_ID = 11;

        public UnsignedRange(UnsignedInteger exceedingValue, StatusFlags statusFlags, UnsignedInteger exceedingLimit)
        {
            ExceedingValue = exceedingValue;
            StatusFlags = statusFlags;
            ExceedingLimit = exceedingLimit;
        }


        protected override void WriteImpl(ByteStream queue)
        {
            write(queue, ExceedingValue, 0);
            write(queue, StatusFlags, 1);
            write(queue, ExceedingLimit, 2);
        }

        public UnsignedRange(ByteStream queue)
        {
            ExceedingValue = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 0);
            StatusFlags = (StatusFlags) read(queue, typeof (StatusFlags), 1);
            ExceedingLimit = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 2);
        }


        protected override int TypeId => TYPE_ID;

        public UnsignedInteger ExceedingValue { get; }

        public StatusFlags StatusFlags { get; }

        public UnsignedInteger ExceedingLimit { get; }
    }
}

using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.EventParameter
{
    class UnsignedRange : EventParameter
    {
        public static readonly byte TYPE_ID = 11;

        public UnsignedRange(UnsignedInteger timeDelay, UnsignedInteger lowLimit, UnsignedInteger highLimit)
        {
            this.TimeDelay = timeDelay;
            this.LowLimit = lowLimit;
            this.HighLimit = highLimit;
        }


        protected override void writeImpl(ByteStream queue)
        {
            write(queue, TimeDelay, 0);
            write(queue, LowLimit, 1);
            write(queue, HighLimit, 2);
        }

        public UnsignedRange(ByteStream queue)
        {
            TimeDelay = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 0);
            LowLimit = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 1);
            HighLimit = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 2);
        }


        protected override int TypeId => TYPE_ID;

        public UnsignedInteger TimeDelay { get; }

        public UnsignedInteger LowLimit { get; }

        public UnsignedInteger HighLimit { get; }
    }
}

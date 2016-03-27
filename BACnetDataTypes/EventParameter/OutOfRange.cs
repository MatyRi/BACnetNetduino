using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.EventParameter
{
    class OutOfRange : EventParameter
    {
        public static readonly byte TYPE_ID = 5;

        public OutOfRange(UnsignedInteger timeDelay, Real lowLimit, Real highLimit, Real deadband)
        {
            TimeDelay = timeDelay;
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Deadband = deadband;
        }


        protected override void writeImpl(ByteStream queue)
        {
            write(queue, TimeDelay, 0);
            write(queue, LowLimit, 1);
            write(queue, HighLimit, 2);
            write(queue, Deadband, 3);
        }

        public OutOfRange(ByteStream queue)
        {
            TimeDelay = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 0);
            LowLimit = (Real) read(queue, typeof (Real), 1);
            HighLimit = (Real) read(queue, typeof (Real), 2);
            Deadband = (Real) read(queue, typeof (Real), 3);
        }


        protected override int TypeId => TYPE_ID;

        public UnsignedInteger TimeDelay { get; }

        public Real LowLimit { get; }

        public Real HighLimit { get; }

        public Real Deadband { get; }
    }
}

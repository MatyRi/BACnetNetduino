using BACnetDataTypes.Primitive;
using Microsoft.SPOT.Hardware;

namespace BACnetDataTypes.Constructed
{
    internal class AccumulatorRecord : BaseType
    {
        public AccumulatorRecord(DateTime timestamp, UnsignedInteger presentValue, UnsignedInteger accumulatedValue,
            AccumulatorStatus accumulatorStatus)
        {
            Timestamp = timestamp;
            PresentValue = presentValue;
            AccumulatedValue = accumulatedValue;
            AccumulatorStatusValue = accumulatorStatus;
        }


        public override void write(ByteStream queue)
        {
            write(queue, Timestamp, 0);
            write(queue, PresentValue, 1);
            write(queue, AccumulatedValue, 2);
            write(queue, AccumulatorStatusValue, 3);
        }

        public AccumulatorRecord(ByteStream queue)
        {
            Timestamp = (DateTime) read(queue, typeof (DateTime), 0);
            PresentValue = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 1);
            AccumulatedValue = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 2);
            AccumulatorStatusValue = (AccumulatorStatus) read(queue, typeof (AccumulatorStatus), 3);
        }

        public class AccumulatorStatus : Primitive.Enumerated
        {
            public static readonly AccumulatorStatus Normal = new AccumulatorStatus(0);
            public static readonly AccumulatorStatus Starting = new AccumulatorStatus(1);
            public static readonly AccumulatorStatus Recovered = new AccumulatorStatus(2);
            public static readonly AccumulatorStatus Abnormal = new AccumulatorStatus(3);
            public static readonly AccumulatorStatus Failed = new AccumulatorStatus(4);

            public AccumulatorStatus(uint value) : base(value)
            {
            }

            public AccumulatorStatus(ByteStream queue) : base(queue)
            {
            }
        }

        public DateTime Timestamp { get; }

        public UnsignedInteger PresentValue { get; }

        public UnsignedInteger AccumulatedValue { get; }

        public AccumulatorStatus AccumulatorStatusValue { get; }
    }
}

using System;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetDataTypes.EventParameter
{
    class FloatingLimit : EventParameter
    {
        public static readonly byte TYPE_ID = 4;

        public FloatingLimit(UnsignedInteger timeDelay, DeviceObjectPropertyReference setpointReference,
            Real lowDiffLimit,
            Real highDiffLimit, Real deadband)
        {
            TimeDelay = timeDelay;
            SetpointReference = setpointReference;
            LowDiffLimit = lowDiffLimit;
            HighDiffLimit = highDiffLimit;
            Deadband = deadband;
        }

        protected override void writeImpl(ByteStream queue)
        {
            write(queue, TimeDelay, 0);
            write(queue, SetpointReference, 1);
            write(queue, LowDiffLimit, 2);
            write(queue, HighDiffLimit, 3);
            write(queue, Deadband, 4);
        }

        public FloatingLimit(ByteStream queue)
        {
            TimeDelay = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 0);
            SetpointReference = (DeviceObjectPropertyReference) read(queue, typeof (DeviceObjectPropertyReference), 1);
            LowDiffLimit = (Real) read(queue, typeof (Real), 2);
            HighDiffLimit = (Real) read(queue, typeof (Real), 3);
            Deadband = (Real) read(queue, typeof (Real), 4);
        }


        protected override int TypeId => TYPE_ID;

        public UnsignedInteger TimeDelay { get; }

        public DeviceObjectPropertyReference SetpointReference { get; }

        public Real LowDiffLimit { get; }

        public Real HighDiffLimit { get; }

        public Real Deadband { get; }
    }
}

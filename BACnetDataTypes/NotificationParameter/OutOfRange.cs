using System;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetDataTypes.NotificationParameter
{
    class OutOfRange : NotificationParameters
    {
        public static readonly byte TYPE_ID = 5;

        public OutOfRange(Real exceedingValue, StatusFlags statusFlags, Real deadband, Real exceedingLimit)
        {
            this.ExceedingValue = exceedingValue;
            this.StatusFlags = statusFlags;
            this.Deadband = deadband;
            this.ExceedingLimit = exceedingLimit;
        }


        protected override void WriteImpl(ByteStream queue)
        {
            write(queue, ExceedingValue, 0);
            write(queue, StatusFlags, 1);
            write(queue, Deadband, 2);
            write(queue, ExceedingLimit, 3);
        }

        public OutOfRange(ByteStream queue)
        {
            ExceedingValue = (Real) read(queue, typeof (Real), 0);
            StatusFlags = (StatusFlags) read(queue, typeof (StatusFlags), 1);
            Deadband = (Real) read(queue, typeof (Real), 2);
            ExceedingLimit = (Real) read(queue, typeof (Real), 3);
        }


        protected override int TypeId => TYPE_ID;

        public Real ExceedingValue { get; }

        public StatusFlags StatusFlags { get; }

        public Real Deadband { get; }

        public Real ExceedingLimit { get; }
    }
}

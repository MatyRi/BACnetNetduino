using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.NotificationParameter
{
    class FloatingLimit : NotificationParameters
    {
        public static readonly byte TYPE_ID = 4;

        public FloatingLimit(Real referenceValue, StatusFlags statusFlags, Real setpointValue, Real errorLimit)
        {
            ReferenceValue = referenceValue;
            StatusFlags = statusFlags;
            SetpointValue = setpointValue;
            ErrorLimit = errorLimit;
        }


        protected override void WriteImpl(ByteStream queue)
        {
            write(queue, ReferenceValue, 0);
            write(queue, StatusFlags, 1);
            write(queue, SetpointValue, 2);
            write(queue, ErrorLimit, 3);
        }

        public FloatingLimit(ByteStream queue)
        {
            ReferenceValue = (Real) read(queue, typeof (Real), 0);
            StatusFlags = (StatusFlags) read(queue, typeof (StatusFlags), 1);
            SetpointValue = (Real) read(queue, typeof (Real), 2);
            ErrorLimit = (Real) read(queue, typeof (Real), 3);
        }


        protected override int TypeId => TYPE_ID;

        public Real ReferenceValue { get; }

        public StatusFlags StatusFlags { get; }

        public Real SetpointValue { get; }

        public Real ErrorLimit { get; }
    }
}

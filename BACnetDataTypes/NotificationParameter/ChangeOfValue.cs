using System.Collections;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.NotificationParameter
{
    class ChangeOfValue : NotificationParameters
    {
        public static readonly byte TYPE_ID = 2;

        private static readonly IList Classes = new ArrayList { typeof(BitString), typeof(Real) };

        public ChangeOfValue(BitString newValue, StatusFlags statusFlags)
        {
            NewValue = new Choice(0, newValue);
            StatusFlags = statusFlags;
        }

        public ChangeOfValue(Real newValue, StatusFlags statusFlags)
        {
            NewValue = new Choice(1, newValue);
            StatusFlags = statusFlags;
        }

        protected override void WriteImpl(ByteStream queue)
        {
            write(queue, NewValue, 0);
            write(queue, StatusFlags, 1);
        }

        public ChangeOfValue(ByteStream queue)
        {
            NewValue = new Choice(queue, Classes, 0);
            StatusFlags = (StatusFlags) read(queue, typeof (StatusFlags), 1);
        }

        protected override int TypeId => TYPE_ID;

        public Choice NewValue { get; }

        public StatusFlags StatusFlags { get; }
    }
}

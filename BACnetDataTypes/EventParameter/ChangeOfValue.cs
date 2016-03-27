using System;
using System.Collections;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetDataTypes.EventParameter
{
    class ChangeOfValue : EventParameter
    {
        public static readonly byte TYPE_ID = 2;

        private static readonly IList Classes = new ArrayList() {typeof (BitString), typeof (Real)};

        public ChangeOfValue(UnsignedInteger timeDelay, BitString bitmask)
        {
            TimeDelay = timeDelay;
            NewValue = new Choice(0, bitmask);
        }

        public ChangeOfValue(UnsignedInteger timeDelay, Real referencedPropertyIncrement)
        {
            TimeDelay = timeDelay;
            NewValue = new Choice(1, referencedPropertyIncrement);
        }

        public ChangeOfValue(ByteStream queue)
        {
            TimeDelay = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 0);
            NewValue = new Choice(queue, Classes, 1);
        }

        protected override void writeImpl(ByteStream queue)
        {
            write(queue, TimeDelay, 0);
            write(queue, NewValue, 1);
        }

        protected override int TypeId => TYPE_ID;

        public UnsignedInteger TimeDelay { get; }

        public Choice NewValue { get; }
    }
}

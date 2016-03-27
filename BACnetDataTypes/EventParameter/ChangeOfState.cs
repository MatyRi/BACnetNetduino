using System;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetDataTypes.EventParameter
{
    class ChangeOfState : EventParameter
    {
        public static readonly byte TYPE_ID = 1;

        public ChangeOfState(UnsignedInteger timeDelay, SequenceOf listOfValues)
        {
            TimeDelay = timeDelay;
            ListOfValues = listOfValues;
        }

        public ChangeOfState(ByteStream queue)
        {
            TimeDelay = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 0);
            ListOfValues = readSequenceOf(queue, typeof (PropertyStates), 1);
        }

        protected override void writeImpl(ByteStream queue)
        {
            write(queue, TimeDelay, 0);
            write(queue, ListOfValues, 1);
        }

        protected override int TypeId => TYPE_ID;

        public UnsignedInteger TimeDelay { get; }

        public SequenceOf ListOfValues { get; } //PropertyStates
    }
}

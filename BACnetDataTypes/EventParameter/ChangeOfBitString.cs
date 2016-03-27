using System;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.EventParameter
{
    class ChangeOfBitString : EventParameter
    {
        public static readonly byte TYPE_ID = 0;

        public ChangeOfBitString(UnsignedInteger timeDelay, BitString bitMask, SequenceOf listOfBitstringValues)
        {
            TimeDelay = timeDelay;
            BitMask = bitMask;
            ListOfBitstringValues = listOfBitstringValues;
        }

        public ChangeOfBitString(ByteStream queue)
        {
            TimeDelay = (UnsignedInteger) read(queue, typeof (UnsignedInteger), 0);
            BitMask = (BitString) read(queue, typeof (BitString), 1);
            ListOfBitstringValues = readSequenceOf(queue, typeof (BitString), 2);
        }


        protected override void writeImpl(ByteStream queue)
        {
            write(queue, TimeDelay, 0);
            write(queue, BitMask, 1);
            write(queue, ListOfBitstringValues, 2);
        }

        protected override int TypeId => TYPE_ID;

        public UnsignedInteger TimeDelay { get; }

        public BitString BitMask { get; }

        public SequenceOf ListOfBitstringValues { get; }
    }
}

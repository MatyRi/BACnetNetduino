using System;
using BACnetDataTypes.Constructed;
namespace BACnetDataTypes.NotificationParameter
{
    class ComplexEventType : NotificationParameters
    {
        public static readonly byte TYPE_ID = 6;

        public ComplexEventType(SequenceOf values)
        {
            Values = values;
        }


        protected override void WriteImpl(ByteStream queue)
        {
            write(queue, Values);
        }

        public ComplexEventType(ByteStream queue)
        {
            Values = readSequenceOf(queue, typeof (PropertyValue));
        }


        protected override int TypeId => TYPE_ID;

        public SequenceOf Values { get; } // PropertyValue
    }
}

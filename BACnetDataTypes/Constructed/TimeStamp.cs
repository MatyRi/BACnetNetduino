using System.Collections;
using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class TimeStamp : BaseType
    {
        private readonly Choice _choice;

        private static readonly IList classes = new ArrayList()
        {
            typeof (Time),
            typeof (UnsignedInteger),
            typeof (DateTime)
        };

        public TimeStamp(Time time)
        {
            _choice = new Choice(0, time);
        }

        public TimeStamp(UnsignedInteger sequenceNumber)
        {
            _choice = new Choice(1, sequenceNumber);
        }

        public TimeStamp(DateTime dateTime)
        {
            _choice = new Choice(2, dateTime);
        }

        /*public override void write(ByteStream queue)
    {
        write(queue, choice);
    }*/

        public TimeStamp(ByteStream queue)
        {
            _choice = new Choice(queue, classes);
        }

        public bool IsTime => _choice.ContextId == 0;

        public Time Time => (Time)_choice.Data;

        public bool IsSequenceNumber => _choice.ContextId == 1;

        public UnsignedInteger SequenceNumber => (UnsignedInteger)_choice.Data;

        public bool IsDateTime => _choice.ContextId == 2;

        public DateTime DateTime => (DateTime)_choice.Data;
    }
}

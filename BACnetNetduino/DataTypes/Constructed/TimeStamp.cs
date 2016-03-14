using System;
using System.Collections;
using BACnetNetduino.DataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Constructed
{
    class TimeStamp : BaseType
    {
        private readonly Choice choice;

        private static IList classes = new ArrayList()
        {
            typeof (Time),
            typeof (UnsignedInteger),
            typeof (DateTime)
        };

        public TimeStamp(Time time)
        {
            choice = new Choice(0, time);
        }

        public TimeStamp(UnsignedInteger sequenceNumber)
        {
            choice = new Choice(1, sequenceNumber);
        }

        public TimeStamp(DateTime dateTime)
        {
            choice = new Choice(2, dateTime);
        }

        /*public override void write(ByteStream queue)
    {
        write(queue, choice);
    }*/

        public TimeStamp(ByteStream queue)
        {
            choice = new Choice(queue, classes);
        }

        public bool isTime()
        {
            return choice.ContextId == 0;
        }

        public Time getTime()
        {
            return (Time) choice.Datum;
        }

        public bool isSequenceNumber()
        {
            return choice.ContextId == 1;
        }

        public UnsignedInteger getSequenceNumber()
        {
            return (UnsignedInteger) choice.Datum;
        }

        public bool isDateTime()
        {
            return choice.ContextId == 2;
        }

        public DateTime getDateTime()
        {
            return (DateTime) choice.Datum;
        }
    }
}

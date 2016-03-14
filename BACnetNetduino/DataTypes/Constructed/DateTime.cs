using System;
using BACnetNetduino.DataTypes.Primitive;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Constructed
{
    class DateTime : BaseType
    {
        private readonly System.DateTime datetime;

        private readonly Date date;
        private readonly Time time;

        public DateTime() : this(System.DateTime.Now) { }

        public DateTime(Date date, Time time)
        {
            // TODO make a DateTime ...
            this.date = date;
            this.time = time;
        }

        public DateTime(long millis)
        {
            datetime = new System.DateTime(millis);
            date = new Date(datetime);
            time = new Time(datetime);
        }

        public DateTime(System.DateTime dt)
        {
            datetime = dt;
            date = new Date(datetime);
            time = new Time(datetime);
        }

        /*public override void write(ByteStream queue)
        {
            date.write(queue);
            time.write(queue);
        }*/

        public DateTime(ByteStream queue)
        {
            date = (Date) read(queue, typeof(Date));
            time = (Time) read(queue, typeof(Time));
        }

    public Date getDate()
    {
        return date;
    }

    public Time getTime()
    {
        return time;
    }

    public long getTimeMillis()
    {
        /*GregorianCalendar gc = new GregorianCalendar(date.getCenturyYear(), date.getMonth().getId() - 1, date.getDay(),
                time.getHour(), time.getMinute(), time.getSecond());*/

        //gc.set(Calendar.MILLISECOND, time.getHundredth() * 10);
        return datetime.Millisecond;
    }
}
}

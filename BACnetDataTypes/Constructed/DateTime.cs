using BACnetDataTypes.Primitive;

namespace BACnetDataTypes.Constructed
{
    public class DateTime : BaseType
    {
        private readonly System.DateTime datetime;


        public Date Date { get; }
        public Time Time { get; }


        public DateTime() : this(System.DateTime.Now) { }

        public DateTime(Date date, Time time)
        {
            // TODO make a DateTime ...
            this.Date = date;
            this.Time = time;
        }

        public DateTime(long millis)
        {
            datetime = new System.DateTime(millis);
            Date = new Date(datetime);
            Time = new Time(datetime);
        }

        public DateTime(System.DateTime dt)
        {
            datetime = dt;
            Date = new Date(datetime);
            Time = new Time(datetime);
        }

        /*public override void write(ByteStream queue)
        {
            date.write(queue);
            time.write(queue);
        }*/

        public DateTime(ByteStream queue)
        {
            Date = (Date) read(queue, typeof(Date));
            Time = (Time) read(queue, typeof(Time));
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

using System;

namespace BACnetDataTypes.Primitive
{
    /**
 * ASHRAE Standard 135-2012 Clause 20.2.12 Encoding of a Date Value p.631<br>
 * The encoding of a date value shall be primitive, with four contents octets<br>
 * Unless otherwise specified (e.g. UTC date), a date value generated by a device<br>
 * shall be a local date. Date values shall be encoded in the contents octets as<br>
 * four binary integers. <br>
 * The first contents octet shall represent the year minus 1900;<br>
 * the second octet shall represent the month, with January = 1; <br>
 * the third octet shall represent the day of the month; <br>
 * and the fourth octet shall represent the day of the week, with Monday = 1.<br>
 * A value of X'FF' = D'255' in any of the four octets shall indicate that the<br>
 * corresponding value is unspecified and shall be considered a wildcard when<br>
 * matching dates. If all four octets = X'FF', the corresponding date may be<br>
 * interpreted as "any" or "don't care."<br> 
 * <br>
 * Neither an unspecified date nor a date pattern shall be used in date values <br>
 * that convey actual dates, such as in a TimeSynchronization-Request.<br>
 * <br>
 * The processing of a day of week received in a service that is in the range 1 to 7<br>
 * and is inconsistent with the values in the other octets shall be a local matter.<br>
 * <br>
 * A number of special values for the month and day octets have been defined.<br>
 * The following special values shall not be used when conveying an actual date<br>
 * value, such as the Local_Date property of the Device object or in a<br>
 * TimeSynchronization-Request.<br>
 * A value of 13 in the second octet shall indicate odd months.<br>
 * A value of 14 in the second octet shall indicate even months.<br>
 * A value of 32 in the third octet shall indicate the last day of the month.<br>
 * A value of 33 in the third octet shall indicate odd days of the month.<br>
 * A value of 34 in the third octet shall indicate even days of the month.<br>
 * <br>
 * Example: Application-tagged specific date value<br>
 * 		 ASN.1 = Date<br>
 *		 Value = January 24, 1991 (Day of week = Thursday)<br>
 *		 Application Tag = Date (Tag Number = 10)<br>
 *		 Encoded Tag = X'A4'<br>
 *		 Encoded Data = X'5B011804'<br>
 *<br>
 * Example: Application-tagged date pattern value<br>
 * 		 ASN.1 = Date<br>
 *		 Value = year = 1991, month is unspecified, day = 24, day of week is unspecified<br>
 *		 Application Tag = Date (Tag Number = 10)<br>
 * 		 Encoded Tag = X'A4'<br>
 *		 Encoded Data = X'5BFF18FF'<br>
 */

    public class Date : Primitive
    {
        public static readonly byte TYPE_ID = 10;

        public Date(int year, int month, int day, DayOfWeek dayOfWeek)
        {
            if (year > 1900)
                year -= 1900;
            else if (year == -1)
                year = 255;
            if (day == -1)
                day = 255;

            Year = year;
            Month = month;
            Day = day;
            DayOfWeek = dayOfWeek;
        }

        public Date() : this(DateTime.Now)
        {
        }

        public Date(DateTime now)
        {
            Year = now.Year;
            Month = now.Month;
            Day = now.Day;
            DayOfWeek = now.DayOfWeek;


            /*this.year = now.get(Calendar.YEAR) - 1900;
        this.month = Month.valueOf((byte)(now.get(Calendar.MONTH) + 1));
        this.day = now.get(Calendar.DATE);
        this.dayOfWeek = DayOfWeek.valueOf((byte)(((now.get(Calendar.DAY_OF_WEEK) + 5) % 7) + 1));*/
        }

        public bool IsYearUnspecified => Year == 255;

        public int Year { get; }

        public int CenturyYear => Year + 1900;

        public int Month { get; }

        public bool IsLastDayOfMonth => Day == 32;

        public bool IsDayUnspecified => Day == 255;

        public int Day { get; }

        public DayOfWeek DayOfWeek { get; }

        //
        // Reading and writing
        //
        public Date(ByteStream queue)
        {
            readTag(queue);
            Year = queue.popU1B();
            Month = queue.popU1B();
            Day = queue.popU1B();
            // TODO dayOfWeek = DayOfWeek.valueOf(queue.pop());
            // DayOfWeek = DayOfWeek.Monday;
            DayOfWeek = (DayOfWeek)queue.ReadByte(); // TODO test
        }

        protected override void WriteImpl(ByteStream queue)
        {
            queue.WriteInt(Year);
            queue.WriteByte((byte) Month);
            queue.WriteByte((byte) Day);
            queue.WriteByte((byte) DayOfWeek); // TODO test
        }

        protected override long Length { get; } = 4;

        protected override byte TypeId => TYPE_ID;

        public override string ToString() => DayOfWeek + " " + Month + " " + Day + ", " + Year;
    }
}

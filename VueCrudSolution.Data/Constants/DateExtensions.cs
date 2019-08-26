using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace VueCrudSolution.Data.Constants
{
    public static class DateExtensions
    {
        public static int CalculateAge(this DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;
            if (theDateTime.AddYears(age) > DateTime.Today)
                age--;
            return age;
        }
        public static DateTime GetDateUtcNow(this DateTime now)
        {
            return DateTime.UtcNow;
        }

        public static DateTime FindNextDate(this DateTime startDate, int interval)
        {
            DateTime today = DateTime.Today;
            do
            {
                startDate = startDate.AddMonths(interval);
            } while (startDate <= today);
            return startDate;
        }

        public static DateTime ToInvariantDateTime(this String value, String format)
        {
            DateTimeFormatInfo dtfi = DateTimeFormatInfo.InvariantInfo;
            var result = DateTime.TryParseExact(value, format, dtfi, DateTimeStyles.None, out DateTime newValue);
            return newValue;
        }

        public static string ToDateString(this DateTime dt, String format)
        {
            return dt.ToString(format, DateTimeFormatInfo.InvariantInfo);
        }
    }
}

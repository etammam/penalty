using System;
using System.Collections.Generic;
using System.Linq;

namespace Penalty.Infrastructure.Implementations.Penalties
{
    public static class PenaltyExtension
    {
        private static DayOfWeek ConvertToDayOfWeek(this string holiday)
        {
            return holiday switch
            {
                "Saturday" => DayOfWeek.Saturday,
                "Sunday" => DayOfWeek.Sunday,
                "Monday" => DayOfWeek.Monday,
                "Tuesday" => DayOfWeek.Tuesday,
                "Wednesday" => DayOfWeek.Wednesday,
                "Thursday" => DayOfWeek.Thursday,
                "Friday" => DayOfWeek.Friday,
                _ => throw new Exception("this is not a valid day")
            };
        }
        private static List<DayOfWeek> GetHolidays(this string[] holidays)
        {
            return holidays.Select(holiday => holiday.ConvertToDayOfWeek()).ToList();
        }
        public static int GetBusinessDays(
            this DateTime startDate,
            DateTime endDate,
            string[] holidays)
        {
            if (startDate > endDate)
                throw new NotSupportedException("end date must be grater than start date");

            var businessDays = 0;
            var totalDays = endDate.Subtract(startDate).Days+1;
            for (int i = 0; i < totalDays; i++)
            {
                var current = startDate.AddDays(i);
                if (!holidays.GetHolidays().Contains(current.DayOfWeek))
                {
                    businessDays++;
                }
            }
            return businessDays;
        }
    }
}

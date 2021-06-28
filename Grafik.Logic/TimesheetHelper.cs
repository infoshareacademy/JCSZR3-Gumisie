
using System;

namespace Grafik_Logic
{
    public class TimesheetHelper
    {
        public DateTime GetDate() => DateTime.Now;
        public DayOfWeek GetDayOfTheWeek(DateTime date) => date.DayOfWeek;
        static TimeSpan CalculateHoursForShift(DateTime start, DateTime end) => end - start;
        static int CalculateHoursForShift(string start, string end)
        {
            DateTime startWorkingDate = DateTime.Parse(start);
            DateTime endWorkingDate = DateTime.Parse(end);
            TimeSpan shiftDifference = endWorkingDate - startWorkingDate;

            return shiftDifference.Hours;
        }

    }
}

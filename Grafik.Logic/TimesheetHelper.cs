
using System;

namespace Grafik_Logic
{
    public class TimesheetHelper
    {
        public DateTime GetDate() => DateTime.Now;
        public DayOfWeek GetDayOfTheWeek(DateTime date) => date.DayOfWeek;
        static int CalculateHoursForShift(DateTime start, DateTime end) {

            TimeSpan shiftDifference = end - start;

            return shiftDifference.Hours;
        }
        static int CalculateHoursForShift(string start, string end)
        {
            DateTime startWorkingDate = DateTime.Parse(start);
            DateTime endWorkingDate = DateTime.Parse(end);
            TimeSpan shiftDifference = endWorkingDate - startWorkingDate;

            return shiftDifference.Hours;
        }

    }
}

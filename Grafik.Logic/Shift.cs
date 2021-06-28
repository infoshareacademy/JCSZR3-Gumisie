using System;

namespace Grafik_Logic
{
    public class Shift
    {
        public string EmployeeEmail { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public DateTime DayOfTheWeek { get; set; } // store which day of the week in case increased day rate for saturday, sunday
        public int WorkingHours { get; set; } // store difference between StartTime
        public DayType WorkingDateType { get; set; }

        public Shift() { }
        public Shift(string employeeEmail, DateTime start, DateTime end, DateTime dayOfTheWeek, DayType type) {
            EmployeeEmail = employeeEmail;
            StartTime = start;
            FinishTime = end;
            DayOfTheWeek = dayOfTheWeek;
            WorkingDateType = type;
        }

    }
}

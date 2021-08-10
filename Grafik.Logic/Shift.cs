using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Grafik_Logic
{
    public class Shift
    {
        public string EmployeeEmail { get; set; }

        [DisplayName("Start time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DisplayName("Finish time")]
        [DataType(DataType.Time)]
        public DateTime FinishTime { get; set; }

        [DisplayName("Total time")]
        [DataType(DataType.Date)]
        public DateTime TotalTime { get; set; }

        [DisplayName("Shift details")]
        [DataType(DataType.MultilineText)]
        public string ShiftDetails { get; set; }

        public DateTime DayOfTheWeek { get; set; } // store which day of the week in case increased day rate for saturday, sunday
        public int WorkingHours { get; set; } // store difference between StartTime

        //public DayType WorkingDateType { get; set; }

        public Shift() { }
        //public Shift(string employeeEmail, DateTime start, DateTime end, DateTime dayOfTheWeek) {

        //public string DayType { get; set; }

        //public Shift() { }
        public Shift(string employeeEmail, DateTime start, DateTime end, DateTime dayOfTheWeek, string type)
        {

            EmployeeEmail = employeeEmail;
            StartTime = start;
            FinishTime = end;
            DayOfTheWeek = dayOfTheWeek;
        }

    }
}
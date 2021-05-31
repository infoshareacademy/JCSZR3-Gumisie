using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafik_Logic
{
    public class Timesheet
    {
        private DateTime _getCurrentDateTime = DateTime.Now;
        
        public int ID { get; set; }
        public Employee Employee { get; set; }
        public DateTime WorkingDate { get; set; } // working date
        private DateTime Day { get; set; } // store days of the week in case working in weekdays
        public int WorkingStartingHour { get; set; }
        public int WorkingEndingHour { get; set; }
        public DateTime Timestamp { get => _getCurrentDateTime; private set => _getCurrentDateTime = value; } // date of creation/modification of record

        public string ShiftType { get; set; } //TO DO ENUM
        private int DayWorkingHours { get; set; } // property to store amount hours Employee working in day

        public Timesheet() {  }
        public Timesheet(int id, Employee employee, DateTime workingDate, int startingHourShift, int endingHoursShift)
        {
            ID = id;
            Employee = employee;
            WorkingDate = workingDate;
            WorkingStartingHour = startingHourShift;
            WorkingEndingHour = endingHoursShift;
        }
        public void getDate() {
            DateTime dateTime = DateTime.Now;
        }
        public int getDayOfTheWeek(DateTime date) {
            return default;
        }
        public int calcaulteHoursForShift(int start, int end) => DayWorkingHours = end - start;
    }
}

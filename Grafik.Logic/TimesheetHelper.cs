using System;
using System.Collections.Generic;

namespace Grafik_Logic
{
    public class Shift
    {
        public string Employeemail { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Finishtime { get; set; }
    }

    public class Timesheet
    {
        public DateTime Timesheetdate { get; set; }
        public List<Shift> Shifts { get; set; }
    }
}

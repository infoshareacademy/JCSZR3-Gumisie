using System;
using System.Collections.Generic;

namespace Grafik_Logic
{
    public class Timesheet
    {
        public DateTime Timesheetdate { get; set; }
        public List<Shift> Shifts { get; set; }
    }
}

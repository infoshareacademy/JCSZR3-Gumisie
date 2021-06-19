using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Grafik_Logic
{
    public class Shift
    {
        [JsonProperty("employeemail")]
        public string Employeemail { get; set; }

        [JsonProperty("starttime")]
        public DateTime Starttime { get; set; }

        [JsonProperty("finishtime")]
        public DateTime Finishtime { get; set; }
    }

    public class Timesheet
    {
        public Timesheet(DateTime timesheetDate, string test, string employeeEmail, DateTime startTime, DateTime finishTime)
        {
            Timesheetdate = timesheetDate;
            Test = test;
            //Shifts.Add(new Shift(){Employeemail = employeeEmail,Starttime = startTime,Finishtime = finishTime});
        }
        [JsonProperty("test")]
        public string Test { get; set; }

        [JsonProperty("timesheetdate")]
        public DateTime Timesheetdate { get; private set; }

        [JsonProperty("shifts")]
        public static List<Shift> Shifts { get; set; }
    }
    public class Root
    {
        [JsonProperty("timesheet")]
        public Timesheet Timesheet { get; set; }
    }
}

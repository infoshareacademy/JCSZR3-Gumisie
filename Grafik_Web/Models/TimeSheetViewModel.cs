using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grafik_Web.Models
{
    public class TimeSheetViewModel
    {
        public List<Grafik_Logic.Timesheet> Timesheets;
        public Grafik_Logic.Timesheet Timesheet;

        public List<Grafik_Logic.Employee> Employees;
        public Grafik_Logic.Employee Employee;
    }
}

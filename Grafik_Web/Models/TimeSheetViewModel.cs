using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grafik_Logic;

namespace Grafik_Web.Models
{
    public class TimeSheetViewModel
    {
        public List<Timesheet> Timesheets;
        public Timesheet Timesheet;

        public List<Employee> Employees;
        public Employee Employee;
    }
}

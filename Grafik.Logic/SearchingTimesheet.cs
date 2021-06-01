using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafik_Logic
{
    public class SearchingTimesheet
    {
        public List<Employee> employees = new List<Employee>();
        public List<Timesheet> timesheets = new List<Timesheet>();



        private Timesheet FindTimesheet(Employee selectedEmployee)
        {
            if (selectedEmployee == null)
            {
                return null;
            }

            Timesheet userTimesheet = null;

            foreach (Timesheet timesheet in timesheets)
            {
                if (timesheet.Employee.FirstName == selectedEmployee.FirstName && timesheet.Employee.LastName == selectedEmployee.LastName)
                {
                    userTimesheet = timesheet;
                }
            }
            return userTimesheet;
        }

        public Timesheet SearchEmployeeTimeshift(string firstName, string lastName)
        {
            Employee selectedEmployee = null;

            foreach (Employee employee in employees)
            {
                if (employee.FirstName == firstName && employee.LastName == lastName)
                {
                    selectedEmployee = employee;
                }
            }

           return FindTimesheet(selectedEmployee);
        }

        public Timesheet SearchEmployeeTimeshift(string emailAdress)
        {
            Employee selectedEmployee = null;

            foreach (Employee employee in employees)
            {
                if (employee.EmailAddress == emailAdress)
                {
                    selectedEmployee = employee;
                }
            }

            return FindTimesheet(selectedEmployee);
        }
    
        public Timesheet SearchEmployeeTimeshift(int userId)
        {
            Employee selectedEmployee = null;

            foreach (Employee employee in employees)
            {
                if (employee.UserId== userId)
                {
                    selectedEmployee = employee;
                }
            }

            return FindTimesheet(selectedEmployee);
        }

    }
}

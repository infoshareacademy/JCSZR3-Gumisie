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



        //public virtual string SearchEmployeeTimeshift(string firstName, string lastName, string emailAdress, int userId)
        //{
        //    return null;
        //}

        public string SearchEmployeeTimeshift(string firstName, string lastName)
        {
            foreach (Employee employee in employees)
            {
                if (employee.FirstName == firstName || employee.LastName == lastName)
                {
                    foreach (Timesheet timesheet in timesheets)
                    {
                        return $"{timesheet.ID} {timesheet.Employee.FirstName} {timesheet.Employee.LastName}/n {timesheet.WorkingDate} {timesheet.WorkingStartingHour} {timesheet.WorkingEndingHour}";
                    }
                }
            }
        return $"This person dosen't exist in our database.";
        }

        public string SearchEmployeeTimeshift(string emailAdress)
        {
            foreach (Employee employee in employees)
            {
                if (employee.EmailAddress == emailAdress)
                {
                    foreach (Timesheet timesheet in timesheets)
                    {
                        return $"{timesheet.ID} {timesheet.Employee.FirstName} {timesheet.Employee.LastName}/n {timesheet.WorkingDate} {timesheet.WorkingStartingHour} {timesheet.WorkingEndingHour}";
                    }
                }
            }
            return $"This e-mail dosen't exist in our database.";
        }
        public string SearchEmployeeTimeshift(int userId)
        {
            foreach (Employee employee in employees)
            {
                if (employee.UserId == userId)
                {
                    foreach (Timesheet timesheet in timesheets)
                    {
                        return $"{timesheet.ID} {timesheet.Employee.FirstName} {timesheet.Employee.LastName}/n {timesheet.WorkingDate} {timesheet.WorkingStartingHour} {timesheet.WorkingEndingHour}";
                    }
                }
            }
            return $"This user ID dosen't exist in our database.";
        }

    }
}

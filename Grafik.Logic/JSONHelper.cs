using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Grafik_Logic
{
    public static class JsonHelper
    {
        public static List<Employee> _employees;
        private const string Path = @"JSON Files\Employees.json";
        private static List<Timesheet> _timesheets;
        private const string Path2 = @"JSON Files\Timesheet.json";

        public static void LoadEmployeesJson()
        {
            var json = File.ReadAllText(Path);
            _employees = JsonConvert.DeserializeObject<List<Employee>>(json);
        }

        public static void AddNewEmployeeToEmployeesList(Employee employee)
        {
            _employees.Add(employee);
            Console.WriteLine("User added successfully to the database. Press Esc to go back or any other key to add a new user.");
        }
        public static void SaveEmployeesListToJson()
        {
            var newJson = JsonConvert.SerializeObject(_employees);
            File.WriteAllText(Path, newJson);
        }
        public static void ListAllUsers()
        {
            foreach (var employee in _employees)
            {
                Console.WriteLine($"{employee.Email} {employee.Name.First} {employee.Name.Last} {employee.Gender}");
            }
        }
        public static bool CheckIfUserExistsInDatabase(string email) => _employees.Any(e => e.Email == email);

        public static Employee SearchForEmployeeByPhoneNumber(string phoneNumber) => _employees.FirstOrDefault(e => e.Phone == phoneNumber);

        public static void LoadTimesheetsJson()
        {
            var json = File.ReadAllText(Path2);
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            _timesheets = JsonConvert.DeserializeObject<List<Timesheet>>(json,settings);
        }
        public static void GetDailyShifts()
        {
            var timesheetDay = new DateTime(2021, 6, 18);
            var timesheetForChosenDay =  _timesheets.FindAll(s => s.Timesheetdate.Equals(timesheetDay))[0];

            foreach (var shift in timesheetForChosenDay.Shifts)
            {
                var employeeName = _employees.Find(e => e.Email == shift.Employeemail);
                if (employeeName != null)
                {
                    Console.WriteLine($"Employee:{employeeName.Name.First} {employeeName.Name.Last} Start time: {shift.Starttime:HH:mm:ss} Finish time:{shift.Finishtime:HH:mm:ss}");  
                }
            }
        }
    }
}
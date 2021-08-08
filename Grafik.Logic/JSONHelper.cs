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
        public static List<Employee> Employees;
        private const string Path = @"JSON Files\Employees.json";
        private static List<Timesheet> _timesheets;
        private const string Path2 = @"JSON Files\Timesheet.json";
        public static List<AbsenceRequestClass> AbRequest;
        private const string Path3 = @"C:\Users\Carmiu\Desktop\PROJEKT\JCSZR3-Gumisie\Grafik.Logic\JSON Files\AbsenceRequests.json";

        public static void LoadAbsenceRequestsJson()
        {
            var json = File.ReadAllText(Path3);
            AbRequest = JsonConvert.DeserializeObject<List<AbsenceRequestClass>>(json);
        }

        public static void LoadEmployeesJson()
        {
            var json = File.ReadAllText(Path);
            Employees = JsonConvert.DeserializeObject<List<Employee>>(json);
        }

        public static void AddNewEmployeeToEmployeesList(Employee employee)
        {
            Employees.Add(employee);
            Console.WriteLine("User added successfully to the database. Press Esc to go back or any other key to add a new user.");
        }
        public static void SaveEmployeesListToJson()
        {
            var newJson = JsonConvert.SerializeObject(Employees);
            File.WriteAllText(Path, newJson);
        }
        public static void ListAllUsers()
        {
            foreach (var employee in Employees)
            {
                Console.WriteLine($"{employee.Email} {employee.Name.First} {employee.Name.Last} {employee.Gender}");
            }
        }
        public static bool CheckIfUserExistsInDatabase(string email) => Employees.Any(e => e.Email == email);
        public static Employee SearchForEmployeeByPhoneNumber(string phoneNumber) => Employees.FirstOrDefault(e => e.Phone == phoneNumber);
        public static void SearchForEmployeeByEmail(string email)
        {
            foreach (var employee in JsonHelper.Employees.Where(x => x.Email != null && x.Email.Contains(email)))
            {
                Console.WriteLine($"{employee.Email} {employee.Phone} {employee.Gender} {employee.Nat}");
            }
        }
        public static void SearchForEmployeeByNationality(string nationality)
        {
            if (string.IsNullOrWhiteSpace(nationality)) return;
            foreach (var employee in JsonHelper.Employees.Where(x => x.Nat != null && x.Nat.Equals(nationality))) 
            {
                Console.WriteLine($" {employee.Email} {employee.Phone} {employee.Gender} {employee.Nat}");
            }
            Console.ReadLine();
        }

        public static void LoadTimesheetsJson()
        {
            var json = File.ReadAllText(Path2);
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            _timesheets = JsonConvert.DeserializeObject<List<Timesheet>>(json, settings);
        }
        //public static string ValidateEmployeesData(string dataName)
        //{
        //    string input;
        //    var i = 0;
        //    do
        //    {
        //        i++;
        //        if (i > 1)
        //        {
        //        }
        //        input = Console.ReadLine();
        //    } while (string.IsNullOrWhiteSpace(input));
        //    return input;
        //}
        public static void GetDailyShifts()
        {
            var timesheetDay = new DateTime(2021, 6, 18);
            var timesheetForChosenDay = _timesheets.FindAll(s => s.Timesheetdate.Equals(timesheetDay))[0];

            foreach (var shift in timesheetForChosenDay.Shifts)
            {
                var employeeName = Employees.Find(e => e.Email == shift.EmployeeEmail);
                if (employeeName != null)
                {
                    Console.WriteLine($"Employee:{employeeName.Name.First} {employeeName.Name.Last} Start time: {shift.StartTime:HH:mm:ss} Finish time:{shift.FinishTime:HH:mm:ss}");
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Grafik_Logic
{
    public static class JsonHelper
    {
        public static List<Employee> _employees;
        private const string Path = @"JSON Files\Employees.json";

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
        public static bool CheckIfUserExistsInDatabase(string email)=> _employees.Any(e => e.Email == email);
    }
}
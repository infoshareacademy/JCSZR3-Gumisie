using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Grafik_Logic
{
    public static class JsonHelper
    {
        public static List<Employee> Employees;
        private const string Path = @"JSON Files\Employees.json";

        public static void LoadEmployeesJson()
        {
            var json = File.ReadAllText(Path);
            Employees = JsonConvert.DeserializeObject<List<Employee>>(json);
        }

        public static void SaveEmployeeToJson(Employee employee)
        {
            Employees.Add(employee);
            var newJson = JsonConvert.SerializeObject(Employees);
            File.WriteAllText(Path, newJson);
            Console.WriteLine("User added successfully to the database.");
        }
        public static void ListAllUsers()
        {
            foreach (var employee in Employees)
            {
                Console.WriteLine(employee.Email);
            }
        }
        public static bool CheckIfUserExistsInDatabase(string email) => Employees.Any(e => e.Email == email);

    }
}

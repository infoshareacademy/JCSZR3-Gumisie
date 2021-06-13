using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Grafik_Logic
{
    public static class JSONHelper
    {
        public static List<Employee> Employees;
        private const string path = @"JSON Files\Employees.json";

        public static void LoadEmployeesJson()
        {
            var json = File.ReadAllText(path);
            Employees = JsonConvert.DeserializeObject<List<Employee>>(json);
        }

        public static void SaveEmployeeToJson(Employee employee)
        {
            Employees.Add(employee);
            var newJson = JsonConvert.SerializeObject(Employees);
            File.WriteAllText(path, newJson);
            Console.WriteLine("User added successfully to the database.");
        }
        public static bool CheckIfUserExistsInDatabase(string email)=> Employees.Any(e => e.Email == email);
    }
}

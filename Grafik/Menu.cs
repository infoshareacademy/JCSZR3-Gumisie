using System;
using System.Collections.Generic;
using System.Threading.Channels;
using Grafik_Logic;
using System.Linq;

namespace Grafik_Console
{
    public abstract class Menu
    {
        public static void ListMenu(Dictionary<int, string> menuToList)
        {
            foreach (var (menuNumber, menuOption) in menuToList)
            {
                Console.WriteLine($"{menuNumber}.{menuOption}");
            }
        }
        public abstract Dictionary<int, string> MenuOptions { get; }
        public abstract Menu CheckMenuChoice(int userChoice);
    }
    public class MainMenu : Menu
    {
        public override Dictionary<int, string> MenuOptions { get; } = new()
        {
            { 1, "Check shifts" },   //ALL - depending on login 
            { 2, "Submit a new shift request" }, //ALL - depending on login 
            { 3, "Submit a absence request" },  //ALL - depending on login
            { 4, "Find Employee By Email" }, //Previously: "Check daily shifts" / CheckDailyShiftsSubmenu /ALL - whole team's shifts 
            { 5, "Find Employees By Nationality" }, //PREVIOUSLY: Modify employee's shift /ModifyEmployeesShiftSubmenu /Manager's only
            { 6, "Add a new user" }, //Manager's only
        };

        public override Menu CheckMenuChoice(int userChoice) =>
            userChoice switch
            {
                1 => new CheckShiftsSubmenu(),
                2 => new SubmitNewShiftRequestSubmenu(),
                3 => new SubmitNewAbsenceRequestSubmenu(),
                4 => new FindEmployeeByEmailSubmenu(),
                5 => new FindEmployeeByNationalitySubmenu(),
                6 => new AddNewUserSubmenu(),
                _ => null
            };
    }
    public class CheckShiftsSubmenu : Menu
    {
        public CheckShiftsSubmenu()
        {
            do
            {
                Banner.DrawTopBanner(true, "Check Shifts");
                Console.WriteLine("Please provide a date");
                var dateChoice = Console.ReadLine();
                var output = ShiftChecker.CheckShift(dateChoice);
                Console.WriteLine(output);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        public override Dictionary<int, string> MenuOptions { get; } = new();
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
    }

    public class SubmitNewShiftRequestSubmenu : Menu
    {
        public SubmitNewShiftRequestSubmenu()
        {
            Banner.DrawTopBanner(true, "Submit New Shift Request");
            //Console.WriteLine("Menu 2");
            JsonHelper.ListAllUsers();
            Console.ReadLine();
        }

        public override Dictionary<int, string> MenuOptions { get; } = new();
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
    }

    public class SubmitNewAbsenceRequestSubmenu : Menu
    {
        public SubmitNewAbsenceRequestSubmenu()
        {
            do
            {
                Banner.DrawTopBanner(true, "Submit New Absence Request");
                //Console.WriteLine("Menu 3");
                Console.WriteLine("Phone number:");
                var employeePhoneNumber = Console.ReadLine();
                var foundEmployee = JsonHelper.SearchForEmployeeByPhoneNumber(employeePhoneNumber);
                if (foundEmployee != null)
                {
                    Console.WriteLine($"First name: {foundEmployee.Name.First}");
                    Console.WriteLine($"Last name: {foundEmployee.Name.Last}");
                    Console.WriteLine($"Phone: {foundEmployee.Phone}");
                    Console.WriteLine("Press Escape to go back or any other key to find another employee.");
                }
                else
                {
                    Console.WriteLine("There is no employee with the provided phone number. Press Escape to go back or any other key to retry.");
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        public override Dictionary<int, string> MenuOptions { get; } = new();
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
    }

    public class FindEmployeeByEmailSubmenu : Menu
    {
        public FindEmployeeByEmailSubmenu()
        {
            Console.WriteLine("Search by Email");
            Console.WriteLine("Enter email address:");
            string EmployeeEmail = (Console.ReadLine());
            if (EmployeeEmail != null && !(String.IsNullOrWhiteSpace(EmployeeEmail)))
            {
                foreach (var employee in JsonHelper._employees.Where(x => x.Email != null && x.Email.Contains(EmployeeEmail)))
                {
                    Console.WriteLine($"{employee.Email} {employee.Phone} {employee.Gender} {employee.Nat}");
                }
            }
            Console.ReadLine();
        }
        public override Dictionary<int, string> MenuOptions { get; } = new();
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
    }

    public class FindEmployeeByNationalitySubmenu : Menu
    {
        public FindEmployeeByNationalitySubmenu()
        {
            Console.WriteLine("Search by Nationality");
            Console.WriteLine("Enter Nationality:");
            var EmployeeNationality = (Console.ReadLine());
            if (EmployeeNationality != null && !(String.IsNullOrWhiteSpace(EmployeeNationality)))
            {
                foreach (var employee in JsonHelper._employees.Where(x => x.Nat != null && x.Nat.Equals(EmployeeNationality))) 
                {
                    Console.WriteLine($" {employee.Email} {employee.Phone} {employee.Gender} {employee.Nat}");
                }
                Console.ReadLine();
            }
        }
        public override Dictionary<int, string> MenuOptions { get; } = new();
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
    }

    public class AddNewUserSubmenu : Menu
    {
        public AddNewUserSubmenu()
        {
            do
            {
                var newUser = GetPersonalDataToCreateNewEmployee();
                if (newUser != null)
                {
                    JsonHelper.AddNewEmployeeToEmployeesList(newUser);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        public override Dictionary<int, string> MenuOptions { get; } = new();
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
        private static Employee GetPersonalDataToCreateNewEmployee()
        {
            var email = ValidateEmployeesData("e-mail");

            if (JsonHelper.CheckIfUserExistsInDatabase(email))
            {
                Console.WriteLine("User with provided e-mail address already exists in the database. Press Escape to go back or any other key to retry.");
                return null;
            }

            var firstName = ValidateEmployeesData("first name");
            var lastName = ValidateEmployeesData("last name");
            var phone = ValidateEmployeesData("phone number");
            return new Employee(firstName, lastName, phone, email);
        }
        private static string ValidateEmployeesData(string dataName)
        {
            string input;
            var i = 0;
            do
            {
                i++;
                if (i > 1)
                {
                    Console.WriteLine($"Provided {dataName} cannot be empty.");
                    Console.ReadKey();
                }
                Banner.DrawTopBanner(true, "Add New Employee");
                Console.WriteLine($"Please provide the {dataName}");
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }
    }
}

using System;
using System.Collections.Generic;
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
                Banner.DrawTopBanner(true);
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
            Console.WriteLine("Menu 2");
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
            Console.WriteLine("Menu 3");
            Console.ReadLine();
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
            Console.WriteLine("Wyszukaj po emailu");
            Console.WriteLine("Wpisz Email pracownika");
            string EmployeeEmail = (Console.ReadLine());
            if (EmployeeEmail != null)
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
            Console.WriteLine("Wyszukaj po Narodowości");
            Console.WriteLine("Wpisz Narodowość:");
            var EmployeeNationality = (Console.ReadLine());
            if (EmployeeNationality != null)
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

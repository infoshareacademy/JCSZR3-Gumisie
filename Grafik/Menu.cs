﻿using System;
using System.Collections.Generic;
using System.IO;
using Grafik_Logic;
using Newtonsoft.Json;

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
            { 4, "Check daily shifts" }, //ALL - whole team's shifts
            { 5, "Modify employee's shift" }, //Manager's only
            { 6, "Add a new user" }, //Manager's only
        };

        public override Menu CheckMenuChoice(int userChoice) =>
            userChoice switch
            {
                1 => new CheckShiftsSubmenu(),
                2 => new SubmitNewShiftRequestSubmenu(),
                3 => new SubmitNewAbsenceRequestSubmenu(),
                4 => new CheckDailyShiftsSubmenu(),
                5 => new ModifyEmployeesShiftSubmenu(),
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
            JSONHelper.ListAllUsers();
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

    public class CheckDailyShiftsSubmenu : Menu
    {
        public CheckDailyShiftsSubmenu()
        {
            Console.WriteLine("Menu 4");
            Console.ReadLine();
        }

        public override Dictionary<int, string> MenuOptions { get; } = new();
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
    }

    public class ModifyEmployeesShiftSubmenu : Menu
    {
        public ModifyEmployeesShiftSubmenu()
        {
            Console.WriteLine("Menu 5");
            Console.ReadLine();
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
                Banner.DrawTopBanner(true);
                var newUser = GetPersonalDataToCreateNewEmployee();
                if (newUser != null)
                {
                    JSONHelper.SaveEmployeeToJson(newUser);
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
            Console.WriteLine("Please provide the e-mail");
            var email = Console.ReadLine();
            if (JSONHelper.CheckIfUserExistsInDatabase(email))
            {
                Console.WriteLine("User with provided e-mail address already exists in the database. Press Escape to go back or any other key to retry.");
                return null;
            }
            Console.WriteLine("Please provide the first name:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Please provide the last name:");
            var lastName = Console.ReadLine();
            Console.WriteLine("Please provide the phone number");
            var phone = Console.ReadLine();
            return new Employee(firstName, lastName, phone, email);
        }

    }


}

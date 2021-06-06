using System;
using System.Collections.Generic;
using Grafik_Logic;

namespace Grafik_Console
{
    public abstract class Menu
    {
        public abstract void ListMenu();
        protected abstract Dictionary<int, string> MenuOptions { get; }
        public abstract Menu CheckMenuChoice(int userChoice);
    }
    public class MainMenu : Menu
    {
        protected override Dictionary<int, string> MenuOptions { get; } = new()
        {
            {1,"Check shifts" },   //ALL - depending on login 
            {2,"Submit a new shift request" }, //ALL - depending on login 
            {3,"Submit a absence request" },  //ALL - depending on login
            {4,"Check daily shifts" }, //ALL - whole team's shifts
            {5,"Modify employee's shift" }, //Manager's only
        };

        public override Menu CheckMenuChoice(int userChoice) =>
            userChoice switch
            {
                1 => new CheckShiftsSubmenu(),
                2 => new SubmitNewShiftRequestSubmenu(),
                3 => new SubmitNewAbsenceRequestSubmenu(),
                4 => new CheckDailyShiftsSubmenu(),
                5 => new ModifyEmployeesShiftSubmenu(),
                _ => null
            };
        public override void ListMenu()
        {
            Console.WriteLine("\nPlease choose one of the options to proceed. Press Escape to exit.");
            foreach (var (menuNumber, returnedMenu) in MenuOptions)
            {
                Console.WriteLine($"{menuNumber}.{returnedMenu}");
            }
            Console.WriteLine();
        }
    }
    public class CheckShiftsSubmenu : Menu
    {
        public CheckShiftsSubmenu()
        {
            do
            {
                Banner.DrawTopBanner("Jakub");
                Console.WriteLine("Please provide a date");
                var dateChoice = Console.ReadLine();
                var output = ShiftChecker.CheckShift(dateChoice);
                Console.WriteLine(output);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        protected override Dictionary<int, string> MenuOptions { get; } = new();
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
        public override void ListMenu()
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

        protected override Dictionary<int, string> MenuOptions { get; } = new() { };
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
        public override void ListMenu()
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
        protected override Dictionary<int, string> MenuOptions { get; } = new() { };
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
        public override void ListMenu()
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
        protected override Dictionary<int, string> MenuOptions { get; } = new() { };
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
        public override void ListMenu()
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
        protected override Dictionary<int, string> MenuOptions { get; } = new() { };
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
        public override void ListMenu()
        {
            throw new NotImplementedException();
        }
    }
}

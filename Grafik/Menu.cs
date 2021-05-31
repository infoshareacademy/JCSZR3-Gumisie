using System;
using System.Collections.Generic;
using Grafik_Logic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafik_Console
{
    abstract public class Menu
    {
        protected abstract Dictionary<int, string> MenuOptions { get; set; }
        public abstract void ListMenu();
        public abstract Menu CheckMenuChoice(int userChoice);
    }
    public class MainMenu : Menu
    {
        public MainMenu()
        {
            MenuOptions = new Dictionary<int, string>
            {
                {1,"Check shifts" },   //ALL - depending on login 
                {2,"Submit a new shift request" }, //ALL - depending on login 
                {3,"Submit a absence request" },  //ALL - depending on login
                {4,"Check day's timeshifts" }, //ALL - whole team's timeshifts
                {5,"Modify employee's timeshift" }, //Manager's only
            };
        }
        protected override Dictionary<int, string> MenuOptions { get; set; }
        public override Menu CheckMenuChoice(int userChoice) =>
            userChoice switch
            {
                1 => new CheckShiftsSubmenu(),
                2 => new SubmitNewShiftRequestSubmenu(),
                3 => new SubmitNewAbsenceRequestSubmenu(),
                4 => new CheckDayilyTimeshiftsSubmenu(),
                5 => new ModifyEmployeesTimeshiftSubmenu(),
                _ => null
            };
        public override void ListMenu()
        {
            Console.WriteLine("\nPlease choose one of the options to proceed. Press Escape to exit.");
            foreach (KeyValuePair<int, string> item in MenuOptions)
            {
                Console.WriteLine($"{item.Key}.{item.Value}");
            }
            Console.WriteLine();
        }
    }
    public class CheckShiftsSubmenu : Menu
    {
        public CheckShiftsSubmenu()
        {
            //MenuOptions = new Dictionary<int, string>
            //{
            //    {1,"Check my shifts" },
            //    {2,"Submit a new shift request" },
            //    {3,"Submit a new holiday request" },
            //};
            Banner.DrawTopBanner("Jakub");
            Console.WriteLine("Please provide a date");
            var dateChoice = Console.ReadLine();
            var output = ShiftChecker.CheckShift(dateChoice);
            Console.WriteLine(output);
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Banner.DrawTopBanner("Jakub");
                Console.WriteLine("Please provide a date");
                dateChoice = Console.ReadLine();
                output = ShiftChecker.CheckShift(dateChoice);
                Console.WriteLine(output);
            }

        }
        protected override Dictionary<int, string> MenuOptions { get; set; }
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
            MenuOptions = new Dictionary<int, string>
            {
                {1,"Check my shifts" },
                {2,"Submit a new shift request" },
                {3,"Submit a new holiday request" },
            };
            Console.WriteLine("Menu 2");
            Console.ReadLine();
        }
        protected override Dictionary<int, string> MenuOptions { get; set; }
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
            MenuOptions = new Dictionary<int, string>
            {
                {1,"Check my shifts" },
                {2,"Submit a new shift request" },
                {3,"Submit a new holiday request" },
            };
            Console.WriteLine("Menu 3");
            Console.ReadLine();
        }
        protected override Dictionary<int, string> MenuOptions { get; set; }
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
        public override void ListMenu()
        {
            throw new NotImplementedException();
        }
    }
    public class CheckDayilyTimeshiftsSubmenu : Menu
    {
        public CheckDayilyTimeshiftsSubmenu()
        {
            MenuOptions = new Dictionary<int, string>
            {
                {1,"Check my shifts" },
                {2,"Submit a new shift request" },
                {3,"Submit a new holiday request" },
            };
            Console.WriteLine("Menu 4");
            Console.ReadLine();
        }
        protected override Dictionary<int, string> MenuOptions { get; set; }
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
        public override void ListMenu()
        {
            throw new NotImplementedException();
        }
    }
    public class ModifyEmployeesTimeshiftSubmenu : Menu
    {
        public ModifyEmployeesTimeshiftSubmenu()
        {
            MenuOptions = new Dictionary<int, string>
            {
                {1,"Check my shifts" },
                {2,"Submit a new shift request" },
                {3,"Submit a new holiday request" },
            };
            Console.WriteLine("Menu 5");
            Console.ReadLine();
        }
        protected override Dictionary<int, string> MenuOptions { get; set; }
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

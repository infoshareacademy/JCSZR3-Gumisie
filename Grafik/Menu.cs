using System;
using System.Collections.Generic;
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
                {1,"Check my shifts" },
                {2,"Submit a new shift request" },
                {3,"Submit a new holiday request" },
            };
        }

        protected override Dictionary<int, string> MenuOptions { get; set; }

        public override Menu CheckMenuChoice(int userChoice) =>
            userChoice switch
            {
                1 => new CheckMyShiftsSubmenu(),
                2 => new SubmitNewShiftRequestSubmenu(),
                3 => new SubmitNewHolidaysRequestSubmenu(),
                _ => null
            };

        public override void ListMenu()
        {
            Console.WriteLine("\nPlease choose one of the options to proceed:");
            foreach (KeyValuePair<int, string> item in MenuOptions)
            {
                Console.WriteLine($"{item.Key}.{item.Value}");
            }
            Console.WriteLine();
        }
    }

    public class SubmitNewHolidaysRequestSubmenu : Menu
    {
        public SubmitNewHolidaysRequestSubmenu()
        {
            MenuOptions = new Dictionary<int, string>
            {
                {1,"Check my shifts" },
                {2,"Submit a new shift request" },
                {3,"Submit a new holiday request" },
            };
        }

        protected override Dictionary<int, string> MenuOptions { get ; set; }

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
        }

        protected override Dictionary<int, string> MenuOptions { get ; set ; }

        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }

        public override void ListMenu()
        {
            throw new NotImplementedException();
        }
    }

    public class CheckMyShiftsSubmenu : Menu
    {
        public CheckMyShiftsSubmenu()
        {
            MenuOptions = new Dictionary<int, string>
            {
                {1,"Check my shifts" },
                {2,"Submit a new shift request" },
                {3,"Submit a new holiday request" },
            };
        }

        protected override Dictionary<int, string> MenuOptions { get ; set ; }

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

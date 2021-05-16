using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafik_Console
{
    abstract public class Menu
    {
        public abstract Dictionary<int, string> MenuOptions { get; set; }
        public abstract void ListMenu();
    }
    public class MainMenu : Menu
    {
        public MainMenu()
        {
            MenuOptions = new Dictionary<int, string>
            {
                {1,"Check my shifts" },
                {2,"Send a new shift request" },
                {3,"Send a new holiday request" },
            };
        }
        public override Dictionary<int, string> MenuOptions { get; set; }
        public override void ListMenu()
        {
            Console.WriteLine("\nPlease choose one of the options to proceed:");
            foreach (KeyValuePair<int,string> item in MenuOptions)
            {
                Console.WriteLine($"{item.Key}.{item.Value}");
            }
            Console.WriteLine();
        }
    }
}

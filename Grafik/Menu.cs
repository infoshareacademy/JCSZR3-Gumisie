using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafik_Console
{
    abstract public class Menu
    {
        public abstract void DrawMenu();

        public static void DrawTopBanner()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|        APPLICATION NAME         |");
            Console.WriteLine("-----------------------------------\n");
        }
        public static void DrawTopBanner(string userName)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|        APPLICATION NAME         |");
            Console.WriteLine("-----------------------------------\n");
            Console.WriteLine($"Welcome, {userName}                 {DateTime.Now.ToShortDateString()}");
        }
    }
    public class MainMenu : Menu
    {
        public override void DrawMenu()
        {
            Console.WriteLine("\nPlease choose one of the options to proceed:");
            Console.WriteLine("1.Check my shifts");
            Console.WriteLine("2.Send a new shift request");
            Console.WriteLine("3.Send a new holiday request\n");
        }
    }
    public class SubMenu
    {

    }

}

using System;

namespace Grafik_Console
{
    class Program
    {
        static void Main()
        {
            do
            {
                Menu.DrawTopBanner();
                Login.AskForCredentials();
                while (!Login.CheckCredentials())
                {
                    
                    Console.WriteLine("Wrong credentials. Please press any key and try again.");
                    Console.ReadLine();
                    Console.Clear();
                    Menu.DrawTopBanner();
                    Login.AskForCredentials();
                }
                Menu.DrawTopBanner("Jakub");
                MainMenu mainMenu = new();
                mainMenu.DrawMenu();
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

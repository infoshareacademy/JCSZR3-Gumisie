using System;

namespace Grafik_Console
{
    class Program
    {
        static void Main()
        {
            //applicaation start point
            do
            {
                Menu.DrawTopBanner();
                Login.AskForCredentials();

                //log-in 
                while (!Login.CheckCredentials())
                {
                    
                    Console.WriteLine("Wrong credentials. Please press any key and try again.");
                    Console.ReadLine();
                    Console.Clear();
                    Menu.DrawTopBanner();
                    Login.AskForCredentials();
                }

                //display main menu after successful log-in
                Menu.DrawTopBanner("Jakub");
                MainMenu mainMenu = new();
                mainMenu.ListMenu();
                
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

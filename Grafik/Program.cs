using System;

namespace Grafik_Console
{
    class Program
    {
        static void Main()
        {
            //application start point
            do
            {
                Banner.DrawTopBanner();
                Login.AskForCredentials();

                //log-in 
                while (!Login.CheckCredentials())
                {
                    
                    Console.WriteLine("Wrong credentials. Please press any key and try again.");
                    Console.ReadLine();
                    Console.Clear();
                    Banner.DrawTopBanner();
                    Login.AskForCredentials();
                }

                //display main menu after successful log-in
                Banner.DrawTopBanner("Jakub");
                MainMenu mainMenu = new();
                mainMenu.ListMenu();
                
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

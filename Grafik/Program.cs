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
                Banner.DrawTopBanner("Jakub"); //user name fetched from the database
                MainMenu mainMenu = new();
                mainMenu.ListMenu();

                //check user's choice in the main menu and returns the sebmenu 
                while (!Int32.TryParse(Console.ReadLine(), out int userChoice) || mainMenu.CheckMenuChoice(userChoice) == null)
                {
                    Console.Clear();
                    Banner.DrawTopBanner("Jakub");
                    mainMenu.ListMenu();
                    Console.WriteLine("Provided value was invalid. Please choose one option from the menu.");
                }


            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

using System;
using System.IO;

namespace Grafik_Console
{
    class Program
    {
        static void Main()
        {
            //application start point
            var i = 0;
            do
            {
                i++;
                if (i > 1)
                {
                    Console.WriteLine("Wrong credentials. Please press any key and try again.");
                    Console.ReadKey();
                }
                Banner.DrawTopBanner();
                Login.AskForCredentials();
            } while (!Login.CheckCredentials());

            //display main menu after successful log-in and check user's choice to return a submenu
            do
            {
                i = 0;
                ConsoleKey pressedKey = ConsoleKey.Escape;
                MainMenu mainMenu = new();
                do
                {
                    i++;
                    Banner.DrawTopBanner("Jakub"); //user name fetched from the database
                    mainMenu.ListMenu();
                    if (i > 1)
                    {
                        if (pressedKey == ConsoleKey.Escape)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Provided value was invalid. Please choose one option from the menu.");
                        }
                    }
                    pressedKey = Console.ReadKey(true).Key;
                } while (!Int32.TryParse(Char.GetNumericValue((char)pressedKey).ToString(), out int userChoice) || mainMenu.CheckMenuChoice(userChoice) == null);
            } while (true);
        }
    }
}

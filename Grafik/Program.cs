using System;
using System.IO;

namespace Grafik_Console
{
    class Program
    {
        static void Main()
        {
            //application start point
            bool loopProgram = true;
            var i = 0;
            do
            {
                i++;
                if (i>1)
                {
                    Console.WriteLine("Wrong credentials. Please press any key and try again.");
                    Console.ReadLine();
                    Console.Clear();
                }
                Banner.DrawTopBanner();
                Login.AskForCredentials();
            } while (!Login.CheckCredentials());

            do
            {
                //display main menu after successful log-in
                Banner.DrawTopBanner("Jakub"); //user name fetched from the database
                MainMenu mainMenu = new();
                mainMenu.ListMenu();

                //check user's choice in the main menu and returns the sebmenu
                var pressedKey = Console.ReadKey().Key;
                while (!Int32.TryParse(Char.GetNumericValue((char)pressedKey).ToString(), out int userChoice) || mainMenu.CheckMenuChoice(userChoice) == null)
                {
                    if (pressedKey == ConsoleKey.Escape)
                    {
                        loopProgram = false;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Banner.DrawTopBanner("Jakub");
                        mainMenu.ListMenu();
                        Console.WriteLine("Provided value was invalid. Please choose one option from the menu.");
                        pressedKey = Console.ReadKey().Key;
                    }
                }
            } while (loopProgram);
        }
    }
}

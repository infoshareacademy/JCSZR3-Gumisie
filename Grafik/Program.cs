using System;
using System.Globalization;
using Grafik_Logic;

namespace Grafik_Console
{
    internal static class Program
    {
        private static void Main()
        {
            //application start point - loading employees list from JSON
            JsonHelper.LoadEmployeesJson();
            JsonHelper.LoadTimesheetsJson();

            var i = 0;
            do
            {
                i++;
                if (i > 1)
                {
                    Console.WriteLine("Wrong credentials. Please press any key and try again.");
                    Console.ReadKey();
                }
                Banner.DrawTopBanner(false);
                Login.AskForCredentials();
            } while (!Login.CheckCredentials());

            //display main menu after successful log-in and check user's choice to return a submenu
            ConsoleKey pressedKey = default;
            MainMenu mainMenu = new();

            do
            {
                i = 0;
                do
                {
                    i++;
                    Banner.DrawTopBanner(true,"Main Menu");
                    Menu.ListMenu(mainMenu.MenuOptions);
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
                } while (!int.TryParse(char.GetNumericValue((char)pressedKey).ToString(CultureInfo.InvariantCulture), out var userChoice) || mainMenu.CheckMenuChoice(userChoice) == null);
            } while (true);
        }
    }
}
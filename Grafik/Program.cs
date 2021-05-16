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
                    Menu.DrawTopBanner(); 
                    Console.WriteLine("Wrong credentials. Please press any key and try again.");
                    Console.ReadLine();
                    Login.AskForCredentials();
                }
                Menu.DrawTopBanner();
                Console.WriteLine("You are logged in.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

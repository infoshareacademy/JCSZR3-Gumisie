using System;

namespace Grafik_Console
{
    internal static class Banner
    {
        public static void DrawTopBanner(bool loggedIn)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|        APPLICATION NAME         |");
            Console.WriteLine("-----------------------------------\n");
            if (loggedIn)
            {
                Console.WriteLine($"Welcome, {"Jakub"}                 {DateTime.Now.ToShortDateString()}");  
            }
        }
    }
}

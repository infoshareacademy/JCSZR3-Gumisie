using System;

namespace Grafik_Console
{
    internal static class Banner
    {
        public static void DrawTopBanner(bool loggedIn, string menuName = "")
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|        APPLICATION NAME         |");
            Console.WriteLine("-----------------------------------\n");
            if (!loggedIn) return;
            Console.WriteLine($"Welcome, {"Jakub"}                 {DateTime.Now.ToShortDateString()}");
            Console.WriteLine($"               {menuName}                                        ");
            Console.WriteLine();
        }
    }
}
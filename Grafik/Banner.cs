using System;

namespace Grafik_Console
{
    internal static class Banner
    {
        public static void DrawTopBanner()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|        APPLICATION NAME         |");
            Console.WriteLine("-----------------------------------\n");
        }
        public static void DrawTopBanner(string userName)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|        APPLICATION NAME         |");
            Console.WriteLine("-----------------------------------\n");
            Console.WriteLine($"Welcome, {userName}                 {DateTime.Now.ToShortDateString()}");
        }
    }
}

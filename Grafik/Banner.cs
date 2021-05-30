using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafik_Console
{
    static class Banner
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

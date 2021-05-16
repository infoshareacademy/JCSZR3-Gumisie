using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafik_Console
{
    public class Menu
    {
        public virtual void DrawMenu()
        {

        }

        public static void DrawTopBanner()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|        APPLICATION NAME         |");
            Console.WriteLine("-----------------------------------");
        }
    }
    public class MainMenu :Menu
    {
       public override void DrawMenu()
        {

        }
    }
    public class SubMenu
    {

    }

}

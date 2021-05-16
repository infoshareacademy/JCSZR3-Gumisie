using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafik_Console
{
    public class Login
    {
        private static string userMail;
        private static string userPassword;
        public static void AskForCredentials()
        {
            userMail = "";
            userPassword = "";
            Console.WriteLine("Please provide your email:");
            userMail = Console.ReadLine();
            Console.WriteLine("Please provide you password:");
            userPassword = Console.ReadLine();
        }
        public static bool CheckCredentials() => userMail == "123" && userPassword == "admin";
    }
}

using System;

namespace Grafik_Console
{
    public static class Login
    {
        private static string _userMail;
        private static string _userPassword;
        public static void AskForCredentials()
        {
            _userMail = "";
            _userPassword = "";
            Console.WriteLine("Please provide your email:");
            _userMail = Console.ReadLine();
            Console.WriteLine("Please provide your password:");
            _userPassword = Console.ReadLine();
        }
        public static bool CheckCredentials() => _userMail == "123" && _userPassword == "admin";
    }
}

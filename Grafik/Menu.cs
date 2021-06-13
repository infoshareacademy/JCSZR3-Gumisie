using System;
using System.Collections.Generic;
using System.IO;
using Grafik_Logic;
using Newtonsoft.Json;

namespace Grafik_Console
{
    public abstract class Menu
    {
        public static void ListMenu(Dictionary<int,string> menuToList)
        {
            foreach (var (menuNumber, menuOption) in menuToList)
            {
                Console.WriteLine($"{menuNumber}.{menuOption}");
            }
        }
        public abstract Dictionary<int, string> MenuOptions { get; }
        public abstract Menu CheckMenuChoice(int userChoice);
    }
    public class MainMenu : Menu
    {
        public override Dictionary<int, string> MenuOptions { get; } = new()
        {
            {1,"Check shifts" },   //ALL - depending on login 
            {2,"Submit a new shift request" }, //ALL - depending on login 
            {3,"Submit a absence request" },  //ALL - depending on login
            {4,"Check daily shifts" }, //ALL - whole team's shifts
            {5,"Modify employee's shift" }, //Manager's only
            {6,"Add new user" }, //Manager's only
        };

        public override Menu CheckMenuChoice(int userChoice) =>
            userChoice switch
            {
                1 => new CheckShiftsSubmenu(),
                2 => new SubmitNewShiftRequestSubmenu(),
                3 => new SubmitNewAbsenceRequestSubmenu(),
                4 => new CheckDailyShiftsSubmenu(),
                5 => new ModifyEmployeesShiftSubmenu(),
                6 => new AddNewUserSubmenu(),
                _ => null
            };
    }
    public class CheckShiftsSubmenu : Menu
    {
        public CheckShiftsSubmenu()
        {
            do
            {
                Banner.DrawTopBanner(true);
                Console.WriteLine("Please provide a date");
                var dateChoice = Console.ReadLine();
                var output = ShiftChecker.CheckShift(dateChoice);
                Console.WriteLine(output);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        public override Dictionary<int, string> MenuOptions { get; } = new();
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
    }

    public class SubmitNewShiftRequestSubmenu : Menu
    {
        public SubmitNewShiftRequestSubmenu()
        {
            Console.WriteLine("Menu 2");
            Console.ReadLine();
        }

        public override Dictionary<int, string> MenuOptions { get; } = new();
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
    }

    public class SubmitNewAbsenceRequestSubmenu : Menu
    {
        public SubmitNewAbsenceRequestSubmenu()
        {
            Console.WriteLine("Menu 3");
            Console.ReadLine();
        }

        public override Dictionary<int, string> MenuOptions { get; } = new();
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
    }

    public class CheckDailyShiftsSubmenu : Menu
    {
        public CheckDailyShiftsSubmenu()
        {
            Console.WriteLine("Menu 4");
            Console.ReadLine();
        }

        public override Dictionary<int, string> MenuOptions { get; } = new();
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
    }

    public class ModifyEmployeesShiftSubmenu : Menu
    {
        public ModifyEmployeesShiftSubmenu()
        {
            Console.WriteLine("Menu 5");
            Console.ReadLine();
        }

        public override Dictionary<int, string> MenuOptions { get; } = new();
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
    }

    public class AddNewUserSubmenu : Menu {

        public AddNewUserSubmenu()
        {
            Console.WriteLine("Menu 6");
            Console.WriteLine("Poniższe dane są wymagane:");
            Console.WriteLine("Podaj imie: ");
            string first_name = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko: ");
            string last_name = Console.ReadLine();
            Console.WriteLine("Podaj email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Podaj telefon: ");
            string phone = Console.ReadLine();
            Console.WriteLine($"{ first_name } { last_name} { email } {phone}" );
            Console.ReadKey();
            Employee newUser = new(first_name, last_name, phone, email);
            string fileName = "Employees.json";
            var path = @"E:\Projects\Grafik\JCSZR3-Gumisie\Grafik.Logic\JSON Files\Employees.json";
            var path1 = Path.Combine(Environment.CurrentDirectory, @"JSON Files", fileName);
            Console.WriteLine(path);
            Console.WriteLine(path1);
            string json = File.ReadAllText(path1);
            List<Employee> listOfEmployees = JsonConvert.DeserializeObject<List<Employee>>(json);
            bool ifUserExist = false;
            foreach (var item in listOfEmployees)
            {
                if (item.Email == newUser.Email) {
                    ifUserExist = true;
                }
            }
            if (!ifUserExist) {
                listOfEmployees.Add(newUser);
               var newJson = JsonConvert.SerializeObject(listOfEmployees);
                File.WriteAllText(path, newJson);
                Console.WriteLine("Nowy uzytkownik zostal dodany!") ;
            }else
                Console.WriteLine("Użytkownik z takim adresem email juz istnieje!");
            Console.ReadKey();
            

        }
        public override Dictionary<int, string> MenuOptions { get; } = new();
        public override Menu CheckMenuChoice(int userChoice)
        {
            throw new NotImplementedException();
        }
    }


}

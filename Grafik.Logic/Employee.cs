using System;

namespace Grafik_Logic
{
    public class Employee
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }


        public Employee(int userId, string firstName, string lastName, int phoneNumber, string emailAdress)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAdress;
        }
    }
}

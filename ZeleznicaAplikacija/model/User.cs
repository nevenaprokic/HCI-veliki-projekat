using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaAplikacija.model
{
    public enum UserType
    {
        CLIENT,
        MANAGER
    }

    public class User
    {
        public User() { }

        public User(string email, string password, string firstName, string lastName, UserType type, string phoneNumber, DateTime dateOfBirth)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Type = type;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType Type { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }



}

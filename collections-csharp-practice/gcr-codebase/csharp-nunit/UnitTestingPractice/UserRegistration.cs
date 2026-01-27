using System;
using System.Text.RegularExpressions;

namespace UnitTestingPractice
{
    public class UserRegistration
    {
        public bool RegisterUser(string username, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is invalid");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Email is invalid");

            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                throw new ArgumentException("Password is invalid");

            // Registration successful
            return true;
        }
    }
}

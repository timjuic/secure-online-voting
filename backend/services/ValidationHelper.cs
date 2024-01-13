using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    using System;
    using System.Text.RegularExpressions;

    public static class ValidationHelper
    {
        public static bool IsValidFirstName(string firstName)
        {
            // Assuming the first name should contain only letters and be between 2 and 50 characters
            return !string.IsNullOrEmpty(firstName) && Regex.IsMatch(firstName, "^[a-zA-Z]{2,50}$");
        }

        public static bool IsValidLastName(string lastName)
        {
            // Assuming the last name should contain only letters and be between 2 and 50 characters
            return !string.IsNullOrEmpty(lastName) && Regex.IsMatch(lastName, "^[a-zA-Z]{2,50}$");
        }

        public static bool IsValidEmail(string email)
        {
            // Using a simple email validation regex (not perfect, but covers common cases)
            return !string.IsNullOrEmpty(email) && Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        public static bool IsValidPassword(string password)
        {
            // Assuming the password should be at least 8 characters long and contain letters and numbers
            return !string.IsNullOrEmpty(password) && password.Length >= 8 && Regex.IsMatch(password, "[a-zA-Z]") && Regex.IsMatch(password, "[0-9]");
        }
    }

}

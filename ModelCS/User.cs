using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public static IEnumerable<User> GetUsers()
        {
            return new List<User>() 
            {
                new User() { FirstName = "Kyle", LastName = "Admin", Email = "k.admin@online.com", Password = "admiNp4sswoRd", IsAdmin = true },
                new User() { FirstName = "Vitali", LastName = "User", Email = "k.user@online.com", Password = "userpassword", IsAdmin = false }
            };
        }
    }
}

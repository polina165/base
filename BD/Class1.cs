using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class UserCredentials
    {
        public string UserId { get; set; }
        public string Password { get; set; }

        public UserCredentials(string userId, string password)
        {
            UserId = userId;
            Password = password;
        }
    }
}

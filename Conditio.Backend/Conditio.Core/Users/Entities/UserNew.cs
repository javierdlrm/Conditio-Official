using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Core.Users
{
    public class UserNew
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public UserProfile Profile { get; set; }
    }
}

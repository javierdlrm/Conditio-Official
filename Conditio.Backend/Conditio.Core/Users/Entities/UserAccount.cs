using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Core.Users
{
    public class UserAccount
    {
        public Credentials Credentials { get; set; }
        public bool Hidden { get; set; }
        public bool Premium { get; set; }
    }

    public class Credentials
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}

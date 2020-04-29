using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Core.Users
{
    public class User
    {
        public string Id { get; set; }
        public UserAccount Account { get; set; }
        public UserProfile Profile { get; set; }

        public static User From(UserNew userNew)
        {
            return new User()
            {
                Profile = userNew.Profile,
                Account = new UserAccount()
                {
                    Credentials = new Credentials()
                    {
                        Email = userNew.Email,
                        PasswordHash = userNew.PasswordHash
                    }
                }
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Adapter.API.Users
{
    public class UserDTO
    {
        public string Id { get; set; }
        public UserProfile Profile { get; set; }
    }
}

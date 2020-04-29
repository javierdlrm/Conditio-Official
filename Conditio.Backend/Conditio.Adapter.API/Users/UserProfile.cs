using AutoMapper;
using Conditio.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Adapter.API.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}

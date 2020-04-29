using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Conditio.Core.Users;

namespace Conditio.Adapter.API.Users
{
    public class UserServiceAdapter : BaseServiceAdapter, IUserServiceAdapter
    {
        private readonly IUserService _userService;

        public UserServiceAdapter(IUserService userService, IMapper mapper) : base(mapper)
        {
            _userService = userService;
        }

        public async Task<bool> CheckCredentials(Credentials credentials)
        {
            return await _userService.CheckCredentials(credentials);
        }

        public async Task DeleteAsync(string id)
        {
            await _userService.DeleteAsync(id);
        }

        public async Task<UserDTO> GetAsync(string id)
        {
            var user = await _userService.GetAsync(id);
            return Mapper.Map<UserDTO>(user);
        }

        public async Task RegisterAsync(UserNew userNew)
        {
            await _userService.RegisterAsync(userNew);
        }

        public async Task UpdateAsync(string username, UserUpdate userUpdate)
        {
            await _userService.UpdateAsync(username, userUpdate);
        }
    }
}

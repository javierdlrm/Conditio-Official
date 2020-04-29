using Conditio.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Adapter.API.Users
{
    public interface IUserServiceAdapter
    {
        Task RegisterAsync(UserNew userNew);
        Task DeleteAsync(string id);
        Task<UserDTO> GetAsync(string id);
        Task UpdateAsync(string id, UserUpdate userUpdate);
        Task<bool> CheckCredentials(Credentials credentials);
    }
}

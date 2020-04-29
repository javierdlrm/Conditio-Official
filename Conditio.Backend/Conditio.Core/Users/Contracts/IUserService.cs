using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Core.Users
{
    public interface IUserService
    {
        Task RegisterAsync(UserNew userNew);
        Task DeleteAsync(string id);
        Task<User> GetAsync(string id);
        Task UpdateAsync(string id, UserUpdate userUpdate);

        Task<bool> CheckCredentials(Credentials credentials);
    }
}

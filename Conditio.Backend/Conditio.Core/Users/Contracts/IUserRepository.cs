using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Core.Users
{
    public interface IUserRepository
    {
        Task AddAsync(User item);
        Task UpdateAsync(string id, UserUpdate item);
        Task<User> GetAsync(string id);
        Task DeleteAsync(string id);

        Task<Credentials> GetCredentialsByEmail(string email);
    }
}

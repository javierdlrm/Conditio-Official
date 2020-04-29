using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Core.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region CRUD

        public async Task DeleteAsync(string id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<User> GetAsync(string id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task RegisterAsync(UserNew newUser)
        {
            var user = User.From(newUser);
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(string id, UserUpdate userUpdate)
        {
            await _userRepository.UpdateAsync(id, userUpdate);
        }

        #endregion

        #region Authentication

        public async Task<bool> CheckCredentials(Credentials credentials)
        {
            var userCredentials = await _userRepository.GetCredentialsByEmail(credentials.Email);
            return userCredentials.PasswordHash.Equals(credentials.PasswordHash);
        }

        #endregion
    }
}

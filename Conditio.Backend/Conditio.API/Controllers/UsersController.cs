using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conditio.Adapter.API.Users;
using Conditio.Core.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConditioWeb.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServiceAdapter _userService;

        public UsersController(IUserServiceAdapter userService)
        {
            _userService = userService;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<UserDTO> Get(string id)
        {
            return await _userService.GetAsync(id);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UserUpdate userUpdate)
        {
            try
            {
                await _userService.UpdateAsync(id, userUpdate);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(string id)
        {
            await _userService.DeleteAsync(id);
        }
    }
}

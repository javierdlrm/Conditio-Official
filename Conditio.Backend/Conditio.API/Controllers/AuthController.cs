using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conditio.Adapter.API.Users;
using Conditio.Core.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conditio.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserServiceAdapter _userService;

        public AuthController(IUserServiceAdapter userService)
        {
            _userService = userService;
        }

        // GET: api/auth/signin
        [HttpGet("[action]")]
        public async Task<IActionResult> SignIn([FromBody] Credentials credentials)
        {
            if (await _userService.CheckCredentials(credentials))
            {
                return Ok("token");
            }
            return Unauthorized();
        }

        // POST: api/auth/register
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] UserNew userNew)
        {
            try
            {
                await _userService.RegisterAsync(userNew);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
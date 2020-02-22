using Identity.WebApi.Models;
using Identity.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.WebApi.Controllers.User.v1
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Login loginParam)
        {
            var token = _userService.Authenticate(loginParam.UserName, loginParam.Password);

            if (token == null)
                return BadRequest(new { message = "Username or Password is incorrect" });

            return Ok(token);
        }
    }
}
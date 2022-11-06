using Microsoft.AspNetCore.Mvc;
using Community_Libary.API.UsersAPI;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using Community_Libary.BL.UsersBL;
using Microsoft.AspNetCore.Cors;

namespace Community_Libary.WEB.Controllers
{
    [Route("api/auth")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUsersService _userService;

        public UserController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<ActionResult> PostRegister(RegisterUserDTO user)
        {
            try
            {
                await _userService.registerUserAsync(user);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(419);
            }
        }
        [HttpPost("signin")]
        public async Task<ActionResult> PostLogin(LoginUserDTO user)
        {
            try
            {
                return StatusCode(200, await _userService.loginUserAsync(user));
            }
            catch
            {
                return StatusCode(400);
            }
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
                return StatusCode(200);
        }
    }
}

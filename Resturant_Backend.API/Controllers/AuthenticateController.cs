using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant_Backend.Business;
using Resturant_Backend.DataAccess.Models.Auth;

namespace Resturant_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserManagerService _userManager;
        public AuthenticateController(IUserManagerService userManager)
        {
            _userManager = userManager;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var login = await _userManager.Login(model);
            return login is not null ? Ok(login) : Unauthorized();

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var register = await _userManager.Register(model);

            switch (register.Status)
            {
                case Domain.Enums.eResponseStatus.Success:
                    return Ok(register);

                case Domain.Enums.eResponseStatus.Failed:
                    return StatusCode(StatusCodes.Status500InternalServerError, register);
                case Domain.Enums.eResponseStatus.Already:
                    return StatusCode(StatusCodes.Status500InternalServerError, register);
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }

        [HttpPost]
        [Route("register-admin")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var register = await _userManager.Register(model);

            switch (register.Status)
            {
                case Domain.Enums.eResponseStatus.Success:
                    return Ok(register);

                case Domain.Enums.eResponseStatus.Failed:
                    return StatusCode(StatusCodes.Status500InternalServerError, register);
                case Domain.Enums.eResponseStatus.Already:
                    return StatusCode(StatusCodes.Status500InternalServerError, register);
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}


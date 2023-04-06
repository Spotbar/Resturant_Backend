using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resturant_Backend.Business;
using Resturant_Backend.DataAccess.Models.Auth;
using Resturant_Backend.DataAccess.Repository;
using Resturant_Backend.Domain.Entities;

namespace Resturant_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        // private readonly IUserManagerService _userManager;
        private readonly IJWTManagerRepository _jWTManager;
        private readonly IUserServiceRepository _userServiceRepository;
        public AuthenticateController(
           // IUserManagerService userManager,
            IJWTManagerRepository jWTManager,
            IUserServiceRepository userServiceRepository
            )
        {
            //  _userManager = userManager;
            this._jWTManager = jWTManager;
            this._userServiceRepository = userServiceRepository;
        }
        //[HttpPost]
        //[Route("register")]
        //public async Task<IActionResult> Register([FromBody] RegisterModel model)
        //{
        //    var register = await _userManager.Register(model);

        //    switch (register.Status)
        //    {
        //        case Domain.Enums.eResponseStatus.Success:
        //            return Ok(register);

        //        case Domain.Enums.eResponseStatus.Failed:
        //            return StatusCode(StatusCodes.Status500InternalServerError, register);
        //        case Domain.Enums.eResponseStatus.Already:
        //            return StatusCode(StatusCodes.Status500InternalServerError, register);
        //        default:
        //            return StatusCode(StatusCodes.Status500InternalServerError);
        //    }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginModel model)
        //{
        //    var login = await _userManager.Login(model);
        //    return login is not null ? Ok(login) : Unauthorized();

        //}

        //[HttpPost]
        //[Route("register")]
        //public async Task<IActionResult> Register([FromBody] RegisterModel model)
        //{
        //    var register = await _userManager.Register(model);

        //    switch (register.Status)
        //    {
        //        case Domain.Enums.eResponseStatus.Success:
        //            return Ok(register);

        //        case Domain.Enums.eResponseStatus.Failed:
        //            return StatusCode(StatusCodes.Status500InternalServerError, register);
        //        case Domain.Enums.eResponseStatus.Already:
        //            return StatusCode(StatusCodes.Status500InternalServerError, register);
        //        default:
        //            return StatusCode(StatusCodes.Status500InternalServerError);
        //    }


        //}

        //[HttpPost]
        //[Route("register-admin")]
        //[Authorize(Roles = nameof(UserRoles.Admin))]
        //public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        //{
        //    var register = await _userManager.Register(model);

        //    switch (register.Status)
        //    {
        //        case Domain.Enums.eResponseStatus.Success:
        //            return Ok(register);

        //        case Domain.Enums.eResponseStatus.Failed:
        //            return StatusCode(StatusCodes.Status500InternalServerError, register);
        //        case Domain.Enums.eResponseStatus.Already:
        //            return StatusCode(StatusCodes.Status500InternalServerError, register);
        //        default:
        //            return StatusCode(StatusCodes.Status500InternalServerError);
        //    }

        //}


        //[HttpGet]
        //public List<string> Get()
        //{
        //    var users = new List<string>
        //{

        //};

        //    return users;
        //}

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(LoginModel usersdata)
        {
            var validUser = await _userServiceRepository.IsValidUserAsync(usersdata);

            if (!validUser)
            {
                return Unauthorized("Incorrect username or password!");
            }

            var token = _jWTManager.GenerateToken(usersdata.Username);

            if (token == null)
            {
                return Unauthorized("Invalid Attempt!");
            }

            // saving refresh token to the db
            UserRefreshTokens obj = new UserRefreshTokens
            {
                RefreshToken = token.Refresh_Token,
                UserName = usersdata.Username
            };

            _userServiceRepository.AddUserRefreshTokens(obj);
            _userServiceRepository.SaveCommit();
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh(Tokens token)
        {
            var principal = _jWTManager.GetPrincipalFromExpiredToken(token.Access_Token);
            var username = principal.Identity?.Name;

            //retrieve the saved refresh token from database
            var savedRefreshToken = _userServiceRepository.GetSavedRefreshTokens(username, token.Refresh_Token);

            if (savedRefreshToken.RefreshToken != token.Refresh_Token)
            {
                return Unauthorized("Invalid attempt!");
            }

            var newJwtToken = _jWTManager.GenerateRefreshToken(username);

            if (newJwtToken == null)
            {
                return Unauthorized("Invalid attempt!");
            }

            // saving refresh token to the db
            UserRefreshTokens obj = new UserRefreshTokens
            {
                RefreshToken = newJwtToken.Refresh_Token,
                UserName = username
            };

            _userServiceRepository.DeleteUserRefreshTokens(username, token.Refresh_Token);
            _userServiceRepository.AddUserRefreshTokens(obj);
            _userServiceRepository.SaveCommit();

            return Ok(newJwtToken);
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var register = await _userServiceRepository.Register(model);

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


﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Resturant_Backend.DataAccess.Models.Auth;
using Resturant_Backend.DataAccess.Repository;
using Resturant_Backend.Domain.Entities;

namespace Resturant_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowClientOrigin")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;
        private readonly IUserServiceRepository _userServiceRepository;
        public AuthenticateController(
            IJWTManagerRepository jWTManager,
            IUserServiceRepository userServiceRepository
            )
        {
            this._jWTManager = jWTManager;
            this._userServiceRepository = userServiceRepository;
        }

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
            await _userServiceRepository.SaveChangesAsync();
            //, SameSite = SameSiteMode.Strict
            //SameSite = SameSiteMode.None, Secure = false

            //var Coption =  new CookieOptions() { HttpOnly = true, Secure = false };
            //Response.Cookies.Append("X-Access-Token", token.Access_Token, Coption);
            //Response.Cookies.Append("X-Username", obj.UserName, Coption);
            //Response.Cookies.Append("X-Refresh-Token", token.Refresh_Token,Coption );


            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh(Tokens token)
        {
            var principal = _jWTManager.GetPrincipalFromExpiredToken(token.Access_Token);
            var username = principal.Identity?.Name;

            //retrieve the saved refresh token from database
            var savedRefreshToken = _userServiceRepository.GetSavedRefreshTokens(username, token.Refresh_Token);
            if (savedRefreshToken == null) return Unauthorized("Invalid attempt!");
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
            await _userServiceRepository.SaveChangesAsync();

            Response.Cookies.Append("X-Access-Token", newJwtToken.Access_Token, new CookieOptions() { HttpOnly = true });
            Response.Cookies.Append("X-Username", obj.UserName, new CookieOptions() { HttpOnly = true });
            Response.Cookies.Append("X-Refresh-Token", obj.RefreshToken, new CookieOptions() { HttpOnly = true });
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

        [HttpPost]
        [Route("register-admin")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var register = await _userServiceRepository.RegisterAdmin(model);

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


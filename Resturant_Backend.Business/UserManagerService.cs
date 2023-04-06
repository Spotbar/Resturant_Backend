//using Resturant_Backend.DataAccess.Events;
//using Resturant_Backend.Infra.Exceptions;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Resturant_Backend.DataAccess.Models;
using Resturant_Backend.DataAccess.Models.Auth;
using Resturant_Backend.Domain.Entities;
using Resturant_Backend.Domain.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


//[assembly: InternalsVisibleTo("ITeasy_UniversityManagementDemo.Test")]

namespace Resturant_Backend.Business
{
    public class UserManagerService : IUserManagerService
    {
        //UserFactory _userFactory=new UserFactory();
        //          var res = _userFactory.CreateUser(user.Name, user.NationalCode,user.PhoneNumber);



        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public UserManagerService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<Tokens?> Login(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return new Tokens()
                {
                  //  Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
            }
            return null;
        }


        public async Task<Response> Register(RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.NationalCode);
            if (userExists != null)
                return new Response { Status = eResponseStatus.Already, Message = "User already exists!" };

            ApplicationUser user = new ApplicationUser()
            {
                Name = model.Name,
                LastName = model.LastName,
                NationalCode = model.NationalCode,
                PhoneNumber = model.PhoneNumber,
                Post = model.Post,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.NationalCode
            };
            try
            {
                var result = await userManager.CreateAsync(user, model.Password);
                await userManager.AddToRoleAsync(user, UserRoles.User);
                if (!result.Succeeded)
                    return new Response { Status = eResponseStatus.Failed, Message = "User creation failed! Please check user details and try again." };

            }
            catch (Exception c)
            {

                throw;
            }

            return new Response { Status = eResponseStatus.Success, Message = "User created successfully!" };
        }

        public async Task<Response> AdminRegister(RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.NationalCode);
            if (userExists != null)
                return new Response { Status = eResponseStatus.Already, Message = "User already exists!" };

            ApplicationUser user = new ApplicationUser()
            {
                Name = model.Name,
                NationalCode = model.NationalCode,
                PhoneNumber = model.PhoneNumber,
                Post = model.Post,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.NationalCode
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new Response { Status = eResponseStatus.Failed, Message = "User creation failed! Please check user details and try again." };

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return new Response { Status = eResponseStatus.Success, Message = "User created successfully!" };
        }





    }
}

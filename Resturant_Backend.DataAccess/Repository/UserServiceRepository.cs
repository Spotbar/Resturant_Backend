using Microsoft.AspNetCore.Identity;
using Resturant_Backend.DataAccess.Models.Auth;
using Resturant_Backend.Domain.DbContexts;
using Resturant_Backend.Domain.Entities;
using Resturant_Backend.Domain.Enums;
using Resturant_Backend.DataAccess.Models;
using Resturant_Backend.DataAccess.Factory;

namespace Resturant_Backend.DataAccess.Repository
{
    public class UserServiceRepository : IUserServiceRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDBContext _db;
        UserFactory _userfact;
        public UserServiceRepository(UserManager<ApplicationUser> userManager, ApplicationDBContext db)
        {
            _userfact = new();
            this._userManager = userManager;
            this._db = db;
        }

        public UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens user)
        {
            _db.UserRefreshToken.Add(user);
            return user;
        }

        public void DeleteUserRefreshTokens(string username, string refreshToken)
        {
            var item = _db.UserRefreshToken.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshToken);
            if (item != null)
            {
                _db.UserRefreshToken.Remove(item);
            }
        }

        public UserRefreshTokens? GetSavedRefreshTokens(string username, string refreshToken)
        {
            return _db.UserRefreshToken.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshToken && x.IsActive);
        }

        public int SaveCommit()
        {
            return _db.SaveChanges();
        }

        public async Task<Response> Register(RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.NationalCode);
            if (userExists != null)
                return new Response { Status = eResponseStatus.Already, Message = "User already exists!" };

          
            ApplicationUser user = _userfact.CreateUser(model.Name, model.LastName, model.NationalCode, model.PhoneNumber, model.Post);


            user.SecurityStamp = Guid.NewGuid().ToString();
            user.UserName = model.NationalCode;
            
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, UserRoles.User);
                if (!result.Succeeded)
                    return new Response { Status = eResponseStatus.Failed, Message = "User creation failed! Please check user details and try again." };

            }
            catch (Exception c)
            {

                throw;
            }

            return new Response { Status = eResponseStatus.Success, Message = "User created successfully!" };
        }
        public async Task<Response> RegisterAdmin(RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.NationalCode);
            if (userExists != null)
                return new Response { Status = eResponseStatus.Already, Message = "User already exists!" };

            ApplicationUser user = _userfact.CreateUser(model.Name, model.LastName, model.NationalCode, model.PhoneNumber, model.Post);
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, UserRoles.User);
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
                if (!result.Succeeded)
                    return new Response { Status = eResponseStatus.Failed, Message = "User creation failed! Please check user details and try again." };

            }
            catch (Exception c)
            {

                throw;
            }

            return new Response { Status = eResponseStatus.Success, Message = "User created successfully!" };
        }



        public async Task<bool> IsValidUserAsync(LoginModel users)
        {
            
            var u = _userManager.Users.FirstOrDefault(o => o.UserName == users.Username);
            var result = await _userManager.CheckPasswordAsync(u, users.Password);
            return result;

        }
    }
}

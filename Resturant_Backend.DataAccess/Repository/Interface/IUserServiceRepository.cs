using Resturant_Backend.DataAccess.Models;
using Resturant_Backend.DataAccess.Models.Auth;
using Resturant_Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant_Backend.DataAccess.Repository
{
    public interface IUserServiceRepository
    {
        Task<bool> IsValidUserAsync(LoginModel users);

        UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens user);

        UserRefreshTokens? GetSavedRefreshTokens(string username, string refreshtoken);

        void DeleteUserRefreshTokens(string username, string refreshToken);

        Task<Response> Register(RegisterModel model);
        Task<Response> RegisterAdmin(RegisterModel model);
        Task SaveChangesAsync();
    }
}

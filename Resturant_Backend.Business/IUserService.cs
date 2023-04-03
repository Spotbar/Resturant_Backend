using Resturant_Backend.DataAccess.Models.Auth;

namespace Resturant_Backend.Business
{
    public interface IUserManagerService
    {


        Task<TokenModel?> Login(LoginModel model);
        Task<Response> Register(RegisterModel model);
        Task<Response> AdminRegister(RegisterModel model);
    }
}

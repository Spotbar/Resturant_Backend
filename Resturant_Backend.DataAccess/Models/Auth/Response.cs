using Resturant_Backend.Domain.Enums;

namespace Resturant_Backend.DataAccess.Models.Auth
{
    public class Response
    {
        public eResponseStatus Status { get; set; }
        public string Message { get; set; }
    }
}

using Resturant_Backend.Domain.Enums;
using System.Runtime.InteropServices.JavaScript;

namespace Resturant_Backend.DataAccess.Models
{
    public class Response
    {
        public eResponseStatus Status { get; set; }
        public JSObject Data { get; set; }
        public string Message { get; set; }
    }
}

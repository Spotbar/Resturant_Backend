using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Resturant_Backend.Business;
using Resturant_Backend.DataAccess.Models.Auth;

namespace Resturant_Backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TestController : ControllerBase
    {
       

        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
           
        }
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [HttpGet(Name = "Get_Admin_Test")]
       
        public IActionResult Get_Admin()
        {

            return Ok("hello Admin");
        }

       // [Authorize]
        //[HttpGet(Name = "Get_Authorize_Test")]
       // [Route("Get_Authorize")]
        //public IActionResult Get_Authorize()
        //{

        //    return Ok("hello Authorize");
        //}

        //[HttpGet(Name = "Get_Test")]
        //[Route("Get")]
        //public IActionResult Get()
        //{

        //    return Ok("hello Authorize");
        //}
    }
}
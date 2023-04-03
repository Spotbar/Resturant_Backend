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
        [HttpGet(Name = "GetTest")]
        public IActionResult Get()
        {

            return Ok("hello");
        }

      

    }
}
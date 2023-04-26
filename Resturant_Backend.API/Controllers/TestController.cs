using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Resturant_Backend.Business;
using Resturant_Backend.DataAccess.Models.Auth;

namespace Resturant_Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowClientOrigin")]
    public class TestController : ControllerBase
    {
       

        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
           
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {

            return Ok("Hello");
        }


        [Authorize]
        [HttpGet]
        [Route("GetAuthorize")]
        public IActionResult GetAuthorize()
        {

            return Ok("Hello Authorize");
        }

        [Authorize(Roles = nameof(UserRoles.Admin))]
        [HttpGet]
        [Route("GetAdmin")]
        public IActionResult GetAdmin()
        {

            return Ok("Hello Admin");
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant_Backend.Business;
using Resturant_Backend.DataAccess.Models.Auth;

namespace Resturant_Backend.API.Controllers
{
    [ApiController]
    [Route("api/Dashboard")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
       

        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
           
        }
       
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {

            return Ok("hello");
        }

        [HttpGet]
        [Route("Get_CreditAndBalance")]
        public IActionResult Get_CreditAndBalance()
        {

            return Ok("hello");
        }

    }
}
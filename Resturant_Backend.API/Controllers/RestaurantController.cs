using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Resturant_Backend.Business;

using Resturant_Backend.DataAccess.Models.Auth;
using Resturant_Backend.Domain.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Resturant_Backend.API.Controllers
{
    [ApiController]
    [Route("api/Restaurant")]
    //[Authorize]
    [EnableCors("AllowClientOrigin")]
    public class RestaurantController : ControllerBase
    {


        private readonly ILogger<DashboardController> _logger;
        private readonly IRestaurantService _restaurant;

        public RestaurantController(ILogger<DashboardController> logger, IRestaurantService restaurant)
        {
            _logger = logger;
            _restaurant = restaurant;
        }
        #region Gets
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var result = _restaurant.GetAllRestaurantAsync();
            return new OkObjectResult(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
        [Route("Get_Id")]
        public async Task<IActionResult> Get_Id(string restaurantId)
        {

            var result = await _restaurant.Get_RestaurantByIdAsync(restaurantId);
            return new OkObjectResult(JsonConvert.SerializeObject(result));
        }
        [HttpGet]
        [Route("Get_RestaurantName")]
        public async Task<IActionResult> Get_RestaurantName(string restaurantName)
        {

            var result = await _restaurant.Get_RestaurantByNameAsync(restaurantName);
            return new OkObjectResult(JsonConvert.SerializeObject(result));
        }
        #endregion  Gets

        #region Posts
        [HttpPost]
        [Route("AddNewRestaurant")]
        public async Task<IActionResult> AddNewRestaurant([FromBody] RestaurantDTO model)
        {
           await  _restaurant.CreateRestaurantAsync(model);
            return Ok();
        }
        #endregion Posts

    }
}
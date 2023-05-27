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
    [Route("api/Factor")]
    //[Authorize]
    [EnableCors("AllowClientOrigin")]
    public class FactorController : ControllerBase
    {


        private readonly ILogger<FactorController> _logger;
        private readonly IFactorService _Factor;

        public FactorController(ILogger<FactorController> logger, IFactorService Factor)
        {
            _logger = logger;
            _Factor = Factor;
        }

        #region Gets
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var result = _Factor.GetAllFactorAsync();
            return new OkObjectResult(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
        [Route("Get_Id")]
        public async Task<IActionResult> Get_Id(string FactorId)
        {

            var result = await _Factor.Get_FactorByIdAsync(FactorId);
            return new OkObjectResult(JsonConvert.SerializeObject(result));
        }
        [HttpGet]
        [Route("Get_FactorNumber")]
        public async Task<IActionResult> Get_FactorName(string FactorNumber)
        {

            var result = await _Factor.Get_FactorByFactorNumberAsync(FactorNumber);
            return new OkObjectResult(JsonConvert.SerializeObject(result));
        }
        #endregion  Gets

        #region Posts
        [HttpPost]
        [Route("AddNewFactor")]
        public async Task<IActionResult> AddNewFactor([FromBody] FactorDTO model)
        {
           await  _Factor.CreateFactorAsync(model);
            return new OkObjectResult(JsonConvert.SerializeObject(model));
        }
        #endregion Posts

        #region Puts

        [HttpPut]
        [Route("UpdateFactor")]
        public async Task<IActionResult> UpdateFactor([FromBody] FactorDTO model)
        {
            await _Factor.UpdateFactorAsync(model);
            return new OkObjectResult(JsonConvert.SerializeObject(model));
        }

        #endregion Puts

    }
}
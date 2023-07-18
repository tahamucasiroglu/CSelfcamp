using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeDersinV2.API.Controllers.Base;
using NeDersinV2.API.HateoasModels;
using NeDersinV2.API.Models;
using NeDersinV2.Extensions;

namespace NeDersinV2.API.Controllers
{
    [Route("/")]
    [ApiController]
    public class PingController : CustomBaseController
    {
        public PingController(HateoasModel hateoasModel, ILogger<ControllerBase> logger) : base(hateoasModel, logger)
        {
        }
        [Route("ping")]
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("{}");

        }
    }
}

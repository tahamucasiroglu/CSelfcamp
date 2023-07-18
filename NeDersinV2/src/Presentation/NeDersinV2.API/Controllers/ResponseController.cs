using Microsoft.AspNetCore.Mvc;
using NeDersinV2.Abstracts.Service;
using NeDersinV2.API.Controllers.Base;
using NeDersinV2.API.Filters;
using NeDersinV2.API.HateoasModels;
using NeDersinV2.API.StaticMethods;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels;
using NeDersinV2.DTOs.ViewModels.Response;
using NeDersinV2.Returns.Abstract;

namespace NeDersinV2.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ResponseController : CustomBaseController<VM_Create_Response, GetResponseDTO>
    {
        private readonly IResponseService responseService;
        public ResponseController(IResponseService responseService, HateoasModel hateoasModel, ILogger<ControllerBase> logger) : base(responseService, hateoasModel, logger)
        {
            this.responseService = responseService;
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public IActionResult GetById([FromBody] VM_IntValue Value)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<VM_IntValue>(nameof(GetById));

            IReturnModel<GetResponseDTO> result = responseService.GetById(Value.Value);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public IActionResult GetByQuestionId([FromBody] VM_IntValue Value)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<VM_IntValue>(nameof(GetByQuestionId));
            IReturnModel<IEnumerable<GetResponseDTO>> result = responseService.GetByQuestionId(Value.Value);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public IActionResult GetByUserId([FromBody] VM_IntValue Value)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<VM_IntValue>(nameof(GetByUserId));
            IReturnModel<IEnumerable<GetResponseDTO>> result = responseService.GetByUserId(Value.Value);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }


    }
}

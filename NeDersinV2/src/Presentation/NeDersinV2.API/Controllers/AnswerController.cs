using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeDersinV2.Abstracts.Service;
using NeDersinV2.API.Controllers.Base;
using NeDersinV2.API.Filters;
using NeDersinV2.API.HateoasModels;
using NeDersinV2.API.StaticMethods;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels;
using NeDersinV2.DTOs.ViewModels.Answer;
using NeDersinV2.Returns.Abstract;

namespace NeDersinV2.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AnswerController : CustomBaseController<VM_Create_Answer, VM_Update_Answer, GetAnswerDTO>
    {
        private readonly IAnswerService answerService;

        public AnswerController(IAnswerService answerService, HateoasModel hateoasModel, ILogger<AnswerController> logger) : base(answerService, hateoasModel, logger)
        {
            this.answerService = answerService;
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        //[Authorize]
        public IActionResult GetsByQuestionId([FromBody] VM_IntValue Value)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<VM_IntValue>(nameof(GetsByQuestionId));

            IReturnModel<IEnumerable<GetAnswerDTO>> result = answerService.GetByQuestionId(Value.Value);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);

        }
    }
}

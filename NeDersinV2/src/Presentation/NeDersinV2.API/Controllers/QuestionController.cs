using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeDersinV2.Abstracts.Service;
using NeDersinV2.API.Controllers.Base;
using NeDersinV2.API.Filters;
using NeDersinV2.API.HateoasModels;
using NeDersinV2.API.StaticMethods;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels;
using NeDersinV2.DTOs.ViewModels.Question;

namespace NeDersinV2.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class QuestionController : CustomBaseController<VM_Create_Question, VM_Update_Question, GetQuestionDTO>
    {
        private readonly IQuestionService questionService;
        public QuestionController(IQuestionService questionService, HateoasModel hateoasModel, ILogger<QuestionController> logger) : base(questionService, hateoasModel, logger)
        {
            this.questionService = questionService;
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public IActionResult GetById([FromBody] VM_IntValue Value)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<VM_IntValue>(nameof(GetById));
            var result = questionService.GetById(Value.Value);

            LogResultError(result);

            return StaticHelperMethods.SolveResult(result, hateoasModel);

        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public IActionResult GetBySurveyId([FromBody] VM_IntValue Value)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<VM_IntValue>(nameof(GetBySurveyId));
            var result = questionService.GetsBySurveyId(Value.Value);

            LogResultError(result);

            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }

    }
}

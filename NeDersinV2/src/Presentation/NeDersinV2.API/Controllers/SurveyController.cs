using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeDersinV2.Abstracts.Service;
using NeDersinV2.Abstracts.Service.Base;
using NeDersinV2.API.Controllers.Base;
using NeDersinV2.API.Filters;
using NeDersinV2.API.HateoasModels;
using NeDersinV2.API.StaticMethods;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels;
using NeDersinV2.DTOs.ViewModels.Question;
using NeDersinV2.DTOs.ViewModels.Survey;

namespace NeDersinV2.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class SurveyController : CustomBaseController<VM_Create_Survey, VM_Update_Survey, GetSurveyDTO>
    {
        private readonly ISurveyService surveyService;

        public SurveyController(ISurveyService surveyService, HateoasModel hateoasModel, ILogger<ControllerBase> logger) : base(surveyService, hateoasModel, logger)
        {
            this.surveyService = surveyService;
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        //[Authorize]
        public IActionResult GetSurveyById([FromBody] VM_IntValue Value)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<VM_IntValue>(nameof(GetSurveyById));

            var result = surveyService.GetById(Value.Value);

            LogResultError(result);

            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        //[Authorize]
        public IActionResult GetSurveysForPage([FromBody] VM_IntValue Value)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<VM_IntValue>(nameof(GetSurveyById));

            var result = surveyService.GetById(Value.Value);

            LogResultError(result);

            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }




    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeDersinV2.Abstracts.Service;
using NeDersinV2.Abstracts.Service.Base;
using NeDersinV2.API.Controllers.Base;
using NeDersinV2.API.HateoasModels;
using NeDersinV2.API.StaticMethods;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels;
using NeDersinV2.DTOs.ViewModels.SurveyRating;

namespace NeDersinV2.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class SurveyRatingController : CustomBaseController<VM_Create_SurveyRating, GetSurveyRatingDTO>
    {
        private readonly ISurveyRatingService surveyRatingService;
        public SurveyRatingController(ISurveyRatingService surveyRatingService, HateoasModel hateoasModel, ILogger<ControllerBase> logger) : base(surveyRatingService, hateoasModel, logger)
        {
            this.surveyRatingService = surveyRatingService;
        }
        [HttpGet("[action]")]
        public IActionResult GetBySurveyId([FromBody] VM_IntValue Value)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<VM_IntValue>(nameof(GetBySurveyId));
            var result = surveyRatingService.GetsBySurveyId(Value.Value);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }
        [HttpGet("[action]")]
        public IActionResult GetByUserId([FromBody] VM_IntValue Value)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<VM_IntValue>(nameof(GetByUserId));
            var result = surveyRatingService.GetsByUserId(Value.Value);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }
        [HttpGet("[action]")]
        public IActionResult GetByRating([FromBody] VM_IntValue Value)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<VM_IntValue>(nameof(GetByRating));
            var result = surveyRatingService.GetsByRating(Value.Value);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }
    }
}

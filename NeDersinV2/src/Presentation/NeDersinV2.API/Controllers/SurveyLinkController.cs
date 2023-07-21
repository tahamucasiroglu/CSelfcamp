using Microsoft.AspNetCore.Mvc;
using NeDersinV2.Abstracts.Service;
using NeDersinV2.API.Controllers.Base;
using NeDersinV2.API.Filters;
using NeDersinV2.API.HateoasModels;
using NeDersinV2.API.StaticMethods;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels;
using NeDersinV2.Returns.Abstract;

namespace NeDersinV2.API.Controllers
{
    [Route("/")]
    [ApiController]
    public class SurveyLinkController : CustomBaseController
    {
        private readonly ISurveyService surveyService;
        public SurveyLinkController(ISurveyService surveyService, HateoasModel hateoasModel, ILogger<ControllerBase> logger) : base(hateoasModel, logger)
        {
            this.surveyService = surveyService;
        }

        [HttpGet]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public IActionResult GetSurveyById([FromBody] VM_GuidValue Value)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<VM_GuidValue>(nameof(GetSurveyById));

            var result = surveyService.GetByAddress(Value.Value);

            LogResultError(result);

            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public IActionResult Page([FromBody] VM_PageValue Value)
        {
            Console.WriteLine(Value.ToString());
            if (!ModelState.IsValid) return ModelStateNonValid<VM_GuidValue>(nameof(Page));

            IReturnModel<GetSurveyPaginationDTO> result = surveyService.GetByPagination(Value.pageNumber, Value.pageSize, Value.order, Value.shortType);
            Console.WriteLine(result.Data?.SurveyList.ToList().Count);
            LogResultError(result);

            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }



    }
}

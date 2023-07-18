using Microsoft.AspNetCore.Mvc;
using NeDersinV2.Abstracts.Service;
using NeDersinV2.API.Controllers.Base;
using NeDersinV2.API.HateoasModels;
using NeDersinV2.API.StaticMethods;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels;
using NeDersinV2.DTOs.ViewModels.User;
using NeDersinV2.Returns.Abstract;

namespace NeDersinV2.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController<VM_Create_User, VM_Update_User, GetUserDTO>
    {
        private readonly IUserService userService; 
        public UserController(IUserService userService, HateoasModel hateoasModel, ILogger<ControllerBase> logger) : base(userService, hateoasModel, logger)
        {
            this.userService = userService;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetById([FromBody] VM_IntValue Value)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<VM_IntValue>(nameof(GetById));
            IReturnModel<GetUserDTO> result = await userService.GetByIdAsync(Value.Value);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetsByName([FromBody] VM_StringValue Value)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<VM_IntValue>(nameof(GetsByName));
            IReturnModel<IEnumerable<GetUserDTO>> result = await userService.GetByNameAsync(Value.Value);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }




    }
}

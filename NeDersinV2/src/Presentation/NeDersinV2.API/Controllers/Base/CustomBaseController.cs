using Microsoft.AspNetCore.Mvc;
using NeDersinV2.API.HateoasModels;
using NeDersinV2.API.StaticMethods;
using NeDersinV2.DTOs.Abstract;
using NeDersinV2.Extensions;
using NeDersinV2.Returns.Abstract;
using NeDersinV2.Abstracts.Service.Base;
using Microsoft.AspNetCore.Authorization;
using NeDersinV2.DTOs.ViewModels;

namespace NeDersinV2.API.Controllers.Base
{
    public class CustomBaseController<TAdd, TUpdate, TGet> : CustomBaseController<TAdd, TGet>
        where TGet : class, IGetDTO, new()
        where TAdd : class, I_VM_Create, new()
        where TUpdate : class, I_VM_Update, new()
    {
        internal readonly new IService<TGet, TAdd, TUpdate> service;

        public CustomBaseController(IService<TGet, TAdd, TUpdate> service, HateoasModel hateoasModel, ILogger<ControllerBase> logger) : base(service, hateoasModel, logger)
        {
            this.service = service;
        }

        [HttpPut("[action]")]
        //[Authorize]
        public virtual IActionResult Update([FromBody] TUpdate entry)
        {
            if (!ModelState.IsValid)
            {
                LogModelState(entry, "Güncelleme");
                return StaticHelperMethods.ReturnError<TUpdate>(ModelState, hateoasModel);
            }

            IReturnModel<TGet> result = service.Update(entry);

            LogResultError(result);

            return StaticHelperMethods.SolveResult<TGet, TUpdate>(result, hateoasModel);
        }
    }

    public class CustomBaseController<TAdd, TGet> : BaseControllerCore
        where TGet : class, IGetDTO, new()
        where TAdd : class, I_VM_Create, new()
    {
        internal readonly IService<TGet, TAdd> service;

        public CustomBaseController(IService<TGet, TAdd> service, HateoasModel hateoasModel, ILogger<ControllerBase> logger) : base(hateoasModel, logger)
        {
            this.service = service;
        }

        [HttpPost("[action]")]
        //[Authorize]

        public virtual IActionResult Add([FromBody] TAdd entry)
        {
            if (!ModelState.IsValid)
            {
                LogModelState(entry, "Ekleme");
                return StaticHelperMethods.ReturnError<TAdd>(ModelState, hateoasModel);
            }

            IReturnModel<TGet> result = service.Add(entry);

            LogResultError(result);

            return StaticHelperMethods.SolveResult<TGet, TAdd>(result, hateoasModel);
        }

        [HttpDelete("[action]")]
        //[Authorize]
        public virtual IActionResult Delete([FromBody] VM_IntValue entry)
        {
            if (!ModelState.IsValid)
            {
                LogModelState(entry, "Silme");
                return StaticHelperMethods.ReturnError<TGet>(ModelState, hateoasModel);
            }


            IReturnModel<TGet> result = service.Delete(entry.Value);

            LogResultError(result);

            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }
    }
    public class CustomBaseController : BaseControllerCore
    {

        public CustomBaseController(HateoasModel hateoasModel, ILogger<ControllerBase> logger) : base(hateoasModel, logger)
        {
        }



    }




    public class BaseControllerCore : ControllerBase, IBaseController
    {
        internal readonly ILogger<ControllerBase> logger;
        internal readonly HateoasModel hateoasModel;

        public BaseControllerCore(HateoasModel hateoasModel, ILogger<ControllerBase> logger)
        {
            this.hateoasModel = hateoasModel;
            this.logger = logger;
        }
        public virtual void LogModelState<TLog>(TLog value)
            => logger.LogError($"{typeof(TLog).Name} tarafından yapılan işlemde istek ModelState'e takıldı.\nİstek = {value.ToJson()}");
        public virtual void LogModelState<TLog>()
           => logger.LogError($"{typeof(TLog).Name} tarafından yapılan işlemde istek ModelState'e takıldı.\nİstek = Null");
        public virtual void LogModelState<TLog>(TLog value, string MethodName)
           => logger.LogError($"{typeof(TLog).Name} tarafından yapılan {MethodName} işleminde istek ModelState'e takıldı.\nİstek = {value?.ToJson()}");
        public virtual void LogModelState<TLog>(string MethodName)
           => logger.LogError($"{typeof(TLog).Name} tarafından yapılan {MethodName} işleminde istek ModelState'e takıldı.\nİstek = Null");
        /// <summary>
        /// Eğer Status false veya data null ise hata loglar ayrıca false döner
        /// </summary>
        /// <typeparam name="TLog"></typeparam>
        /// <param name="result"></param>
        public virtual bool LogResultError<TLog>(IReturnModel<TLog> result)
        {
            if (!result.Status || result.Data == null)
            {
                string message = "";
                message += $" Status = {result.Status} \n";
                message += $" Data is Null = {result.Data == null} \n";
                message += $" Data Type Name = {result.Data?.GetType().Name} \n";
                message += $" Exception = {result.Exception?.Message} \n";
                message += $" Data = {result.Data?.ToJson()} \n";
                logger.LogError(message);
                return false;
            }
            return true;
        }


        public virtual BadRequestObjectResult ModelStateNonValid<TLog>(string methodName)
        {
            LogModelState<TLog>(methodName);
            return StaticHelperMethods.ReturnError<TLog>(ModelState, hateoasModel);
        }
    }
}

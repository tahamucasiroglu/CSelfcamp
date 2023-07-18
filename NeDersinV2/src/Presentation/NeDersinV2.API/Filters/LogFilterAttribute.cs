using Microsoft.AspNetCore.Mvc.Filters;
using NeDersinV2.Extensions;

namespace NeDersinV2.API.Filters
{
    public class LogFilterAttribute : ActionFilterAttribute // istenilen yerde istekleri basar
    {
        private readonly ILogger<LogFilterAttribute> logger;

        public LogFilterAttribute(ILogger<LogFilterAttribute> logger)
        {
            this.logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string message = "";
            message += $" Host = {context.HttpContext.Request.Host.Host} \n";
            message += $" Port = {context.HttpContext.Request.Host.Port} \n";
            message += $" Response Code = {context.HttpContext.Response.StatusCode} \n";
            message += $" Controller = {context.Controller.GetType().Name} \n";
            message += $" ModelState.IsValid = {context.ModelState.IsValid} \n";
            message += $" RouteData Values = {context.RouteData.Values} \n";
            message += $" User Identity = {context.HttpContext.User.Identity} \n";
            message += $" User Identity = {context.HttpContext.User.Identities.Select(u => u.Name + " - " + u.Label + " - " + u.NameClaimType.ToString()).ToJson()} \n";
            message += $" Body = {context.RouteData.Values.ToJson()} \n";
            message += $" Body Json = \n";
            message += context.ActionArguments.ToJson();
            logger.LogInformation(message);
        }
    }
}

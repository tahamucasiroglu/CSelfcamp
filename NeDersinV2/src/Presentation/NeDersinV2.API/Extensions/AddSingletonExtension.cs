using NeDersinV2.Abstracts.Service.Base;
using NeDersinV2.API.Filters;
using NeDersinV2.API.HateoasModels;

namespace NeDersinV2.API.Extensions
{
    static public class AddSingletonExtension
    {
        public static void AddSingleton(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<HateoasModel>();
            builder.Services.AddSingleton<LogFilterAttribute>();
        }
    }
}

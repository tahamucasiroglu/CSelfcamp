using Microsoft.EntityFrameworkCore;
using NeDersinV2.Infrasructure.Contexts;

namespace NeDersinV2.API.Extensions
{
    static public class AddDbExtension
    {
        public static void AddDb(this WebApplicationBuilder builder)
        {
            string? connectionString = builder.Configuration.GetConnectionString("NeDersinV2Context");
            builder.Services.AddDbContext<NeDersinV2Context>(opt =>
            {
                opt.UseSqlServer(connectionString);
                opt.UseLoggerFactory(LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                    builder.SetMinimumLevel(LogLevel.Warning); //açılıştaki bir sürü konsol çıktısını önlemek için
                }));
            });
        }
    }
}

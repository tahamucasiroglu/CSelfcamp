
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NeDersinV2.Abstracts.Repository;
using NeDersinV2.Abstracts.Service;
using NeDersinV2.API.Extensions;
using NeDersinV2.API.HateoasModels;
using NeDersinV2.Constants.Const;
using NeDersinV2.Entities.Concrete;
using NeDersinV2.Extensions;
using NeDersinV2.Infrasructure.Contexts;
using NeDersinV2.Infrasructure.Repository.EfCore;
using NeDersinV2.Mapper;
using NeDersinV2.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine(UserStatusConst.Admin);


        var builder = WebApplication.CreateBuilder(args);

        builder.AddDb(); //Extension

        builder.Services.AddAutoMapper(typeof(MapProfile));

        builder.AddScoped(); //Extension

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        //await app.Seeding(); //Extension







        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    


}
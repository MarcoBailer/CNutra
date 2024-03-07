using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Nutricao.Core.Dtos.Context;
using Nutricao.Core.Interfaces;
using Nutricao.Core.Service;
using Nutricao.Core.Service.Api;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Db
        builder.Services.AddDbContext<RefeicaoContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("refeicao");
            options.UseSqlServer(connectionString);
        });
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //Config Api
        builder.Services.AddSingleton(provider =>
        {
            var apiKey = builder.Configuration["FoodDataCentralApiKey"];
            return new FoodDataCentralApiConnection(apiKey);
        });

        // Inject app Dependencies (Dependency Injection)
        builder.Services.AddScoped<IFoodInfomation, FoodInformationService>();
        builder.Services.AddScoped<IFoodCalc, FoodCalcService>();

        var app = builder.Build();


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
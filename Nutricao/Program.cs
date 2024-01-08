using Microsoft.OpenApi.Models;
using Nutricao.Core.Interfaces;
using Nutricao.Core.Service;
using Nutricao.Core.Service.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Config Api
builder.Services.AddSingleton<FoodDataCentralApiService>(provider =>
{
    var apiKey = builder.Configuration["FoodDataCentralApiKey"];
    var dataType = builder.Configuration["dataType"];
    return new FoodDataCentralApiService(apiKey,dataType);
});

// Inject app Dependencies (Dependency Injection)
builder.Services.AddScoped<IFoodInfomation, FoodInformation>();

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

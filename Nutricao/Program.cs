using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Nutricao.Core.Dtos.Context;
using Nutricao.Core.Interfaces;
using Nutricao.Core.Service;
using Nutricao.Core.Service.Api;
using System.Text;

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
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Description = "Por favor insira seu token no formato : 'Bearer SEU_TOKEN'",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new List<string>()
                }
            });
        });

        //Config Api
        //builder.Services.AddSingleton(provider =>
        //{
        //    var apiKey = builder.Configuration["FoodDataCentralApiKey"];
        //    return new FoodDataCentralApiConnection(apiKey);
        //});

        // Inject app Dependencies (Dependency Injection)
        builder.Services.AddScoped<IFoodInfomation, FoodInformationService>();
        builder.Services.AddScoped<IFoodCalc, FoodCalcService>();
        builder.Services.AddScoped<IUsuario, UsuarioService>();
        builder.Services.AddSingleton(provider =>
        {
            return new FoodDataCentralApiConnection();
        });

        // Add Authentication and JwtBearer
        builder.Services
            .AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                };
            });

        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(options =>
        {
            options
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
        });

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
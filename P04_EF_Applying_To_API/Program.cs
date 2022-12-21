using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using P04_EF_Applying_To_API.Data;
using P04_EF_Applying_To_API.Repository;
using P04_EF_Applying_To_API.Repository.IRepository;
using P04_EF_Applying_To_API.Services;
using P04_EF_Applying_To_API.Services.Adapters;
using P04_EF_Applying_To_API.Services.Adapters.IAdapters;
using P04_EF_Applying_To_API.Services.IServices;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace P04_EF_Applying_To_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<RestaurantContext>(option =>
            {
                option.UseSqlite(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
                option.UseLazyLoadingProxies();
            });
            builder.Services.AddScoped<IDishRepository, DishRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IDishOrderRepository, DishOrderRepository>();
            builder.Services.AddScoped<IPasswordService, PasswordService>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddTransient<IDishOrderAdapter, DishOrderAdapter>();
            builder.Services.AddTransient<IDishAdapter, DishAdapter>();
            builder.Services.AddTransient<ICookingService, CookingService>();

            var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            builder.Services.AddControllers()
                .AddNewtonsoftJson()
                .AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath);

                // This is added to show JWT UI part in Swagger
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description =
                        "JWT Authorization header is using Bearer scheme. \r\n\r\n" +
                        "Enter 'Bearer' and token separated by a space. \r\n\r\n" +
                        "Example: \"Bearer d5f41g85d1f52a\"",
                    Name = "Authorization", // Header key name
                    In = ParameterLocation.Header,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); // Order matters
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
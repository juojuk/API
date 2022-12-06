using CarApiAiskinimas.Database;
using CarApiAiskinimas.Models;
using CarApiAiskinimas.Repositories;
using CarApiAiskinimas.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CarApiAiskinimas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<CarContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("CarConnectionString"));
            });

            builder.Services.AddTransient<ICarRepository, CarRepository>();
            builder.Services.AddTransient<ICarAdapter, CarAdapter>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });

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
}
using API_mokymai.Data;
using API_mokymai.Repository;
using API_mokymai.Repository.IRepository;
using API_mokymai.Services;
using API_mokymai.Services.IServices;
using API_mokymai.Services.XServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace API_mokymai
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            // Add services to the container.

            //builder.Services.AddTransient<IOperationTransient, GuidService>();
            //builder.Services.AddScoped<IOperationScoped, GuidService>();
            //builder.Services.AddSingleton<IOperationSingleton, GuidService>();
            //builder.Services.AddSingleton<IBookSet, BookSet>();
            builder.Services.AddTransient<IBookWrapper, BookWrapper>();
            builder.Services.AddTransient<IBookManager, BookManager>();
            //builder.Services.AddTransient<IBadService, BadService>();
            //builder.Services.AddTransient<IDalybaService, DalybaService>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IMeasureRepository, MeasureRepository>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<IShippingOrderRepository, ShippingOrderRepository>();
            builder.Services.AddScoped<IShippingPriceRepo, ShippingPriceRepo>();
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPasswordService, PasswordService>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddHttpClient("FakeApi", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ExternalServices:FakeApiUri"]);
                client.Timeout = TimeSpan.FromSeconds(10);
                client.DefaultRequestHeaders.Clear();
            });
            builder.Services.AddTransient<IFakeApiProxyService, FakeApiProxyService>();

            builder.Services.AddHttpClient("OpenRouteServiceGeocodeSearchApi", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ExternalServices:OpenRouteServiceGeocodeSearchUri"]);
                client.Timeout = TimeSpan.FromSeconds(10);
                client.DefaultRequestHeaders.Clear();
            });
            builder.Services.AddHttpClient("OpenRouteServiceDirectionsApi", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ExternalServices:OpenRouteServiceDirectionsUri"]);
                client.Timeout = TimeSpan.FromSeconds(10);
                client.DefaultRequestHeaders.Clear();
            });

            builder.Services.AddTransient<IOpenRouteService, OpenRouteService>();

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


            builder.Services.AddDbContext<BookContext>(option =>
            {
                option.UseSqlite(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
                option.UseLazyLoadingProxies();
            });


            builder.Services.AddControllers()
                .AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                //.AddNewtonsoftJson()
                .AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);




            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath);

                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description =
                        "JWT Authorization header is using Bearer scheme. \r\n\r\n" +
                        "Enter 'Bearer' and token separated by a space. \r\n\r\n" +
                        "Example: \"Bearer d5f41g85d1f52a\"",
                    Name = "Authorization",
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


            builder.Services.AddCors(p => p.AddPolicy("corsforlibrary", builder =>
            {
                builder.WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("corsforlibrary");
            app.UseHttpsRedirection();

            app.UseAuthentication(); //Order matters
            app.UseAuthorization();


            app.MapControllers();
            app.UseCors();

            app.Run();
        }
    }
}
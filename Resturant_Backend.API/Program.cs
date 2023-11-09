
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Resturant_Backend.Business;
using Resturant_Backend.DataAccess.Factory;
using Resturant_Backend.DataAccess.Repository;
using Resturant_Backend.Domain.DbContexts;
using Resturant_Backend.Domain.Entities;
using System.Text;
using System.Text.Json.Serialization;

namespace Resturant_Backend.API
{
    public class Program
    {
        //    public  string AllowOrigin = "AllowClientOrigin";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //Add Cross Origin Resource Sharing Support
            builder.Services.AddCors((cors) =>
            {
                cors.AddPolicy("AllowClientOrigin", policy => policy

               .WithMethods("GET", "POST", "PUT", "DELETE")
               //.WithOrigins("http://200.200.200.185:3000")
               //.SetIsOriginAllowed(origin => true) // allow any origin
               .AllowAnyOrigin()
                //.AllowAnyMethod()
                .AllowAnyHeader()
                //.AllowCredentials()
                );
            });





            // Add services to the container.
            builder.Services.AddControllers()
                .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test01", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
            });
            builder.Services.AddHttpClient();
            builder.Services.AddMvc();

            #region Authorization

            // Database & Authorization
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
               // options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDatabase"));
                options.UseMongoDB(builder.Configuration.GetConnectionString("MONGODatabase"),"Restaurant");
            });
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = true; // on production add more secured options
                options.Password.RequireDigit = true;

                options.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();

            // Adding Authentication  
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
            {
                var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, // on production make it true
                    ValidateAudience = false, // on production make it true
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Key),
                    ClockSkew = TimeSpan.Zero
                };
                o.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {

                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
                        }
                        return Task.CompletedTask;
                    }
                    //,
                    //OnMessageReceived = context =>
                    //{

                    //    if (context.Request.Cookies.ContainsKey("X-Access-Token"))
                    //    {
                    //        context.Token = context.Request.Cookies["X-Access-Token"];
                    //    }

                    //    return Task.CompletedTask;
                    //}
                };
            });


            builder.Services.AddSingleton<IJWTManagerRepository, JWTManagerRepository>();
            builder.Services.AddScoped<IUserServiceRepository, UserServiceRepository>();

            #endregion Authorization




            //Restaurant
            builder.Services.AddScoped<IRestaurantManagementRepository, RestaurantManagementRepository>();
            builder.Services.AddScoped<RestaurantFactory>();
            builder.Services.AddScoped<IRestaurantService, RestaurantService>();

            //Factor
            builder.Services.AddScoped<IFactorRepository, FactorRepository>();
            builder.Services.AddScoped<FactorFactory>();
            builder.Services.AddScoped<IFactorService, FactorService>();







            //  builder.Services.AddSingleton<IRestaurantService, RestaurantService>();
            //builder.Services.AddScoped<IUserManagerService, UserManagerService>();
            //  builder.Services.AddScoped<UserManager<ApplicationUser>, UserManager<ApplicationUser>>();
            //builder.Services.AddScoped<IUserManagerRepository, UserManagerRepository>();
            //builder.Services.AddScoped<IUserService, UserService>();



            /*builder.Services.AddGraphQL().AddSystemTextJson()*/


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");

                    // Provide client ID, client secret, realm and application name (if need)

                    // Swashbuckle.AspNetCore 4.0.1
                    c.OAuthClientId("swagger-ui");
                    c.OAuthClientSecret("swagger-ui-secret");
                    c.OAuthRealm("swagger-ui-realm");
                    c.OAuthAppName("Swagger UI");

                    // Swashbuckle.AspNetCore 1.1.0
                    // c.ConfigureOAuth2("swagger-ui", "swagger-ui-secret", "swagger-ui-realm", "Swagger UI");
                });
            }
            app.UseCors("AllowClientOrigin");
            //  app.UseHttpsRedirection();
            app.UseGraphQLGraphiQL("/ui/graphql");

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();


        }
    }
}
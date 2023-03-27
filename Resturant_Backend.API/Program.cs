
using Resturant_Backend.Domain.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using GraphQL.Server;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Resturant_Backend.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers()
                .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDatabase"));
            });

            /*builder.Services.AddGraphQL().AddSystemTextJson()*/;

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
          
            app.UseHttpsRedirection();
            app.UseGraphQLGraphiQL("/ui/graphql");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
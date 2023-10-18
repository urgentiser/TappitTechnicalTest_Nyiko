using Tappit.Application;
using System.Text.Json.Serialization;
using Tappit.Infrastructure;

namespace Tappit.WebApi
{
    public class Program
    {
        public static readonly string CORSOpenPolicy = "OpenCORSPolicy";
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);

            // Application Layer and Infrastructure Layer DI
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                  name: CORSOpenPolicy,
                  builder => {
                      builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                  });
            });

            builder.Services.AddMvc().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.DisplayRequestDuration());
            app.UseCors(CORSOpenPolicy);
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}


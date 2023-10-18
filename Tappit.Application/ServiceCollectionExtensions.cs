using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Tappit.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assemby = Assembly.GetExecutingAssembly();

            return services
                .AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssemblies(assemby);
                })
                .AddAutoMapper(assemby)
                .AddValidatorsFromAssembly(assemby);
        }
    }
}

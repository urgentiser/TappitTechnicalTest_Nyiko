using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tappit.Application.Repositories;
using Tappit.Infrastructure.Context;
using Tappit.Infrastructure.Repositories;

namespace Tappit.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddTransient<IPersonRepository, PersonRepository>()
                .AddTransient<ISportRepository, SportRepository>()
                .AddTransient<IFavouriteSportRepository, FavouriteSportRepository>()
                .AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}

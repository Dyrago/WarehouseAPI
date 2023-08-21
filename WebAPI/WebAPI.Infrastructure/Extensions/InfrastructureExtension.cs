using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Repositories;
using WebAPI.Infrastructure.Data;
using WebAPI.Infrastructure.Repositories;
using WebAPI.Infrastructure.Seeders;

namespace WebAPI.Infrastructure.Extensions
{
    public static class InfrastructureExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WebAPIDBContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("APIDBConnection")));

            services.AddTransient<Seeder>();
            services.AddScoped<IRepository<Item>, ItemRepository>();
        }
    }
}

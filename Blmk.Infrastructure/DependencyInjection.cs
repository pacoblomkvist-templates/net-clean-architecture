using Blmk.Application.Common.Interfaces;
using Blmk.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blmk.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<AlephDbContext>(options =>
                    options.UseInMemoryDatabase("CleanArchitectureDb"));
            }
            else
            {
                services.AddDbContext<AlephDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AlephDbConnection"),
                    builder => builder.MigrationsAssembly(typeof(AlephDbContext).Assembly.FullName)));
            }
            services.AddScoped<IAlephDbContext>(provider => provider.GetRequiredService<AlephDbContext>());

            //services.addAuth etc

            return services;

        }
    }
}
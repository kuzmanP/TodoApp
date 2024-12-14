using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using Services.Interfaces;
using Repository.Providers;
using Services.Providers;

namespace ServiceExtensions
{

    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            //services.AddSingleton<ILoggerManager, LoggerManager>();
        }


        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();


        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();


        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("TodoAppAPIDbConnectionString")));
        }


    }
}

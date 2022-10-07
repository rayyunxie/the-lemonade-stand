using Microsoft.EntityFrameworkCore;
using tls.api.DataTransfer;
using tls.api.Repositories;
using tls.api.Service;

namespace tls.api.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services, string policyName) =>
            services.AddCors(options =>
            {
                options.AddPolicy(policyName, builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, string sqlConnectionString) =>
            services.AddDbContext<RepositoryContext>(opts =>
                opts.UseSqlServer(sqlConnectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        public static void AddAutoMapper(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(DtoMappingProfile));

        public static void AddAppOptions(this IServiceCollection services, IConfigurationSection appConfigSection) =>
            services.Configure<AppOptions>(appConfigSection);
    }
}

using Microsoft.AspNetCore.HttpOverrides;
using System.Text.Json.Serialization;
using tls.api.Extensions;

namespace tls.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add application options early so that we can use IOptions with DI in other extension methods
            var appSection = builder.Configuration.GetSection(Constants.ConfigSection);
            builder.Services.AddAppOptions(appSection);
            var appOptions = new AppOptions();
            builder.Configuration.Bind(Constants.ConfigSection, appOptions);

            // Add services
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureServiceManager();

            // Sql context
            builder.Services.ConfigureSqlContext(appOptions.SqlConnection!);

            // Auto mapper
            builder.Services.AddAutoMapper();

            // Cors
            builder.Services.ConfigureCors(Constants.CorsPolicyName);

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition =
                    JsonIgnoreCondition.WhenWritingNull;
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.ConfigureExceptionHandler();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHsts();

            app.UseHttpsRedirection();

            // Enables static file serving for the current request path
            app.UseStaticFiles();

            // Forwards proxy headers to the current request
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseCors(Constants.CorsPolicyName);

            app.UseAuthorization();
            app.MapControllers();

            app.ApplyPendingMigrations();

            app.Run();
        }
    }
}
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using tls.api.Errors;
using tls.api.Repositories;

namespace tls.api.Extensions
{
    public static class AppExtension
    {
        public static void ApplyPendingMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
            if (!db.Database.IsInMemory() && !db.Database.EnsureCreated())
            {
                db.Database.Migrate();
            }
        }

        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    // Need to specify content type here
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        string name = contextFeature.Error is BaseException baseException ?
                            baseException.Name : string.Empty;

                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException e => StatusCodes.Status404NotFound,
                            BadRequestException e => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError,
                        };

                        // for security reasons, only send internal error message if in
                        // development, otherwise send a generic error message, 'Internal Server Error' 
                        string message = !app.Environment.IsDevelopment() &&
                            context.Response.StatusCode == StatusCodes.Status500InternalServerError ?
                            "Internal Server Error" : contextFeature.Error.Message;

                        await context.Response.WriteAsync(new ErrorDetails(
                            context.Response.StatusCode, name, message).ToString());
                    }
                });
            });
        }
    }
}

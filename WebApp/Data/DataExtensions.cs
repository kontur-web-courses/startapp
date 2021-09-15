using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace WebApp.Data
{
    public static class DataExtensions
    {
        public static void PrepareDB(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
                    var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                    if (env.IsDevelopment()
                        && string.IsNullOrEmpty(configuration.GetConnectionString("SqlServerConnection")))
                    {
                        scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
                    }
                }
                catch (Exception e)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "An error occurred while migrating or seeding the database.");
                }
            }
        }
    }
}

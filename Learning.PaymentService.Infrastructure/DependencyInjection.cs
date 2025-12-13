using Learning.PaymentService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Learning.PaymentService.Infrastructure
{
    /// <summary>
    /// adds infrastructure services to the service collection.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Parse DATABASE_URL for EF Core (handles Render's format)
            // Render sets DATABASE_URL as an environment variable - check it FIRST before appsettings
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

            if (!string.IsNullOrEmpty(databaseUrl) && databaseUrl.StartsWith("postgresql://"))
            {
                try
                {
                    var url = new Uri(databaseUrl);
                    var userInfo = url.UserInfo.Split(':');
                    var connectionString = new NpgsqlConnectionStringBuilder
                    {
                        Host = url.Host,
                        Username = userInfo[0],
                        Password = userInfo.Length > 1 ? userInfo[1] : string.Empty,
                        Database = url.AbsolutePath.TrimStart('/'),
                        Port = url.Port == -1 ? 5432 : url.Port,  // Default to 5432 if port not specified
                        SslMode = SslMode.Require
                    }.ConnectionString;

                    Console.WriteLine($"INFO: Using DATABASE_URL from environment variable. Connecting to {url.Host}");
                    services.AddDbContext<PaymentContext>(options => options.UseNpgsql(connectionString));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: Failed to parse DATABASE_URL: {ex.Message}. Falling back to DefaultConnection.");
                    services.AddDbContext<PaymentContext>(options =>
                        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")!));
                }
            }
            else
            {
                var fallbackConnection = configuration.GetConnectionString("DefaultConnection");
                Console.WriteLine($"INFO: DATABASE_URL not found. Using DefaultConnection from appsettings.");
                services.AddDbContext<PaymentContext>(options =>
                    options.UseNpgsql(fallbackConnection!));
            }

            return services;
        }
    }
}

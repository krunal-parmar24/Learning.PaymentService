using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Learning.PaymentService.Infrastructure.Data
{
    /// <summary>
    /// Provides a design-time factory for creating PaymentContext instances.
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PaymentContext>
    {
        public PaymentContext CreateDbContext(string[] args)
        {
            // Navigate to API project directory to find appsettings.json
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Learning.PaymentService.API");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<PaymentContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new PaymentContext(optionsBuilder.Options);
        }
    }
}

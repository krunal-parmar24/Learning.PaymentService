using Learning.PaymentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Learning.PaymentService.Infrastructure.Data
{
    /// <summary>
    /// Context class for PaymentService, managing Payment entities.
    /// </summary>
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("payments");
            base.OnModelCreating(modelBuilder);
        }
    }
}

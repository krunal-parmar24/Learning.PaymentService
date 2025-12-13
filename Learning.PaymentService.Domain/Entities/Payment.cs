using Learning.PaymentService.Domain.Enums;

namespace Learning.PaymentService.Domain.Entities
{
    /// <summary>
    /// Represents a payment entity with details about the payment transaction.
    /// </summary>
    public class Payment : BaseEntity
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus Status { get; set; }
        public string TransactionId { get; set; } = string.Empty;
    }
}

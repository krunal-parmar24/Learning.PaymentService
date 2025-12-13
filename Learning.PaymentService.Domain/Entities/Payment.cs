using Learning.PaymentService.Domain.Enums;

namespace Learning.PaymentService.Domain.Entities
{
    /// <summary>
    /// Represents a payment entity with details about the payment transaction.
    /// </summary>
    public class Payment : BaseEntity
    {
        public required int OrderId { get; set; }
        public required decimal Amount { get; set; }
        public required PaymentMethod PaymentMethod { get; set; }
        public required PaymentStatus Status { get; set; }
        public required string TransactionId { get; set; }
    }
}

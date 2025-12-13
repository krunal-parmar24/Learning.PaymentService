namespace Learning.PaymentService.Domain.Entities
{
    /// <summary>
    /// Provides a base class for entities with common properties such as identifier and timestamps.
    /// </summary>
    public class BaseEntity
    {
        public required int Id { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

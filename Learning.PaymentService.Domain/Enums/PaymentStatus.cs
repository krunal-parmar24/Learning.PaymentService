namespace Learning.PaymentService.Domain.Enums
{
    /// <summary>
    /// Presents the various payment statuses in the payment service.
    /// </summary>
    public enum PaymentStatus
    {
        Pending = 0,
        Success = 1,
        Failed = 2,
        Refunded = 3,
    }
}

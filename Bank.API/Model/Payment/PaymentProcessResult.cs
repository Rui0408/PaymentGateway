using System;

namespace Bank.API.Model.Payment
{
    public class PaymentProcessResult
    {
        public Guid paymentRefId { get; set; }

        public Status status { get; set; }
    }

    public enum Status
    {
        Success = 1,
        Failed = 2
    }
}

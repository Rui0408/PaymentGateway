using System;

namespace PaymentGateway.Srv.Commands.Submit
{
    public class PaymentSubmitCommandResponse
    {
        public PaymentProcessResult Data { get; set; }


    }
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
using PaymentGateway.Srv.Commands.Submit;

namespace PaymentGateway.Srv.Queries.Payment.Get
{
    public class GetQueryResponse
    {
        public PaymentResult Data { get; set; }


    }
    public class PaymentResult
    {
        public PaymentRequest paymentDetail { get; set; }
        public Status status { get; set; }
    }

}
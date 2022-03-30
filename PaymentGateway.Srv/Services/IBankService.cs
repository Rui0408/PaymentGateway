using PaymentGateway.Srv.Commands.Submit;
using PaymentGateway.Srv.Queries.Payment.Get;
using System;
using System.Threading.Tasks;

namespace PaymentGateway.Srv.Services
{
    public interface IBankService
    {
        Task<PaymentProcessResult> Process(PaymentRequest request);
        Task<PaymentResult> Get(Guid id);

    }
}

using AutoMapper;
using FluentResults;
using MediatR;
using PaymentGateway.Srv.Commands.Base;
using PaymentGateway.Srv.Services;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.Srv.Commands.Submit
{
    public class PaymentSubmitCommandHandler : CommandHandlerBase, IRequestHandler<PaymentSubmitCommand, Result<PaymentSubmitCommandResponse>>
    {

        private readonly IBankService _bankService;
        public PaymentSubmitCommandHandler(IMapper mapper, IBankService bankService) : base(mapper)
        {
            _bankService = bankService;
        }

        public async Task<Result<PaymentSubmitCommandResponse>> Handle(PaymentSubmitCommand c, CancellationToken cancellationToken)
        {
            var result = await _bankService.Process(c.Data);

            var response = new PaymentSubmitCommandResponse()
            {
                Data = result
            };

            return Result.Ok(response);
        }
    }
}

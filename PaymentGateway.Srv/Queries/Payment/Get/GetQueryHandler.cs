using AutoMapper;
using FluentResults;
using MediatR;
using PaymentGateway.Srv.Commands.Base;
using PaymentGateway.Srv.Services;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.Srv.Queries.Payment.Get
{
    public class GetQueryHandler : CommandHandlerBase, IRequestHandler<GetQuery, Result<GetQueryResponse>>
    {
        private readonly IBankService _bankService;

        public GetQueryHandler(IMapper mapper, IBankService bankService) : base(mapper)
        {
            _bankService = bankService;
        }

        public async Task<Result<GetQueryResponse>> Handle(GetQuery query, CancellationToken cancellationToken)
        {
            var result = await _bankService.Get(query.Id);

            var response = new GetQueryResponse() { Data = result };

            return Result.Ok(response);
        }
    }
}
using FluentResults;
using MediatR;
using PaymentGateway.Srv.Commands.Base;
using System;

namespace PaymentGateway.Srv.Queries.Payment.Get
{
    public class GetQuery : CommandBase, IRequest<Result<GetQueryResponse>>
    {
        public GetQuery() : base()
        {

        }
        public Guid Id { get; set; }
    }

}
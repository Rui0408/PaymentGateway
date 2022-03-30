using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.API.Controllers.Base
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator _mediator;

        public ApiControllerBase(IMediator mediator) : base()
        {
            _mediator = mediator;
        }

        protected async Task<T> SendAsync<T>(IRequest<T> command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command, cancellationToken);
        }
    }
}

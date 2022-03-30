using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentGateway.API.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentGatewayController : ApiControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PaymentGatewayController> _logger;

        public PaymentGatewayController(ILogger<PaymentGatewayController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        [HttpPost("[controller]/Payment")]
        [ProducesResponseType(typeof(Srv.Commands.Submit.PaymentSubmitCommandResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> DraftCreate([FromBody] Srv.Commands.Submit.PaymentRequest data, CancellationToken cancellationToken)
        {
            var request = new Srv.Commands.Submit.PaymentSubmitCommand() { Data = data };
            var response = await SendAsync(request, cancellationToken);
            return MapToObjectResult(response);
        }

        [HttpGet("[controller]/Payment/{paymentId}")]
        [ProducesResponseType(typeof(Srv.Commands.Submit.PaymentSubmitCommandResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get([FromRoute] Guid paymentId, CancellationToken cancellationToken)
        {
            var request = new Srv.Queries.Payment.Get.GetQuery() { Id = paymentId };
            var response = await SendAsync(request, cancellationToken);
            return MapToObjectResult(response);
        }

        public ObjectResult MapToObjectResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return Problem(
                            title: "There are some errors when processing your request, please try later.",
                            statusCode: StatusCodes.Status400BadRequest
                    );
            }
        }
    }
}

using Bank.API.Model;
using Bank.API.Model.Payment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankController : ControllerBase
    {
        private readonly ILogger<BankController> _logger;

        public BankController(ILogger<BankController> logger)
        {
            _logger = logger;
        }

        [HttpPost("[controller]/Payment")]
        public PaymentProcessResult Process([FromBody] PaymentRequest data, CancellationToken cancellationToken)
        {
            var rng = new Random();

            var result = new PaymentProcessResult()
            {
                paymentRefId = Guid.NewGuid(),
                status = (rng.Next(10) > 5) ? Status.Success : Status.Failed
            };

            StaticPaymentStore.Push(data, result);

            return result;
        }


        [HttpGet("[controller]/Payment/{paymentId}")]
        public PaymentResult Get([FromRoute] Guid paymentId)
        {
            var paymentStore = StaticPaymentStore.Get(paymentId);

            if (paymentStore == null)
            {
                return null;
            }

            var firstPart = paymentStore.paymentDetail.Card.CardNumber.Substring(0, 6);
            var secondPart = paymentStore.paymentDetail.Card.CardNumber.Substring(paymentStore.paymentDetail.Card.CardNumber.Length - 4, 4);
            var requiredMask = new string('X', paymentStore.paymentDetail.Card.CardNumber.Length - firstPart.Length - secondPart.Length);

            return new PaymentResult()
            {
                paymentDetail = new PaymentRequest()
                {
                    Card = new Card()
                    {
                        CardNumber = string.Concat(firstPart, requiredMask, secondPart),
                        CVV = paymentStore.paymentDetail.Card.CVV,
                        Expiry = paymentStore.paymentDetail.Card.Expiry
                    },
                    Amount = paymentStore.paymentDetail.Amount,
                    Currency = paymentStore.paymentDetail.Currency,
                },
                status = paymentStore.status
            };
        }
    }
}

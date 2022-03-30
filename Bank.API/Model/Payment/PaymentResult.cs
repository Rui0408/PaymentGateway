using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.API.Model.Payment
{
    public class PaymentResult
    {
        public PaymentRequest paymentDetail { get; set; }
        public Status status{ get; set; }
    }
}

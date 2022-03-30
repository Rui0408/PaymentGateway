using Bank.API.Model.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.API.Model
{
    public static class StaticPaymentStore
    {
        private static List<PaymentResultStore> PaymentHistory;

        public static PaymentResultStore Get(Guid paymentId)
        {
            if(PaymentHistory != null && PaymentHistory.Count > 0)
            {
                return PaymentHistory.Find(pay => pay.paymentRefId == paymentId);
            }

            return null;
        }

        public static void Push(PaymentRequest req, PaymentProcessResult res)
        {
            if (PaymentHistory == null) PaymentHistory = new List<PaymentResultStore>();

            PaymentHistory.Add(new PaymentResultStore()
            {
                 paymentDetail = req,
                 paymentRefId = res.paymentRefId,
                 status = res.status
            });
        }
    }
}

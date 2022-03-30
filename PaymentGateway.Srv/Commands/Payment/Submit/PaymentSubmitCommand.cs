using FluentResults;
using MediatR;
using PaymentGateway.Srv.Commands.Base;
using System;

namespace PaymentGateway.Srv.Commands.Submit
{
    public class PaymentSubmitCommand : CommandBase, IRequest<Result<PaymentSubmitCommandResponse>>
    {
        public PaymentSubmitCommand() : base()
        {

        }
        public PaymentRequest Data { get; set; } = new PaymentRequest();

    }
    public class PaymentRequest
    {
      
        public Card Card { get; set; }
        public Double Amount { get; set; }
        public CURRENCY Currency { get; set; }      
    }

    public class Card
    {
        public string CardNumber { get; set; }
        public String Expiry { get; set; }
        public int CVV { get; set; }
    }

    public enum CURRENCY
    {
        EUR = 1,
        USD = 2,
        GBP = 3,
        CNY = 4
    }
}
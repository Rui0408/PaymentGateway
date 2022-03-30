using FluentValidation;
using PaymentGateway.Srv.Commands.Base;

namespace PaymentGateway.Srv.Commands.Submit
{
    public class PaymentSubmitCommandValidator : AbstractValidator<PaymentSubmitCommand>
    {
        public PaymentSubmitCommandValidator()
        {
            Include(new CommandBaseValidator());
            RuleFor(m => m.Data).NotNull().SetValidator(new PaymentRequestValidator());
        }
    }

    public class PaymentRequestValidator : AbstractValidator<PaymentRequest>
    {
        public PaymentRequestValidator()
        {
            RuleFor(x => x.Card).NotNull().SetValidator(new CardValidator());
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.Currency).NotEmpty().IsInEnum();
        }
    }

    public class CardValidator : AbstractValidator<Card>
    {
        public CardValidator()
        {
            RuleFor(x => x.CardNumber).NotEmpty().CreditCard();
            RuleFor(x => x.CVV).NotEmpty();
            RuleFor(x => x.Expiry).Matches("^(0[1-9]|1[0-2])\\/?([0-9]{4}|[0-9]{2})$");
        }
    }
}

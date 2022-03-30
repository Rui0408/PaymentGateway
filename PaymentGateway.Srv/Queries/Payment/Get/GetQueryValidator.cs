using FluentValidation;
using PaymentGateway.Srv.Commands.Base;

namespace PaymentGateway.Srv.Queries.Payment.Get
{
    public class GetQueryValidator : AbstractValidator<GetQuery>
    {
        public GetQueryValidator()
        {
            Include(new CommandBaseValidator());
            RuleFor(m => m.Id).NotNull();
        }

    }
        




}

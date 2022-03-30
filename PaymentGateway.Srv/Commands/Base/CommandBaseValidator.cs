using FluentValidation;
using System;

namespace PaymentGateway.Srv.Commands.Base
{
    public class CommandBaseValidator : AbstractValidator<CommandBase>
    {
        public CommandBaseValidator()
        {
        }
    }
}
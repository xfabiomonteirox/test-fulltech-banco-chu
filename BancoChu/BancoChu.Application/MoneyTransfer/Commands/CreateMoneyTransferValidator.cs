using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoChu.Application.MoneyTransfer.Commands
{
    public sealed class CreateMoneyTransferValidator : AbstractValidator<CreateMoneyTransferCommand>
    {
        public CreateMoneyTransferValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.AccountNumber).GreaterThan(0);
            RuleFor(x => x.BranchCode).GreaterThan(0);
            RuleFor(x => x.MadeOn).NotEmpty().NotNull();
            RuleFor(x => x.Description).NotEmpty().NotNull();
            RuleFor(x => x.Description).NotEmpty().NotNull();
        }
    }
}

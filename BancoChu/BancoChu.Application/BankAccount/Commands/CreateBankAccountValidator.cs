using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoChu.Application.BankAccount.Commands
{
    public sealed class CreateBankAccountValidator : AbstractValidator<CreateBankAccountCommand>
    {
        public CreateBankAccountValidator()
        {
            RuleFor(x => x.BranchCode).GreaterThan(0);
            RuleFor(x => x.CurrentAccountNumber).GreaterThan(0);
            RuleFor(x => x.AccountBalance).GreaterThanOrEqualTo(0);
        }
    }
}

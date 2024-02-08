using BancoChu.Application.Abstractions;
using BancoChu.Domain.Repositories;
using BancoChu.Domain.Shared;

namespace BancoChu.Application.BankAccount.Commands;

internal sealed class CreateBankAccountCommandHandler(
    IUnitOfWork unitOfWork,
    IBankAccountRepository bankAccountRepository)
    : ICommandHandler<CreateBankAccountCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IBankAccountRepository _bankAccountRepository = bankAccountRepository;

    public async Task<Result<Guid>> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = new Domain.Entities.BankAccounts.BankAccount(
            Guid.NewGuid(),
            request.BranchCode,
            request.CurrentAccountNumber,
            request.AccountBalance);

        _bankAccountRepository.Add(bankAccount);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return bankAccount.Id;
    }
}
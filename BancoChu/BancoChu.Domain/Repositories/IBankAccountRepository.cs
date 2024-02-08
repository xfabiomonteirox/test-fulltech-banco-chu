using BancoChu.Domain.Entities.BankAccounts;

namespace BancoChu.Domain.Repositories;

public interface IBankAccountRepository
{
    void Add(BankAccount bankAccount);

    Task<BankAccount?> GetByBranchCodeAndAccountNumberAsync(
        int branchCode,
        int accountNumber,
        CancellationToken cancellationToken = default);
}
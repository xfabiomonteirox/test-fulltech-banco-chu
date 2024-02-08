using BancoChu.Domain.Entities.BankAccounts;
using BancoChu.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BancoChu.Persistence.Repositories;

public sealed class BankAccountRepository(ApplicationDbContext dbContext)
    : IBankAccountRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public void Add(BankAccount bankAccount)
        => _dbContext.Set<BankAccount>().Add(bankAccount);

    public async Task<BankAccount?> GetByBranchCodeAndAccountNumberAsync(
        int branchCode,
        int accountNumber,
        CancellationToken cancellationToken = default)
        => await _dbContext.BankAccounts.FirstOrDefaultAsync(x =>
            x.BranchCode == branchCode
            && x.CurrentAccountNumber == accountNumber,
            cancellationToken);
}
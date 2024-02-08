using BancoChu.Domain.Entities.BankAccounts;
using BancoChu.Domain.Repositories;

namespace BancoChu.Persistence.Repositories;

public sealed class BankAccountRepository(ApplicationDbContext dbContext) : IBankAccountRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public void Add(BankAccount bankAccount)
        => _dbContext.Set<BankAccount>().Add(bankAccount);
}
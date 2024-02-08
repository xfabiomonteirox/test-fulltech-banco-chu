using BancoChu.Domain.Entities.MoneyTransfers;
using BancoChu.Domain.Repositories;

namespace BancoChu.Persistence.Repositories;

public sealed class MoneyTransferRepository(ApplicationDbContext dbContext) : IMoneyTransferRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public void Add(MoneyTransfer moneyTransfer)
        => _dbContext.Set<MoneyTransfer>().Add(moneyTransfer);
}
using BancoChu.Domain.Entities.MoneyTransfers;
using BancoChu.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BancoChu.Persistence.Repositories;

public sealed class MoneyTransferRepository(ApplicationDbContext dbContext) : IMoneyTransferRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public void Add(MoneyTransfer moneyTransfer)
        => _dbContext.Set<MoneyTransfer>().Add(moneyTransfer);

    public async Task<IReadOnlyList<MoneyTransfer>> GetBankStatamentByPeriodAsync(
        Guid bankAccountId,
        DateTime from,
        DateTime to,
        CancellationToken cancellationToken = default)
        => await _dbContext.MoneyTransfers
            .Where(x =>
                x.BankAccount.Id == bankAccountId
                && x.MadeOn.Date >= from
                && x.MadeOn.Date <= to)
            .ToListAsync(cancellationToken);
}
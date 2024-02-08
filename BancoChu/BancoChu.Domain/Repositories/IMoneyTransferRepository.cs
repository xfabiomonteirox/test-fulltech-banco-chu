using BancoChu.Domain.Entities.MoneyTransfers;

namespace BancoChu.Domain.Repositories;

public interface IMoneyTransferRepository
{
    void Add(MoneyTransfer moneyTransfer);

    Task<IReadOnlyList<MoneyTransfer>> GetBankStatamentByPeriodAsync(
        Guid bankAccountId,
        DateTime from,
        DateTime to,
        CancellationToken cancellationToken = default);
}
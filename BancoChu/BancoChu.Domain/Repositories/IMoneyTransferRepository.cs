using BancoChu.Domain.Entities.MoneyTransfers;

namespace BancoChu.Domain.Repositories;

public interface IMoneyTransferRepository
{
    void Add(MoneyTransfer moneyTransfer);
}
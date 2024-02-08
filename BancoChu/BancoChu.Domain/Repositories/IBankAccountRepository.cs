using BancoChu.Domain.Entities.BankAccounts;

namespace BancoChu.Domain.Repositories;

public interface IBankAccountRepository
{
    void Add(BankAccount bankAccount);
}
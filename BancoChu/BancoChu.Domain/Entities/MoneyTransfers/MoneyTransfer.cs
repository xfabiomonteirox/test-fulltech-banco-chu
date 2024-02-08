using BancoChu.Domain.Entities.BankAccounts;

namespace BancoChu.Domain.Entities.MoneyTransfers;

public sealed class MoneyTransfer : BaseEntity
{
    public MoneyTransfer(
        Guid id,
        BankAccount bankAccount,
        decimal amount,
        DateTime madeOn,
        string description,
        string destination) : base(id)
    {
        Amount = amount;
        BankAccount = bankAccount;
        MadeOn = madeOn;
        Description = description;
        Destination = destination;
        Destination = destination;
    }

    private MoneyTransfer()
    {
    }

    public decimal Amount { get; set; }
    public DateTime MadeOn { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public BankAccount BankAccount { get; set; } = default!;
}
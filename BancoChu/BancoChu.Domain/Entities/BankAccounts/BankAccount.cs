namespace BancoChu.Domain.Entities.BankAccounts;

public sealed class BankAccount : BaseEntity
{
    public BankAccount(Guid id,
        int branchCode,
        int currentAccountNumber,
        int accountBalance) : base(id)
    {
        BranchCode = branchCode;
        CurrentAccountNumber = currentAccountNumber;
        AccountBalance = accountBalance;
    }

    private BankAccount()
    {
    }

    public Guid BankAccountId { get; private set; }
    public int BranchCode { get; set; }
    public int CurrentAccountNumber { get; set; }
    public int AccountBalance { get; set; }
}
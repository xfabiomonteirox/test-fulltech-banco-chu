namespace BancoChu.Domain.Entities.BankAccounts;

public sealed class BankAccount : BaseEntity
{
    public BankAccount(Guid id,
        int branchCode,
        int currentAccountNumber,
        decimal accountBalance) : base(id)
    {
        BranchCode = branchCode;
        CurrentAccountNumber = currentAccountNumber;
        AccountBalance = accountBalance;
    }

    private BankAccount()
    {
    }

    public int BranchCode { get; set; }
    public int CurrentAccountNumber { get; set; }
    public decimal AccountBalance { get; set; }
}
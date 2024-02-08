using BancoChu.Application.Abstractions;

namespace BancoChu.Application.BankAccount.Commands;

public sealed record CreateBankAccountCommand(
    int BranchCode,
    int CurrentAccountNumber,
    decimal AccountBalance) : ICommand<Guid>;
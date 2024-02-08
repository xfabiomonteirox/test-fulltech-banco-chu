using BancoChu.Application.Abstractions;

namespace BancoChu.Application.MoneyTransfer.Commands;

public sealed record CreateMoneyTransferCommand(
    int BranchCode,
    int AccountNumber,
    decimal Amount,
    DateTime MadeOn,
    string Description,
    string Destination) : ICommand<Guid>;
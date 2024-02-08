namespace BancoChu.Application.MoneyTransfer.Queries;

public sealed class BankStatamentResponse
{
    public IReadOnlyList<Domain.Entities.MoneyTransfers.MoneyTransfer> MoneyTransfers { get; set; } = [];
}
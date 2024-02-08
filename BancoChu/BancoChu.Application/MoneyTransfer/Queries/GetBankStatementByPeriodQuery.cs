using BancoChu.Application.Abstractions;

namespace BancoChu.Application.MoneyTransfer.Queries;

public sealed record GetBankStatementByPeriodQuery(
    int BranchCode,
    int AccountNumber,
    string From,
    string To) : IQuery<BankStatamentResponse>;
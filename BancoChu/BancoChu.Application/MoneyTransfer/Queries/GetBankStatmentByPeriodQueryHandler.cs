using BancoChu.Application.Abstractions;
using BancoChu.Domain.Entities.BankAccounts;
using BancoChu.Domain.Repositories;
using BancoChu.Domain.Shared;
using System.Globalization;

namespace BancoChu.Application.MoneyTransfer.Queries;

internal sealed class GetBankStatmentByPeriodQueryHandler(
    IBankAccountRepository bankAccountRepository,
    IMoneyTransferRepository moneyTransferRepository)
    : IQueryHandler<GetBankStatementByPeriodQuery, BankStatamentResponse>
{
    private readonly IBankAccountRepository _bankAccountRepository = bankAccountRepository;
    private readonly IMoneyTransferRepository _moneyTransferRepository = moneyTransferRepository;

    public async Task<Result<BankStatamentResponse>> Handle(
        GetBankStatementByPeriodQuery request,
        CancellationToken cancellationToken)
    {
        var bankAccount = await _bankAccountRepository
            .GetByBranchCodeAndAccountNumberAsync(
                request.BranchCode,
                request.AccountNumber,
                cancellationToken);

        if (bankAccount is null)
        {
            return Result.Failure<BankStatamentResponse>(BankAccountErrors
                .NotFound(request.BranchCode, request.AccountNumber));
        }

        var from = DateTime.SpecifyKind(
            DateTime.ParseExact(request.From, "dd/MM/yyyy",
                CultureInfo.GetCultureInfo("en-US"),
                DateTimeStyles.AdjustToUniversal),
            DateTimeKind.Utc);

        var to = DateTime.SpecifyKind(
            DateTime.ParseExact(
                request.To,
                "dd/MM/yyyy",
                CultureInfo.GetCultureInfo("en-US"),
                DateTimeStyles.AdjustToUniversal),
            DateTimeKind.Utc);

        var moneyTransfers = await _moneyTransferRepository
            .GetBankStatamentByPeriodAsync(
                bankAccount.Id,
                from,
                to,
                cancellationToken);

        return new BankStatamentResponse { MoneyTransfers = moneyTransfers };
    }
}
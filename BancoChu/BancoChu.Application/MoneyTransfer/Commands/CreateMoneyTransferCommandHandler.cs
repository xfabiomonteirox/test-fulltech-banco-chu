using BancoChu.Application.Abstractions;
using BancoChu.Domain.Entities.MoneyTransfers;
using BancoChu.Domain.Repositories;
using BancoChu.Domain.Shared;

namespace BancoChu.Application.MoneyTransfer.Commands;

internal sealed class CreateMoneyTransferCommandHandler(
    IUnitOfWork unitOfWork,
    IMoneyTransferRepository moneyTransferRepository,
    IBankAccountRepository bankAccountRepository,
    IBrazilHolidaysService brazilHolidaysService)
    : ICommandHandler<CreateMoneyTransferCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMoneyTransferRepository _moneyTransferRepository = moneyTransferRepository;
    private readonly IBankAccountRepository _bankAccountRepository = bankAccountRepository;
    private readonly IBrazilHolidaysService _brazilHolidaysService = brazilHolidaysService;

    public async Task<Result<Guid>> Handle(CreateMoneyTransferCommand request, CancellationToken cancellationToken)
    {
        if (await _brazilHolidaysService.IsHolidayAsync(request.MadeOn, cancellationToken))
            return Result.Failure<Guid>(MoneyTransferErrors.NotAllowedBrazilHoliday());

        var bankAccount = await _bankAccountRepository
            .GetByBranchCodeAndAccountNumberAsync(request.BranchCode, request.AccountNumber, cancellationToken);

        if (bankAccount is null)
            return Result.Failure<Guid>(MoneyTransferErrors.NotFoundBranchCode(request.BranchCode));

        bankAccount.AccountBalance -= request.Amount;

        var moneyTransfer = new Domain.Entities.MoneyTransfers.MoneyTransfer(
            Guid.NewGuid(),
            bankAccount,
            request.Amount,
            request.MadeOn,
            request.Description,
            request.Destination);

        _moneyTransferRepository.Add(moneyTransfer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return moneyTransfer.Id;
    }
}
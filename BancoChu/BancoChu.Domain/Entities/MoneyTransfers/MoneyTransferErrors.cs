using BancoChu.Domain.Shared;

namespace BancoChu.Domain.Entities.MoneyTransfers;

public static class MoneyTransferErrors
{
    public static Error NotFoundBranchCode(int branchCode) => Error.NotFound(
        "MoneyTransfer.NotFoundBranchCode",
        $"The Account with the Code = '{branchCode}' was not found");

    public static Error NotAllowedBrazilHoliday() => Error.Failure(
    "MoneyTransfer.NotAllowed",
    "Transfers are not allowed on national holidays, so try again with a different date!");
}
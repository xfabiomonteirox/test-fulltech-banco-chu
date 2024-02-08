using BancoChu.Domain.Shared;

namespace BancoChu.Domain.Entities.BankAccounts;

public static class BankAccountErrors
{
    public static Error NotFound(int branchCode, int accountNumber) => Error.NotFound(
        "BankAccountErrors.NotFound",
        $"The Account with the Code = '{branchCode}' and AccountNumber = {accountNumber} was not found");
}
using BancoChu.Domain.Shared;

namespace BancoChu.Domain.Entities.ApplicationUsers;

public static class ApplicationUserErrors
{
    public static Error NotFoundByEmail(string email) => Error.NotFound(
        "ApplicationUsers.NotFoundByEmail", $"The user with the Email = '{email}' was not found");
}
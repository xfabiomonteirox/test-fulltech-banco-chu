using BancoChu.Domain.Entities.ApplicationUsers;

namespace BancoChu.Domain.Repositories;

public interface IApplicationUserRepository
{
    Task<ApplicationUser?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default);
}
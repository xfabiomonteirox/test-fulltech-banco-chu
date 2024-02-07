using BancoChu.Domain.Entities;

namespace BancoChu.Domain.Repositories;

public interface IApplicationUserRepository
{
    Task<ApplicationUser?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default);
}
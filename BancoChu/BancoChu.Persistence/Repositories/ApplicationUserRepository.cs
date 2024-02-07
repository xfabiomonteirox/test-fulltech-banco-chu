using BancoChu.Domain.Entities;
using BancoChu.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BancoChu.Persistence.Repositories;

public sealed class ApplicationUserRepository(ApplicationDbContext dbContext)
    : IApplicationUserRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<ApplicationUser?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default)
        => await _dbContext.ApplicationUsers
            .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
}
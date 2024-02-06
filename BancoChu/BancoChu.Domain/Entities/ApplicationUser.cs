using BancoChu.Domain.Entities.Base;

namespace BancoChu.Domain.Entities;

public sealed class ApplicationUser : BaseEntity
{
    internal ApplicationUser(Guid id,
        string email) : base(id)
    {
        Email = email;
    }

    private ApplicationUser()
    {
    }

    public string Email { get; private set; } = null!;
}
﻿namespace BancoChu.Domain.Entities.ApplicationUsers;

public sealed class ApplicationUser : BaseEntity
{
    public ApplicationUser(
        Guid id,
        string email) : base(id)
    {
        Email = email;
    }

    private ApplicationUser()
    {
    }

    public string Email { get; private set; } = null!;
}
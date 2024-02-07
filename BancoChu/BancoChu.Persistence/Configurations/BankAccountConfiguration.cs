using BancoChu.Domain.Entities.BankAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoChu.Persistence.Configurations;

public sealed class BankAccountConfiguration
    : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
using BancoChu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoChu.Persistence.Configurations;

internal sealed class MoneyTransferConfiguration
    : IEntityTypeConfiguration<MoneyTransfer>
{
    public void Configure(EntityTypeBuilder<MoneyTransfer> builder)
    {
        builder.ToTable(nameof(MoneyTransfer));

        builder.HasKey(x => x.Id);

        builder.HasOne<BankAccount>()
            .WithMany()
            .HasForeignKey(x => x.AccountId);
    }
}
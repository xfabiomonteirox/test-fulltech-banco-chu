using BancoChu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancoChu.Persistence;

public sealed class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<MoneyTransfer> MoneyTransfers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
}
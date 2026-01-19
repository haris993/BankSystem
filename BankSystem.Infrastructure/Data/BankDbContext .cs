using BankSystem.Domain.Models;
using BankSystem.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infrastructure.Data
{
    public class BankDbContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts => Set<BankAccount>();

        public BankDbContext(DbContextOptions<BankDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}

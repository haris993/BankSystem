using BankSystem.Application.Repositories.Interfaces;
using BankSystem.Domain.Models;
using BankSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Application.Repositories.Definitions
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly BankDbContext _context;

        public BankAccountRepository(BankDbContext context)
        {
            _context = context;
        }

        public IQueryable<BankAccount> GetAll()
            => _context.BankAccounts.AsNoTracking();
    }
}

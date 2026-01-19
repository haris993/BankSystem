using BankSystem.Domain.Models;

namespace BankSystem.Application.Repositories.Interfaces
{
    public interface IBankAccountRepository
    {
        IQueryable<BankAccount> GetAll();
    }
}

using BankSystem.Application.Dtos;
using BankSystem.Application.Queries;

namespace BankSystem.Application.Services.Interfaces
{
    public interface IBankAccountService
    {
        Task<PagedResult<BankAccountDto>> GetAllAsync(BankAccountQuery query);
    }
}

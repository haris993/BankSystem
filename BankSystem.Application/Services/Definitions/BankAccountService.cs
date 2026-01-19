using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankSystem.Application.Dtos;
using BankSystem.Application.Queries;
using BankSystem.Application.Repositories.Interfaces;
using BankSystem.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BankSystem.Application.Services.Definitions
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _repository;
        private readonly IMapper _mapper;

        public BankAccountService(
            IBankAccountRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BankAccountDto>> GetAllAsync(BankAccountQuery query)
        {
            var data = _repository.GetAll();

            // FILTERI
            if (!string.IsNullOrWhiteSpace(query.Currency))
                data = data.Where(x => x.Currency == query.Currency);

            if (query.IsActive.HasValue)
                data = data.Where(x => x.IsActive == query.IsActive);

            if (!string.IsNullOrWhiteSpace(query.Search))
                data = data.Where(x =>
                    x.ClientFirstName.Contains(query.Search) ||
                    x.ClientLastName.Contains(query.Search));

            var totalCount = await data.CountAsync();

            var items = await data
                .OrderBy(x => x.Id)
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ProjectTo<BankAccountDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedResult<BankAccountDto>
            {
                Items = items,
                TotalCount = totalCount,
                Page = query.Page,
                PageSize = query.PageSize
            };
        }
    }
}

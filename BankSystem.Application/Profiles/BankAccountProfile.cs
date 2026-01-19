using AutoMapper;
using BankSystem.Application.Dtos;
using BankSystem.Domain.Models;

namespace BankSystem.Application.Profiles
{
    public class BankAccountProfile : Profile
    {
        public BankAccountProfile()
        {
            CreateMap<BankAccount, BankAccountDto>()
                .ForMember(d => d.ClientName,
                    o => o.MapFrom(s => $"{s.ClientFirstName} {s.ClientLastName}"));
        }
    }
}

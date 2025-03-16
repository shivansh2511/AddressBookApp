using AutoMapper;
using AddressBookAPI.DTOs;
using AddressBookAPI.Models;

namespace AddressBookAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddressBookEntry, AddressBookDto>().ReverseMap();
        }
    }
}

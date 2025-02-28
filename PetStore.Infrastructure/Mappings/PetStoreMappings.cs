using AutoMapper;
using PetStore.Data.Dtos;
using PetStore.Data.Entities;

namespace PetStore.Infrastructure.Mappings
{
    public class PetStoreMappings : Profile
    {
        public PetStoreMappings()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, CreateUserDto>();

            CreateMap<CreateBrandDto, Brand>();
            CreateMap<Brand, CreateBrandDto>();
        }
    }
}

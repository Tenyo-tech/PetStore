using PetStore.Data.Dtos;

namespace PetStore.Business.Services
{
    public interface IBrandService
    {
        public Task<CreateBrandDto?> CreateBrand(CreateBrandDto createBrandDto);
    }
}

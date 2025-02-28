using PetStore.Data.Dtos;

namespace PetStore.Data.Repositories
{
    public interface IBrandRepository
    {
        public Task<CreateBrandDto?> CreateBrand(CreateBrandDto createBrandDto);
    }
}

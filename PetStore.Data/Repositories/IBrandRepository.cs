using PetStore.Data.Dtos.Brand;

namespace PetStore.Data.Repositories
{
    public interface IBrandRepository
    {
        public Task<CreateBrandDto?> CreateBrandAsync(CreateBrandDto createBrandDto);

        public Task<BrandDto?> GetBrandByIdAsync(int id);

        public Task<IEnumerable<BrandDto>> GetAllBrandsAsync();

        public Task<UpdateBrandDto?> UpdateBrandAsync(int id, UpdateBrandDto updateBrandDto);

        public Task<BrandDto?> DeleteBrandAsync(int id);
    }
}

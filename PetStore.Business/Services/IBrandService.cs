using PetStore.Data.Dtos.Brand;

namespace PetStore.Business.Services
{
    public interface IBrandService
    {
        public Task<CreateBrandDto?> CreateBrandAsync(CreateBrandDto createBrandDto);

        public Task<BrandDto?> GetBrandByIdAsync(int id);

        public Task<IEnumerable<BrandDto>> GetAllBrandsAsync();

        public Task<UpdateBrandDto?> UpdateBrandAsync(int id, UpdateBrandDto updateBrandDto);

        public Task<BrandDto?> DeleteBrandAsync(int id);
    }
}

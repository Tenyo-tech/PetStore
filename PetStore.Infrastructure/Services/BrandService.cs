using PetStore.Business.Services;
using PetStore.Data.Dtos.Brand;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task<CreateBrandDto?> CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var brand = await brandRepository.CreateBrandAsync(createBrandDto);
            return brand;
        }

        public async Task<BrandDto?> GetBrandByIdAsync(int id)
        {
            return await this.brandRepository.GetBrandByIdAsync(id);
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            return await this.brandRepository.GetAllBrandsAsync();
        }

        public async Task<UpdateBrandDto?> UpdateBrandAsync(int id, UpdateBrandDto updateBrandDto)
        {
            var brand = await brandRepository.UpdateBrandAsync(id, updateBrandDto);

            return brand;
        }

        public async Task<BrandDto?> DeleteBrandAsync(int id)
        {
            return await this.brandRepository.DeleteBrandAsync(id);
        }
    }
}

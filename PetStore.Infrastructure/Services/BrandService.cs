using PetStore.Business.Services;
using PetStore.Data.Dtos;
using PetStore.Data.Entities;
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

        public async Task<Brand?> GetBrandByIdAsync(int id)
        {
            return await this.brandRepository.GetBrandByIdAsync(id);
        }

        public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
        {
            return await this.brandRepository.GetAllBrandsAsync();
        }
    }
}

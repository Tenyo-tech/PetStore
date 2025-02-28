using PetStore.Business.Services;
using PetStore.Data.Dtos;
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

        public async Task<CreateBrandDto?> CreateBrand(CreateBrandDto createBrandDto)
        {
            var brand = await brandRepository.CreateBrand(createBrandDto);
            return brand;
        }
    }
}

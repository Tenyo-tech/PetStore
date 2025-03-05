using PetStore.Data.Dtos;
using PetStore.Data.Entities;

namespace PetStore.Business.Services
{
    public interface IBrandService
    {
        public Task<CreateBrandDto?> CreateBrandAsync(CreateBrandDto createBrandDto);

        public Task<Brand?> GetBrandByIdAsync(int id);

        public Task<IEnumerable<Brand>> GetAllBrandsAsync();
    }
}

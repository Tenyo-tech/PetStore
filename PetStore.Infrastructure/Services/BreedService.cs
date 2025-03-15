using PetStore.Business.Services;
using PetStore.Data.Dtos.Breed;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Services
{
    public class BreedService : IBreedService
    {
        private readonly IBreedRepository breedRepository;

        public BreedService(IBreedRepository breedRepository)
        {
            this.breedRepository = breedRepository;
        }

        public async Task<CreateBreedDto?> CreateBreedAsync(CreateBreedDto createBreedDto)
        {
            var breed = await breedRepository.CreateBreedAsync(createBreedDto);
            return breed;
        }

        public async Task<BreedDto?> GetBreedByIdAsync(int id)
        {
            return await breedRepository.GetBreedByIdAsync(id);
        }

        public async Task<IEnumerable<BreedDto>> GetAllBreedsAsync()
        {
            return await breedRepository.GetAllBreedsAsync();
        }

        public async Task<UpdateBreedDto?> UpdateBreedAsync(int id, UpdateBreedDto updateBreedDto)
        {
            var breed = await breedRepository.UpdateBreedAsync(id, updateBreedDto);
            return breed;
        }

        public async Task<BreedDto?> DeleteBreedAsync(int id)
        {
            return await breedRepository.DeleteBreedAsync(id);
        }
    }
}

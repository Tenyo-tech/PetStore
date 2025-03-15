using PetStore.Business.Services;
using PetStore.Data.Dtos.Toy;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Services
{
    public class ToyService : IToyService
    {
        private readonly IToyRepository toyRepository;

        public ToyService(IToyRepository toyRepository)
        {
            this.toyRepository = toyRepository;
        }

        public async Task<CreateToyDto?> CreateToyAsync(CreateToyDto createToyDto)
        {
            return await toyRepository.CreateToyAsync(createToyDto);
        }

        public async Task<ToyDto?> GetToyByIdAsync(int id)
        {
            return await toyRepository.GetToyByIdAsync(id);
        }

        public async Task<IEnumerable<ToyDto>> GetAllToysAsync()
        {
            return await toyRepository.GetAllToysAsync();
        }

        public async Task<UpdateToyDto?> UpdateToyAsync(int id, UpdateToyDto updateToyDto)
        {
            return await toyRepository.UpdateToyAsync(id, updateToyDto);
        }

        public async Task<ToyDto?> DeleteToyAsync(int id)
        {
            return await toyRepository.DeleteToyAsync(id);
        }
    }
}

using PetStore.Business.Services;
using PetStore.Data.Dtos.Pet;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository petRepository;

        public PetService(IPetRepository petRepository)
        {
            this.petRepository = petRepository;
        }

        public async Task<CreatePetDto?> CreatePetAsync(CreatePetDto createPetDto)
        {
            return await petRepository.CreatePetAsync(createPetDto);
        }

        public async Task<PetDto?> GetPetByIdAsync(int id)
        {
            return await petRepository.GetPetByIdAsync(id);
        }

        public async Task<IEnumerable<PetDto>> GetAllPetsAsync()
        {
            return await petRepository.GetAllPetsAsync();
        }

        public async Task<UpdatePetDto?> UpdatePetAsync(int id, UpdatePetDto updatePetDto)
        {
            return await petRepository.UpdatePetAsync(id, updatePetDto);
        }

        public async Task<PetDto?> DeletePetAsync(int id)
        {
            return await petRepository.DeletePetAsync(id);
        }
    }
}

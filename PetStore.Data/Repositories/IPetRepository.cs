using PetStore.Data.Dtos.Pet;

namespace PetStore.Data.Repositories
{
    public interface IPetRepository
    {
        Task<CreatePetDto?> CreatePetAsync(CreatePetDto createPetDto);
        Task<PetDto?> GetPetByIdAsync(int id);
        Task<IEnumerable<PetDto>> GetAllPetsAsync();
        Task<UpdatePetDto?> UpdatePetAsync(int id, UpdatePetDto updatePetDto);
        Task<PetDto?> DeletePetAsync(int id);
    }
}

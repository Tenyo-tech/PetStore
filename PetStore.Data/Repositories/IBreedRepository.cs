using PetStore.Data.Dtos.Breed;

namespace PetStore.Data.Repositories
{
    public interface IBreedRepository
    {
        Task<CreateBreedDto?> CreateBreedAsync(CreateBreedDto createBreedDto);
        Task<BreedDto?> GetBreedByIdAsync(int id);
        Task<IEnumerable<BreedDto>> GetAllBreedsAsync();
        Task<UpdateBreedDto?> UpdateBreedAsync(int id, UpdateBreedDto updateBreedDto);
        Task<BreedDto?> DeleteBreedAsync(int id);
    }
}

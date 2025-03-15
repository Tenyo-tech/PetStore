using PetStore.Data.Dtos.Breed;

namespace PetStore.Business.Services
{
    public interface IBreedService
    {
        Task<CreateBreedDto?> CreateBreedAsync(CreateBreedDto createBreedDto);
        Task<BreedDto?> GetBreedByIdAsync(int id);
        Task<IEnumerable<BreedDto>> GetAllBreedsAsync();
        Task<UpdateBreedDto?> UpdateBreedAsync(int id, UpdateBreedDto updateBreedDto);
        Task<BreedDto?> DeleteBreedAsync(int id);
    }
}

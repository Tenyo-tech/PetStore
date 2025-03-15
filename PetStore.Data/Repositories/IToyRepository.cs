using PetStore.Data.Dtos.Toy;

namespace PetStore.Data.Repositories
{
    public interface IToyRepository
    {
        Task<CreateToyDto?> CreateToyAsync(CreateToyDto createToyDto);
        Task<ToyDto?> GetToyByIdAsync(int id);
        Task<IEnumerable<ToyDto>> GetAllToysAsync();
        Task<UpdateToyDto?> UpdateToyAsync(int id, UpdateToyDto updateToyDto);
        Task<ToyDto?> DeleteToyAsync(int id);
    }
}

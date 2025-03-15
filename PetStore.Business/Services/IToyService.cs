using PetStore.Data.Dtos.Toy;

namespace PetStore.Business.Services
{
    public interface IToyService
    {
        Task<CreateToyDto?> CreateToyAsync(CreateToyDto createToyDto);
        Task<ToyDto?> GetToyByIdAsync(int id);
        Task<IEnumerable<ToyDto>> GetAllToysAsync();
        Task<UpdateToyDto?> UpdateToyAsync(int id, UpdateToyDto updateToyDto);
        Task<ToyDto?> DeleteToyAsync(int id);
    }
}

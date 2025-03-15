using PetStore.Data.Dtos.Food;

namespace PetStore.Data.Repositories
{
    public interface IFoodRepository
    {
        Task<CreateFoodDto?> CreateFoodAsync(CreateFoodDto createFoodDto);
        Task<FoodDto?> GetFoodByIdAsync(int id);
        Task<IEnumerable<FoodDto>> GetAllFoodAsync();
        Task<UpdateFoodDto?> UpdateFoodAsync(int id, UpdateFoodDto updateFoodDto);
        Task<FoodDto?> DeleteFoodAsync(int id);
    }
}

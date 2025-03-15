using PetStore.Data.Dtos.Food;

namespace PetStore.Business.Services
{
    public interface IFoodService
    {
        Task<CreateFoodDto?> CreateFoodAsync(CreateFoodDto createFoodDto);
        Task<FoodDto?> GetFoodByIdAsync(int id);
        Task<IEnumerable<FoodDto>> GetAllFoodAsync();
        Task<UpdateFoodDto?> UpdateFoodAsync(int id, UpdateFoodDto updateFoodDto);
        Task<FoodDto?> DeleteFoodAsync(int id);
    }
}

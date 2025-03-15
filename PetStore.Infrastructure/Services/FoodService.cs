using PetStore.Business.Services;
using PetStore.Data.Dtos.Food;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            this.foodRepository = foodRepository;
        }

        public async Task<CreateFoodDto?> CreateFoodAsync(CreateFoodDto createFoodDto)
        {
            return await foodRepository.CreateFoodAsync(createFoodDto);
        }

        public async Task<FoodDto?> GetFoodByIdAsync(int id)
        {
            return await foodRepository.GetFoodByIdAsync(id);
        }

        public async Task<IEnumerable<FoodDto>> GetAllFoodAsync()
        {
            return await foodRepository.GetAllFoodAsync();
        }

        public async Task<UpdateFoodDto?> UpdateFoodAsync(int id, UpdateFoodDto updateFoodDto)
        {
            return await foodRepository.UpdateFoodAsync(id, updateFoodDto);
        }

        public async Task<FoodDto?> DeleteFoodAsync(int id)
        {
            return await foodRepository.DeleteFoodAsync(id);
        }
    }
}

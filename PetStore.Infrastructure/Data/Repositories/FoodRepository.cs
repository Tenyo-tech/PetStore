using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetStore.Data.Context;
using PetStore.Data.Dtos.Food;
using PetStore.Data.Entities;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Data.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly IPetStoreDbContext petStoreDbContext;
        private readonly IMapper mapper;

        public FoodRepository(IPetStoreDbContext petStoreDbContext, IMapper mapper)
        {
            this.petStoreDbContext = petStoreDbContext;
            this.mapper = mapper;
        }

        public async Task<CreateFoodDto?> CreateFoodAsync(CreateFoodDto createFoodDto)
        {
            var food = mapper.Map<Food>(createFoodDto);
            petStoreDbContext.Food.Add(food);
            await petStoreDbContext.SaveChangesAsync();

            return mapper.Map<CreateFoodDto>(food);
        }

        public async Task<FoodDto?> GetFoodByIdAsync(int id)
        {
            var food = await petStoreDbContext.Food.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<FoodDto>(food);
        }

        public async Task<IEnumerable<FoodDto>> GetAllFoodAsync()
        {
            var foods = await petStoreDbContext.Food.ToListAsync();
            return mapper.Map<IEnumerable<FoodDto>>(foods);
        }

        public async Task<UpdateFoodDto?> UpdateFoodAsync(int id, UpdateFoodDto updateFoodDto)
        {
            var food = await petStoreDbContext.Food.FirstOrDefaultAsync(x => x.Id == id);
            if (food != null)
            {
                mapper.Map(updateFoodDto, food);
                await petStoreDbContext.SaveChangesAsync();
            }

            return mapper.Map<UpdateFoodDto>(food);
        }

        public async Task<FoodDto?> DeleteFoodAsync(int id)
        {
            var food = await petStoreDbContext.Food.FirstOrDefaultAsync(x => x.Id == id);
            if (food != null)
            {
                petStoreDbContext.Food.Remove(food);
                await petStoreDbContext.SaveChangesAsync();
            }

            return mapper.Map<FoodDto>(food);
        }
    }
}

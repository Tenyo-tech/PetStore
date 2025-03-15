using Microsoft.AspNetCore.Mvc;
using PetStore.Business.Services;
using PetStore.Data.Dtos.Food;

namespace PetStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService foodService;

        public FoodsController(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodById(int id)
        {
            var food = await foodService.GetFoodByIdAsync(id);
            if (food == null)
                return NotFound(new { message = "Cannot find food item" });

            return Ok(food);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFoods()
        {
            var foods = await foodService.GetAllFoodAsync();
            return Ok(foods);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFood(CreateFoodDto createFoodDto)
        {
            var food = await foodService.CreateFoodAsync(createFoodDto);
            return Ok(food);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFood(int id, UpdateFoodDto updateFoodDto)
        {
            var food = await foodService.UpdateFoodAsync(id, updateFoodDto);
            return Ok(new { Message = "Food item updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var food = await foodService.DeleteFoodAsync(id);
            return Ok(new { Message = "Food item deleted successfully" });
        }
    }
}

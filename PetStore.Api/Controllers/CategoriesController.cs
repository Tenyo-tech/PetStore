using Microsoft.AspNetCore.Mvc;
using PetStore.Business.Services;
using PetStore.Data.Dtos.Category;

namespace PetStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET /api/categories/{id} → Gets a category by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound(new { message = "Cannot find category" });

            return Ok(category);
        }

        // GET /api/categories → Returns all categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // POST /api/categories → Creates a new category
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = await categoryService.CreateCategoryAsync(createCategoryDto);
            if (category == null)
                return BadRequest(new { message = "Category creation failed!" });

            return Ok(category);
        }

        // PUT /api/categories/{id} → Updates an existing category
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDto categoryDto)
        {
            var category = await categoryService.UpdateCategoryAsync(id, categoryDto);
            if (category == null)
                return NotFound(new { message = "Cannot find category" });

            return Ok(new { Message = "Category updated successfully" });
        }

        // DELETE /api/categories/{id} → Deletes a category by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await categoryService.DeleteCategoryAsync(id);
            if (category == null)
                return NotFound(new { message = "Cannot find category" });

            return Ok(new { Message = "Category deleted successfully" });
        }
    }
}

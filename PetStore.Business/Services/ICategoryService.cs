using PetStore.Data.Dtos.Category;

namespace PetStore.Business.Services
{
    public interface ICategoryService
    {
        Task<CreateCategoryDto?> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<UpdateCategoryDto?> UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto);
        Task<CategoryDto?> DeleteCategoryAsync(int id);
    }
}

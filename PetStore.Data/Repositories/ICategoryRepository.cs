using PetStore.Data.Dtos.Category;

namespace PetStore.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<CreateCategoryDto?> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<UpdateCategoryDto?> UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto);
        Task<CategoryDto?> DeleteCategoryAsync(int id);
    }
}

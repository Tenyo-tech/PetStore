using PetStore.Business.Services;
using PetStore.Data.Dtos.Category;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<CreateCategoryDto?> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            return await categoryRepository.CreateCategoryAsync(createCategoryDto);
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            return await categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            return await categoryRepository.GetAllCategoriesAsync();
        }

        public async Task<UpdateCategoryDto?> UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto)
        {
            return await categoryRepository.UpdateCategoryAsync(id, updateCategoryDto);
        }

        public async Task<CategoryDto?> DeleteCategoryAsync(int id)
        {
            return await categoryRepository.DeleteCategoryAsync(id);
        }
    }
}

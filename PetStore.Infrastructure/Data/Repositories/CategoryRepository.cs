using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetStore.Data.Context;
using PetStore.Data.Dtos.Category;
using PetStore.Data.Entities;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IPetStoreDbContext petStoreDbContext;
        private readonly IMapper mapper;

        public CategoryRepository(IPetStoreDbContext petStoreDbContext, IMapper mapper)
        {
            this.petStoreDbContext = petStoreDbContext;
            this.mapper = mapper;
        }

        public async Task<CreateCategoryDto?> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = mapper.Map<Category>(createCategoryDto);
            petStoreDbContext.Categories.Add(category);
            await petStoreDbContext.SaveChangesAsync();

            return mapper.Map<CreateCategoryDto>(category);
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var category = await petStoreDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await petStoreDbContext.Categories.ToListAsync();
            return mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<UpdateCategoryDto?> UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto)
        {
            var category = await petStoreDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category != null)
            {
                category.Name = updateCategoryDto.Name;
                category.Description = updateCategoryDto.Description;

                await petStoreDbContext.SaveChangesAsync();
            }

            return mapper.Map<UpdateCategoryDto>(category);
        }

        public async Task<CategoryDto?> DeleteCategoryAsync(int id)
        {
            var category = await petStoreDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category != null)
            {
                petStoreDbContext.Categories.Remove(category);
                await petStoreDbContext.SaveChangesAsync();
            }

            return mapper.Map<CategoryDto>(category);
        }
    }
}

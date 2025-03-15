using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetStore.Data.Context;
using PetStore.Data.Dtos.Brand;
using PetStore.Data.Entities;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Data.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IPetStoreDbContext petStoreDbContext;
        private readonly IMapper mapper;

        public BrandRepository(IPetStoreDbContext petStoreDbContext, IMapper mapper)
        {
            this.petStoreDbContext = petStoreDbContext;
            this.mapper = mapper;
        }

        public async Task<CreateBrandDto?> CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var brand = mapper.Map<Brand>(createBrandDto);

            petStoreDbContext.Brands.Add(brand);

            await petStoreDbContext.SaveChangesAsync();

            var result = await petStoreDbContext.Brands.FirstOrDefaultAsync(x => x.Id == brand.Id);
            var createdBrand = mapper.Map<CreateBrandDto>(result);
            return createdBrand;
        }

        public async Task<BrandDto?> GetBrandByIdAsync(int id)
        {
            var result = await this.petStoreDbContext.Brands.FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<BrandDto>(result);
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var result = await this.petStoreDbContext.Brands.ToListAsync();

            return mapper.Map<IEnumerable<BrandDto>>(result);
        }

        public async Task<UpdateBrandDto?> UpdateBrandAsync(int id, UpdateBrandDto updateBrandDto)
        {

            var brand = await this.petStoreDbContext.Brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand != null)
            {
                brand.Name = updateBrandDto.Name;
                brand.ImageUrl = updateBrandDto.ImageUrl;

                this.petStoreDbContext.Brands.Remove(brand);

                await petStoreDbContext.SaveChangesAsync();
            }

            return mapper.Map<UpdateBrandDto>(brand);
        }

        public async Task<BrandDto?> DeleteBrandAsync(int id)
        {
            var brand = await this.petStoreDbContext.Brands.FirstOrDefaultAsync(x => x.Id == id);

            if (brand != null)
            {
                this.petStoreDbContext.Brands.Remove(brand);

                await petStoreDbContext.SaveChangesAsync();
            }

            return mapper.Map<BrandDto>(brand);
        }
    }
}

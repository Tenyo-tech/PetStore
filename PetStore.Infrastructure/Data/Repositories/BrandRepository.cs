﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetStore.Data.Context;
using PetStore.Data.Dtos;
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

        public async Task<CreateBrandDto?> CreateBrand(CreateBrandDto createBrandDto)
        {
            var brand = mapper.Map<Brand>(createBrandDto);

            petStoreDbContext.Brands.Add(brand);

            await petStoreDbContext.SaveChangesAsync();

            var result = await petStoreDbContext.Brands.FirstOrDefaultAsync(x => x.Id == brand.Id);
            var createdBrand = mapper.Map<CreateBrandDto>(result);
            return createdBrand;
        }
    }
}

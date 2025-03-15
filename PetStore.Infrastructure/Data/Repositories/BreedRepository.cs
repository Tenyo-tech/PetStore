using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetStore.Data.Context;
using PetStore.Data.Dtos.Breed;
using PetStore.Data.Entities;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Data.Repositories
{
    public class BreedRepository : IBreedRepository
    {
        private readonly IPetStoreDbContext petStoreDbContext;
        private readonly IMapper mapper;

        public BreedRepository(IPetStoreDbContext petStoreDbContext, IMapper mapper)
        {
            this.petStoreDbContext = petStoreDbContext;
            this.mapper = mapper;
        }

        public async Task<CreateBreedDto?> CreateBreedAsync(CreateBreedDto createBreedDto)
        {
            var breed = mapper.Map<Breed>(createBreedDto);

            petStoreDbContext.Breeds.Add(breed);
            await petStoreDbContext.SaveChangesAsync();

            var result = await petStoreDbContext.Breeds.FirstOrDefaultAsync(x => x.Id == breed.Id);
            return mapper.Map<CreateBreedDto>(result);
        }

        public async Task<BreedDto?> GetBreedByIdAsync(int id)
        {
            var breed = await petStoreDbContext.Breeds.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<BreedDto>(breed);
        }

        public async Task<IEnumerable<BreedDto>> GetAllBreedsAsync()
        {
            var breeds = await petStoreDbContext.Breeds.ToListAsync();
            return mapper.Map<IEnumerable<BreedDto>>(breeds);
        }

        public async Task<UpdateBreedDto?> UpdateBreedAsync(int id, UpdateBreedDto updateBreedDto)
        {
            var breed = await petStoreDbContext.Breeds.FirstOrDefaultAsync(x => x.Id == id);
            if (breed != null)
            {
                breed.Name = updateBreedDto.Name;
                breed.ImageUrl = updateBreedDto.ImageUrl;

                await petStoreDbContext.SaveChangesAsync();
            }

            return mapper.Map<UpdateBreedDto>(breed);
        }

        public async Task<BreedDto?> DeleteBreedAsync(int id)
        {
            var breed = await petStoreDbContext.Breeds.FirstOrDefaultAsync(x => x.Id == id);
            if (breed != null)
            {
                petStoreDbContext.Breeds.Remove(breed);
                await petStoreDbContext.SaveChangesAsync();
            }

            return mapper.Map<BreedDto>(breed);
        }
    }
}

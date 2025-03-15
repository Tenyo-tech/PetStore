using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetStore.Data.Context;
using PetStore.Data.Dtos.Toy;
using PetStore.Data.Entities;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Data.Repositories
{
    public class ToyRepository : IToyRepository
    {
        private readonly IPetStoreDbContext petStoreDbContext;
        private readonly IMapper mapper;

        public ToyRepository(IPetStoreDbContext petStoreDbContext, IMapper mapper)
        {
            this.petStoreDbContext = petStoreDbContext;
            this.mapper = mapper;
        }

        public async Task<CreateToyDto?> CreateToyAsync(CreateToyDto createToyDto)
        {
            var toy = mapper.Map<Toy>(createToyDto);
            petStoreDbContext.Toys.Add(toy);
            await petStoreDbContext.SaveChangesAsync();

            return mapper.Map<CreateToyDto>(toy);
        }

        public async Task<ToyDto?> GetToyByIdAsync(int id)
        {
            var toy = await petStoreDbContext.Toys.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<ToyDto>(toy);
        }

        public async Task<IEnumerable<ToyDto>> GetAllToysAsync()
        {
            var toys = await petStoreDbContext.Toys.ToListAsync();
            return mapper.Map<IEnumerable<ToyDto>>(toys);
        }

        public async Task<UpdateToyDto?> UpdateToyAsync(int id, UpdateToyDto updateToyDto)
        {
            var toy = await petStoreDbContext.Toys.FirstOrDefaultAsync(x => x.Id == id);
            if (toy != null)
            {
                mapper.Map(updateToyDto, toy);
                await petStoreDbContext.SaveChangesAsync();
            }

            return mapper.Map<UpdateToyDto>(toy);
        }

        public async Task<ToyDto?> DeleteToyAsync(int id)
        {
            var toy = await petStoreDbContext.Toys.FirstOrDefaultAsync(x => x.Id == id);
            if (toy != null)
            {
                petStoreDbContext.Toys.Remove(toy);
                await petStoreDbContext.SaveChangesAsync();
            }

            return mapper.Map<ToyDto>(toy);
        }
    }
}

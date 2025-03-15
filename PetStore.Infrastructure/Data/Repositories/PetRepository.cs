using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetStore.Data.Context;
using PetStore.Data.Dtos.Pet;
using PetStore.Data.Entities;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly IPetStoreDbContext petStoreDbContext;
        private readonly IMapper mapper;

        public PetRepository(IPetStoreDbContext petStoreDbContext, IMapper mapper)
        {
            this.petStoreDbContext = petStoreDbContext;
            this.mapper = mapper;
        }

        public async Task<CreatePetDto?> CreatePetAsync(CreatePetDto createPetDto)
        {
            var pet = mapper.Map<Pet>(createPetDto);
            petStoreDbContext.Pets.Add(pet);
            await petStoreDbContext.SaveChangesAsync();

            return mapper.Map<CreatePetDto>(pet);
        }

        public async Task<PetDto?> GetPetByIdAsync(int id)
        {
            var pet = await petStoreDbContext.Pets.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<PetDto>(pet);
        }

        public async Task<IEnumerable<PetDto>> GetAllPetsAsync()
        {
            var pets = await petStoreDbContext.Pets.ToListAsync();
            return mapper.Map<IEnumerable<PetDto>>(pets);
        }

        public async Task<UpdatePetDto?> UpdatePetAsync(int id, UpdatePetDto updatePetDto)
        {
            var pet = await petStoreDbContext.Pets.FirstOrDefaultAsync(x => x.Id == id);
            if (pet != null)
            {
                mapper.Map(updatePetDto, pet);
                await petStoreDbContext.SaveChangesAsync();
            }

            return mapper.Map<UpdatePetDto>(pet);
        }

        public async Task<PetDto?> DeletePetAsync(int id)
        {
            var pet = await petStoreDbContext.Pets.FirstOrDefaultAsync(x => x.Id == id);
            if (pet != null)
            {
                petStoreDbContext.Pets.Remove(pet);
                await petStoreDbContext.SaveChangesAsync();
            }

            return mapper.Map<PetDto>(pet);
        }
    }
}

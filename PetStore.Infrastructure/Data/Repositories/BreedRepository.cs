using PetStore.Data.Context;
using PetStore.Data.Entities;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Data.Repositories
{
    public class BreedRepository : IBreedRepository
    {
        private readonly IPetStoreDbContext petStoreDbContext;

        public BreedRepository(IPetStoreDbContext petStoreDbContext)
        {
            this.petStoreDbContext = petStoreDbContext;
        }

        public async Task<string> AddBreedAsync(string breedName)
        {
            var breed = new Breed { Name = breedName };

            this.petStoreDbContext.Breeds.Add(breed);

            await this.petStoreDbContext.SaveChangesAsync();

            return breed.Name;
        }
    }
}

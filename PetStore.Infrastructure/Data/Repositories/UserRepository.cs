using PetStore.Data.Context;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IPetStoreDbContext petStoreDbContext;

        public UserRepository(IPetStoreDbContext petStoreDbContext)
        {
            this.petStoreDbContext = petStoreDbContext;
        }

        public Task<string> CreateUser()
        {

        }
    }
}

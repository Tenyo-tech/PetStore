using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetStore.Data.Context;
using PetStore.Data.Dtos;
using PetStore.Data.Entities;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IPetStoreDbContext petStoreDbContext;
        private readonly IMapper mapper;

        public UserRepository(IPetStoreDbContext petStoreDbContext, IMapper mapper)
        {
            this.petStoreDbContext = petStoreDbContext;
            this.mapper = mapper;
        }

        public async Task<CreateUserDto?> CreateUser(CreateUserDto createUserDto)
        {
            var user = mapper.Map<User>(createUserDto);

            petStoreDbContext.Users.Add(user);

            await petStoreDbContext.SaveChangesAsync();

            var result = await petStoreDbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            var createdUser = mapper.Map<CreateUserDto>(result);
            return createdUser;
        }

        public async Task<bool> Exists(int userId)
        {
            var exist = await this.petStoreDbContext.Users.AnyAsync(x => x.Id == userId);
            return exist;
        }
    }
}

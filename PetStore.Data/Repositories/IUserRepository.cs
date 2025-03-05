using PetStore.Data.Dtos;
using PetStore.Data.Entities;

namespace PetStore.Data.Repositories
{
    public interface IUserRepository
    {
        public Task<CreateUserDto?> CreateUser(CreateUserDto createUserDto);
        public Task<User> GetUserById(int id);
        public Task<bool> Exists(int userId);
    }
}

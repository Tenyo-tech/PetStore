using PetStore.Data.Dtos;

namespace PetStore.Data.Repositories
{
    public interface IUserRepository
    {
        public Task<CreateUserDto?> CreateUser(CreateUserDto createUserDto);

        public Task<bool> Exists(int userId);
    }
}

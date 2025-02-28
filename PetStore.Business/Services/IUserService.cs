using PetStore.Data.Dtos;

namespace PetStore.Business.Services
{
    public interface IUserService
    {
        public Task<CreateUserDto?> CreateUser(CreateUserDto createUserDto);

        public Task<bool> Exists(int userId);
    }
}

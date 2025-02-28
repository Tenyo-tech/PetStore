﻿using PetStore.Business.Services;
using PetStore.Data.Dtos;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<CreateUserDto?> CreateUser(CreateUserDto createUserDto)
        {
            return await userRepository.CreateUser(createUserDto);
        }

        public async Task<bool> Exists(int userId)
        {
            return await userRepository.Exists(userId);
        }
    }
}

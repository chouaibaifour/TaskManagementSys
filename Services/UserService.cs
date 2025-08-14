using Domain.DTOs.User;
using Domain.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Mappers;
namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) => _repository = repository;

        public Task<ResponseUserDto> CreateUserAsync(CreateUserDto dto)
        {
           UserModel user = dto.toModel();
            Task<UserModel>CreatedUser =  _repository.CreateAsync(user);

            if (!HasSuccessCreation(CreatedUser))
            {
                throw new Exception("User creation failed");
            }
            return Task.FromResult(CreatedUser.Result.toResponseDto());

        }

        private  bool HasSuccessCreation( Task<UserModel> createdUser)
        {
            return createdUser.Result != null;
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            return Task.FromResult( _repository.DeleteAsync(id).Result);
        }

        public Task<IEnumerable<ResponseUserDto>> GetAllUsersAsync()
        {
            return Task.FromResult(_repository.GetAllAsync().Result.Select(u => u.toResponseDto()));
        }

        public Task<ResponseUserDto> GetUserByIdAsync(int id)
        {
            UserModel user = _repository.GetByIdAsync(id).Result;
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return Task.FromResult(user.toResponseDto());
        }

        public Task<ResponseUserDto> UpdateUserAsync(int id, UpdateUserDto dto)
        {

            UserModel existingUser = _repository.GetByIdAsync(id).Result;
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }
            existingUser.update(dto.Username, dto.PasswordHash, dto.Email);
            Task<UserModel> updatedUser = _repository.UpdateAsync(existingUser);
             // Ensure the ID is set correctly for the update
            if (updatedUser.Result == null)
            {
                throw new Exception("User update failed");
            }
            return Task.FromResult(updatedUser.Result.toResponseDto());
        }
    }
}

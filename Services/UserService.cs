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


        private bool NullUser(UserModel createdUser)
        {
            return (createdUser == null);
        }

        public async Task<ResponseUserDto> CreateUserAsync(CreateUserDto dto)
        {
            UserModel user = dto.toModel();

            var CreatedUser = await _repository.CreateAsync(user);

            NullUser(CreatedUser);

            return CreatedUser.toResponseDto();

        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ResponseUserDto>> GetAllUsersAsync()
        {
            var users = await _repository.GetAllAsync();

            return users.Select(u => u.toResponseDto());
        }

        public async Task<ResponseUserDto> GetUserByIdAsync(int id)
        {
            UserModel user = await _repository.GetByIdAsync(id);

            return user.toResponseDto();
        }

        public async Task<ResponseUserDto> UpdateUserAsync( UpdateUserDto dto)
        {


            var updatedUser = await _repository.UpdateAsync(dto.toModel());


                return updatedUser.toResponseDto();

           


        }

    }
}

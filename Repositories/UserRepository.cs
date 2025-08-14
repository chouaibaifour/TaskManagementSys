using Domain.DTOs.User;
using Domain.Entities;
using Domain.Mappers;
using Domain.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _jsonFilePath = "Data\\users.json";

        public async Task<UserModel> CreateAsync(UserModel user)
        {
            
            var usersJSON = await File.ReadAllTextAsync(_jsonFilePath);
            if (string.IsNullOrEmpty(usersJSON))
            {
                usersJSON = "[]"; // Initialize with an empty array if the file is empty
            }
            UserEntity? userEntity = user.toEntity();
            
            var users = JsonSerializer.Deserialize<List<UserEntity>>(usersJSON);

            userEntity.Id = users?.Count > 0 ? users.Max(t => t.Id) + 1 : 1;
            userEntity.CreatedAt = DateTime.Now;

            users?.Add(userEntity);
            var updatedUsersJSON = JsonSerializer.Serialize(users);
            await File.WriteAllTextAsync(_jsonFilePath, updatedUsersJSON);
            return userEntity.toModel();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usersJSON = await File.ReadAllTextAsync(_jsonFilePath);
            if (string.IsNullOrEmpty(usersJSON))
            {
                usersJSON = "[]"; // Initialize with an empty array if the file is empty
            }


            var users = JsonSerializer.Deserialize<List<UserEntity>>(usersJSON);
            if(users is null || !users.Any())
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            UserEntity OldUser = users.FirstOrDefault(u => u.Id == id)!;
            if (OldUser is null) throw new KeyNotFoundException($"User with ID {id} not found.");
           return users.Remove(OldUser);
        }

        public  async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var usersJSON = await File.ReadAllTextAsync(_jsonFilePath);
            if (string.IsNullOrEmpty(usersJSON))
            {
                usersJSON = "[]"; // Initialize with an empty array if the file is empty
            }


            var users = JsonSerializer.Deserialize<List<UserEntity>>(usersJSON);
            if (users is null || !users.Any())
            {
                throw new KeyNotFoundException($"no Users found.");
            }
            
            return users.Select(u => u.toModel()).ToList();
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            var usersJSON = await File.ReadAllTextAsync(_jsonFilePath);
            if (string.IsNullOrEmpty(usersJSON))
            {
                usersJSON = "[]"; // Initialize with an empty array if the file is empty
            }
            

            var users = JsonSerializer.Deserialize<List<UserEntity>>(usersJSON);

            UserEntity userEntity = users?.FirstOrDefault(u => u.Id == id)!; 

            if (userEntity == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            return userEntity.toModel();
        }

        public async Task<UserModel> UpdateAsync(UserModel user)
        {
            var usersJSON = await File.ReadAllTextAsync(_jsonFilePath);
            if (string.IsNullOrEmpty(usersJSON))
            {
                usersJSON = "[]"; // Initialize with an empty array if the file is empty
            }
           

            var users = JsonSerializer.Deserialize<List<UserEntity>>(usersJSON);

            UserEntity OldUser = users?.FirstOrDefault(u => u.Id == user.Id)!;
            if (OldUser is null) throw new KeyNotFoundException($"User with ID {user.Id} not found.");
            users?.Remove(OldUser);
            UserEntity userEntity = user.toEntity();
            userEntity.UpdatedAt = DateTime.Now;
            userEntity.Id = OldUser.Id;
            users?.Add(userEntity);


            var updatedUsersJSON = JsonSerializer.Serialize(users);
            await File.WriteAllTextAsync(_jsonFilePath, updatedUsersJSON);
            return userEntity.toModel();
        }
    }
}

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
        private readonly string _jsonFilePath = "Data\\_users.json";
       

        public UserRepository()
        {
           
        }

        private bool FileExists()
        {
            return File.Exists(_jsonFilePath);
        }

        private async Task< List<UserEntity> > LoadUsersAsync()
        {
            if (FileExists())
            {
                return await Deserialize();
            }
               
            return new List<UserEntity>();

        }
         
        private async  Task<string>  ReadUsersFileContent()
        {
            var FileContent = await File.ReadAllTextAsync(_jsonFilePath);

            return IsContentEmpty(FileContent) ? "[]": FileContent;
        }

        private bool IsContentEmpty(string content)
        {
            return string.IsNullOrEmpty(content) || content.Trim() == "[]";
        }

        private async Task<List<UserEntity>>Deserialize()
        {
            var FileContent = await ReadUsersFileContent();
            return JsonSerializer.Deserialize<List<UserEntity>>(FileContent) ?? new List<UserEntity>();

        }

        private  void SaveChanges(List<UserEntity>users)
        {
            File.WriteAllText(_jsonFilePath, JsonSerializer.Serialize(users));
            
        }

        private  UserEntity AddNewUser( List<UserEntity> users, UserEntity user)
        {
            if (users == null)
                throw new ArgumentNullException(nameof(users));

            user.Id = users.Count > 0 ? users.Max(t => t.Id) + 1 : 1;
           

            users.Add(user);
            
            return user; 
        }

        public async Task<UserModel> CreateAsync(UserModel user)
        {
            var users = await LoadUsersAsync();

            var userEntity = AddNewUser(users,user.toEntity());

            SaveChanges(users);

            return userEntity.toModel();
        }

        private bool DeleteUser(List<UserEntity> users, int id)
        {
            
            UserEntity OldUser = users.FirstOrDefault(u => u.Id == id)!;

            if (!NullUser(OldUser)) return users.Remove(OldUser);

            throw new KeyNotFoundException($"User with ID {id} not found.");
        }
        private bool NullUser(UserEntity user)
        {
            return user is null;
        }
        public async Task< bool >DeleteAsync(int id)
        {
            var users = await LoadUsersAsync();
            if (!EmptyOrNullUsersList(users))
            {
                bool Removed = DeleteUser(users, id);
                SaveChanges(users);
            return Removed;
            }
            throw new KeyNotFoundException($"no users found.");

        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var users = await LoadUsersAsync();

            if (!EmptyOrNullUsersList(users))
            {
                return users.Select(u => u.toModel());
            }
            throw new KeyNotFoundException($"no users found.");
            
        }
        private UserEntity GetUserById(List<UserEntity> users, int id)
        {
            
            return users.FirstOrDefault(u => u.Id == id)!;
        }

        private bool EmptyOrNullUsersList(List<UserEntity> users)
        {
            return users is null || !users.Any();
        }
        public async Task<UserModel> GetByIdAsync(int id)
        {

            var users = await LoadUsersAsync();
            UserEntity userEntity;

            if (!EmptyOrNullUsersList( users))
            {
                 userEntity = GetUserById(users, id);
                if(!NullUser(userEntity))
                    return userEntity.toModel();
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            throw new KeyNotFoundException($"No Users Found.");
            
        }
        private int FindUserIndex(List<UserEntity> users, int id)
        {
           

            int index = users.FindIndex(u => u.Id == id)!;
            if (!NullUser(users[index]))
              return index;
                throw new KeyNotFoundException($"User with ID {id} not found.");


          
        }

        private int UpdateUser(List<UserEntity> users, UserEntity user)
        {
            if (!EmptyOrNullUsersList(users))
            {
                int index = FindUserIndex(users, user.Id ?? -1);

                if(!string.IsNullOrEmpty(user.Username))
                users[index].Username = user.Username;

                if (!string.IsNullOrEmpty(user.Email))
                    users[index].Email = user.Email;

                if (!string.IsNullOrEmpty(user.PasswordHash))
                    users[index].PasswordHash = user.PasswordHash;

                if (user.UpdatedAt.HasValue)
                    users[index].UpdatedAt = user.UpdatedAt;

                return index;
            }
                throw new KeyNotFoundException($"no users found.");
            
        }

        

        public async Task<UserModel> UpdateAsync(UserModel user)
        {
            var users = await LoadUsersAsync();

            int index = UpdateUser(users, user.toEntity());

            SaveChanges(users);
            return users[index].toModel();
        }
    }
}

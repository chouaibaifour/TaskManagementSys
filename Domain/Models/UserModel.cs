using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.ObjectValues;
using Domain.DTOs.User;
using Domain.Entities;
namespace Domain.Models
{
    public class UserModel
    {
        public int? Id { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        private enObjState _state = enObjState.added;
        public UserModel()
        {
            Id = null;
            Username = null;
            PasswordHash = null;
            Email = null;
            CreatedAt = null;
            UpdatedAt = null;
            _state = enObjState.added;
        }

        public UserModel(CreateUserDto dto)
        {
            Id = null;
            Username = dto.Username;
            PasswordHash = dto.PasswordHash;
            Email = dto.Email;
            CreatedAt = DateTime.Now;
            UpdatedAt = null;
            _state = enObjState.added;
        }

        public UserModel(UpdateUserDto dto)
        {
            Id = dto.Id;
            Username = dto.Username;
            PasswordHash = HashPassword(dto.Password);
            Email = dto.Email;
            UpdatedAt = DateTime.Now;
            _state = enObjState.updated;
        }

        public UserModel(UserEntity entity)
        {
            Id = entity.Id;
            Username = entity.Username;
            PasswordHash = entity.PasswordHash;
            Email = entity.Email;
            CreatedAt = entity.CreatedAt;
            UpdatedAt = entity.UpdatedAt;
            _state = enObjState.updated;
        }

        private string? HashPassword(string? password)
        {
            return password;
        }

        public void update( string? username, string? passwordHash, string? email )
        {

            Username = username;
            PasswordHash = passwordHash;
            Email = email;
            UpdatedAt = DateTime.Now;
            _state = enObjState.updated;
        }

        
    }
}

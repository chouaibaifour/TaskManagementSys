using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.User;
using Domain.Models;
using Domain.Entities;
namespace Domain.Mappers
{
    public static class UserMapper
    {
        public static UserModel toModel(this CreateUserDto dto)
        {
            UserModel user = new UserModel();
            user.Username = dto.Username;
            user.PasswordHash = dto.PasswordHash;
            user.Email = dto.Email;

            return user;
        }

        public static UserModel toModel(this UpdateUserDto dto)
        {
            UserModel user = new UserModel();
            user.update(dto.Username, dto.PasswordHash, dto.Email);
            return user;
        }
        public static ResponseUserDto toResponseDto(this UserModel model)
        {
            ResponseUserDto dto = new ResponseUserDto();
            dto.Id = model.Id;
            dto.Username = model.Username;
            dto.Email = model.Email;
            dto.CreatedAt = model.CreatedAt;
            dto.UpdatedAt = model.UpdatedAt;
            return dto;
        }
        public static UserModel toModel(this UserEntity entity)
        {
           
            UserModel user = new UserModel();
            // use update method in the usermodel
            user.Id = entity.Id;
            user.Username = entity.Username;
            user.PasswordHash = entity.PasswordHash;
            user.Email = entity.Email;
            user.CreatedAt = entity.CreatedAt;
            user.UpdatedAt = entity.UpdatedAt;
            return user;
        }
        public static UserEntity toEntity(this UserModel model)
        {
            UserEntity entity = new UserEntity();
            entity.Id = model.Id;
            entity.Username = model.Username;
            entity.PasswordHash = model.PasswordHash;
            entity.Email = model.Email;
            entity.CreatedAt = model.CreatedAt;
            entity.UpdatedAt = model.UpdatedAt;
            return entity;
        }
    }
}

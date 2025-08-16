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
        public static UserModel ToModel(this CreateUserDto dto)
        {
            UserModel user = new UserModel(dto);
            return user;
        }

        public static UserModel toModel(this UpdateUserDto dto)
        {
            UserModel user = new UserModel(dto);
            
            return user;
        }
        public static ResponseUserDto toResponseDto(this UserModel model)
        {
            ResponseUserDto dto = new ResponseUserDto(model);
            
            return dto;
        }
        public static UserModel toModel(this UserEntity entity)
        {
           
            UserModel user = new UserModel(entity);
            
            return user;
        }
        public static UserEntity toEntity(this UserModel model)
        {
            UserEntity entity = new UserEntity(model);
            
            return entity;
        }
    }
}

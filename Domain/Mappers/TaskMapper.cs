using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.DTOs.Task;
using Domain.Entities;

namespace Domain.Mappers
{
    public static class TaskMapper
    {

        public static TaskModel ToModel(this CreateTaskDto dto)
        {

            return new TaskModel(dto);
            
            
            
        }
        public static TaskModel toModel(this TaskEntity entity)
        {
            return new TaskModel(entity);
        }

        public static TaskEntity toEntity(this TaskModel model)
        {
            return new TaskEntity(model);
        }

        public static ResponseTaskDto ToResponseDto(this TaskModel model)
        {
            return new ResponseTaskDto(model);
            
        }

    }
}

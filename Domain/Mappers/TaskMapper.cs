using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.DTOs.Task;
namespace Domain.Mappers
{
    public static class TaskMapper
    {

        public static TaskModel ToCreateDto(this CreateTaskDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto), "CreateTaskDto cannot be null");
            }
            return new TaskModel
            {
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate
            };
        }

      
    }
}

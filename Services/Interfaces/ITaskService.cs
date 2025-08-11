using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;
namespace Services.Interfaces
{
    public interface ITaskService
    {
        Task<ResponseTaskDto> CreateTaskAsync(CreateTaskDto dto);
        Task<ResponseTaskDto> UpdateTaskAsync(int id, UpdateTaskDto dto);
        Task<bool> DeleteTaskAsync(int id);
        Task<ResponseTaskDto> GetTaskByIdAsync(int id);
        Task<IEnumerable<ResponseTaskDto>> GetAllTasksAsync();
        Task<bool> MarkAsCompletedAsync(int id);
    }
}

using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Interfaces;
using Domain.Entities;
using Domain.DTOs.Task;
using Domain.Models;
using Domain.Mappers;
namespace Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        public TaskService(ITaskRepository repository) => _repository = repository;

        private bool NullTask(TaskModel createdTask)
        {
            return (createdTask == null);
        }

        public async Task<ResponseTaskDto> CreateTaskAsync(CreateTaskDto dto)
        {
            var CreatedTask = await _repository.CreateAsync( dto.ToModel());

            return NullTask(CreatedTask) ? null : CreatedTask.ToResponseDto();
        }

        public Task<bool> DeleteTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResponseTaskDto>> GetAllTasksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseTaskDto> GetTaskByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MarkAsCompletedAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseTaskDto> UpdateTaskAsync(int id, UpdateTaskDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

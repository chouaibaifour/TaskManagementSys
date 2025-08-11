using Domain.DTOs;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Interfaces;
using Domain.Entities;
namespace Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        public TaskService(ITaskRepository repository) => _repository = repository;

        public Task<ResponseTaskDto> CreateTaskAsync(CreateTaskDto dto)
        {
            TaskEntity ToCreateTask = new TaskEntity(dto.Title, dto.Description, dto.DueDate, false);
            
           Task<TaskEntity>? createdTask = _repository.AddAsync(ToCreateTask)!;
            if (createdTask != null)
            {
                return Task.FromResult(new ResponseTaskDto
                {
                    Id = createdTask.Result.Id,
                    Title = createdTask.Result.Title!,
                    Description = createdTask.Result.Description!,
                    DueDate = createdTask.Result.DueDate,
                    IsCompleted = createdTask.Result.IsCompleted
                });
            }
            else
            {
                throw new Exception("Failed to create task");
            }
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

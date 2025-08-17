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
        private readonly ITaskRepository _taskrepository;
        private readonly IUserRepository _userRepository;
        private readonly IProjectRepository _projectRepository;
        public TaskService
            (ITaskRepository repository,IUserRepository userRepository,IProjectRepository projectRepository) { 
            _taskrepository = repository;
            _userRepository = userRepository;
            _projectRepository = projectRepository;
        }

        private bool NullTask(TaskModel createdTask)
        {
            return (createdTask == null);
        }

        private async Task<TaskModel> BuildTaskModelAsync(CreateTaskDto dto)
        {
            var CreatedTask = dto.ToModel();

            CreatedTask.CreatedBy = await _userRepository.GetByIdAsync(dto.CreatedById) ??
                throw new ArgumentNullException(nameof(dto.CreatedById), "CreatedBy cannot be null.");
            
                CreatedTask.Project = await _projectRepository.GetByIdAsync(dto.ProjectId) ??
                null;

            return CreatedTask;
        }

        public async Task<ResponseTaskDto> CreateTaskAsync(CreateTaskDto dto)
        {

            return (await _taskrepository.CreateAsync(await BuildTaskModelAsync(dto))).ToResponseDto();
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

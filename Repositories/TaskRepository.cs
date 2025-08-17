using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Mappers;
using Domain.Models;
using Repositories.Interfaces;
namespace Repositories
{
    public class TaskRepository : ITaskRepository
    {
        //private readonly AppDbContext _context;
        //public TaskRepository(AppDbContext context) => _context = context;
        private readonly string _jsonFilePath = "Data\\tasks.json";
        private readonly IUserRepository _userRepository;
        private readonly IProjectRepository _projectRepository;
        public TaskRepository(IUserRepository userRepository,IProjectRepository projectRepository)
        {
            _userRepository = userRepository;
            _projectRepository = projectRepository;

        }
        private bool FileExists()
        {
            return File.Exists(_jsonFilePath);
        }

        private async Task<List<TaskEntity>> LoadTaskAsync()
        {
            if (FileExists())
            {
                return await Deserialize();
            }

            return new List<TaskEntity>();

        }

        private async Task<string> ReadTasksFileContent()
        {
            var FileContent = await File.ReadAllTextAsync(_jsonFilePath);

            return IsContentEmpty(FileContent) ? "[]" : FileContent;
        }

        private bool IsContentEmpty(string content)
        {
            return string.IsNullOrEmpty(content) || content.Trim() == "[]";
        }

        private async Task<List<TaskEntity>> Deserialize()
        {
            var FileContent = await ReadTasksFileContent();
            return JsonSerializer.Deserialize<List<TaskEntity>>(FileContent) ?? new List<TaskEntity>();

        }

        private void SaveChanges(List<TaskEntity> tasks)
        {
            File.WriteAllText(_jsonFilePath, JsonSerializer.Serialize(tasks));

        }

        public async Task<TaskModel> CreateAsync(TaskModel task)
        {
            var tasks = await LoadTaskAsync();

            var taskEntity = AddNewTask(tasks, task.toEntity());

            SaveChanges(tasks);

            return await BuildTaskModel(taskEntity);
        }

        private async Task<TaskModel> BuildTaskModel(TaskEntity entity)
        {
            var task= entity.toModel();
            task.CreatedBy = await _userRepository.GetByIdAsync(entity.CreatedById);
            task.Project = await _projectRepository.GetByIdAsync(entity.ProjectId);
            return task;
        }

        private TaskEntity AddNewTask(List<TaskEntity> tasks, TaskEntity task)
        {
            task.Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;

            tasks.Add(task);
            return task;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TaskModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskModel> UpdateAsync(TaskModel task)
        {
            throw new NotImplementedException();
        }
    }
}

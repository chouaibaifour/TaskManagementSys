using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Entities;
using Repositories.Interfaces;
namespace Repositories
{
    public class TaskRepository : ITaskRepository
    {
        //private readonly AppDbContext _context;
        //public TaskRepository(AppDbContext context) => _context = context;
        private readonly string _jsonFilePath = "Data\\tasks.json";

        public async Task<TaskEntity?> AddAsync(TaskEntity task)
        {
            var tasksJSON = await File.ReadAllTextAsync(_jsonFilePath);
            if (string.IsNullOrEmpty(tasksJSON))
            {
                tasksJSON = "[]"; // Initialize with an empty array if the file is empty
            }
            var tasks =JsonSerializer.Deserialize<List<TaskEntity>>(tasksJSON);

            task.Id = tasks?.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;

            tasks?.Add(task);
            var updatedTasksJSON = JsonSerializer.Serialize(tasks);
            await File.WriteAllTextAsync(_jsonFilePath, updatedTasksJSON);
            return task;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tasks = await File.ReadAllTextAsync(_jsonFilePath);

            return false;
        }

        public async Task<IEnumerable<TaskEntity>?> GetAllAsync()
        {
            var tasks = await File.ReadAllTextAsync(_jsonFilePath);
            

            return tasks is null? null: JsonSerializer.Deserialize<List<TaskEntity>>(tasks);

        }

        public async Task<TaskEntity?> GetByIdAsync(int id)
        {
            var tasks = await File.ReadAllTextAsync(_jsonFilePath);

            return null;
        }

        public async Task<TaskEntity?> UpdateAsync(TaskEntity task)
        {
            var tasks = await File.ReadAllTextAsync(_jsonFilePath);

            return null;
        }
    }
}

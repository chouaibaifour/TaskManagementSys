using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskModel> CreateAsync(TaskModel task);
        Task<TaskModel> UpdateAsync(TaskModel task);
        Task<bool> DeleteAsync(int id);
        Task<TaskModel> GetByIdAsync(int id);
        Task<IEnumerable<TaskModel>> GetAllAsync();
    }
}

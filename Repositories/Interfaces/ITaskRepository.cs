using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskEntity?> AddAsync(TaskEntity task);
        Task<TaskEntity?> UpdateAsync(TaskEntity task);
        Task<bool> DeleteAsync(int id);
        Task<TaskEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TaskEntity>?> GetAllAsync();
    }
}

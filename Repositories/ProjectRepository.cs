using Domain.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public Task<ProjectModel> CreateAsync(ProjectModel project)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjectModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectModel> GetByIdAsync(int id)
        {
            return null;
        }

        public Task<ProjectModel> UpdateAsync(ProjectModel project)
        {
            throw new NotImplementedException();
        }
    }
}

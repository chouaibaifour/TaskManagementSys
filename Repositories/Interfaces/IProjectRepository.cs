using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
namespace Repositories.Interfaces
{
    public interface IProjectRepository
    {
        /// <summary>
        /// Creates a new project asynchronously.
        /// </summary>
        /// <param name="project">The project to create.</param>
        /// <returns>A task that represents the asynchronous operation, containing the created project.</returns>
        Task<ProjectModel> CreateAsync(ProjectModel project);
        /// <summary>
        /// Gets all projects asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing a collection of projects.</returns>
        Task<IEnumerable<ProjectModel>> GetAllAsync();
        /// <summary>
        /// Gets a project by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the project to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation, containing the project if found; otherwise, null.</returns>
        Task<ProjectModel> GetByIdAsync(int id);
        /// <summary>
        /// Updates an existing project asynchronously.
        /// </summary>
        /// <param name="project">The project with updated information.</param>
        /// <returns>A task that represents the asynchronous operation, containing the updated project.</returns>
        Task<ProjectModel> UpdateAsync(ProjectModel project);
        /// <summary>
        /// Deletes a project by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the project to delete.</param>
        /// <returns>A task that represents the asynchronous operation, returning true if deletion was successful; otherwise, false.</returns>
        Task<bool> DeleteAsync(int id);
    }
}

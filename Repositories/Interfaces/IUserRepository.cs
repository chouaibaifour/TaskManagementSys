using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.User;
using Domain.Models;
namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> CreateAsync(UserModel user);
        Task<UserModel> UpdateAsync( UserModel user);
        Task<bool> DeleteAsync(int id);
        Task<UserModel> GetByIdAsync(int id);
        Task<IEnumerable<UserModel>> GetAllAsync();
    }
}

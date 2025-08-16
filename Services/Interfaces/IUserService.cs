using Domain.DTOs.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.User;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseUserDto> CreateUserAsync(CreateUserDto dto);
        Task<ResponseUserDto> UpdateUserAsync( UpdateUserDto dto);
        Task<bool> DeleteUserAsync(int id);
        Task<ResponseUserDto> GetUserByIdAsync(int id);
        Task<IEnumerable<ResponseUserDto>> GetAllUsersAsync();

    }
}

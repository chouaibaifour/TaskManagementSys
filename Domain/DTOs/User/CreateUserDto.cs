using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.User
{
    public record CreateUserDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }

        public CreateUserDto()
        {
            Username = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
        }
    }
}

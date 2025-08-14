using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.User
{
    public record ResponseUserDto
    {
        public int? Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ResponseUserDto()
        {

            Id = null;
            Username = null;
            Email = null;
            PasswordHash = null;
            CreatedAt =null;
            UpdatedAt = null;
        }
    }
}

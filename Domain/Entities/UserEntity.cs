using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserEntity
    {
        public int? Id { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public UserEntity()
        {
            Id = null;
            Username = null;
            PasswordHash = null;
            Email = null;
            CreatedAt = null;
            UpdatedAt = null;
        }
        public UserEntity (UserModel user)
        {
            Id = user.Id;
            Username = user.Username;
            PasswordHash = user.PasswordHash;
            Email = user.Email;
            CreatedAt = user.CreatedAt;
            UpdatedAt = user.UpdatedAt;
        }

    }
}

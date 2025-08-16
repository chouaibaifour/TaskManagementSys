using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.ObjectValues;
namespace Domain.Models
{
    public class UserModel
    {
        public int? Id { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        private enObjState _state = enObjState.added;
        public UserModel()
        {
            Id = null;
            Username = null;
            PasswordHash = null;
            Email = null;
            CreatedAt = null;
            UpdatedAt = null;
            _state = enObjState.added;
        }
        public void update( string? username, string? passwordHash, string? email )
        {

            Username = username;
            PasswordHash = passwordHash;
            Email = email;
            UpdatedAt = DateTime.Now;
            _state = enObjState.updated;
        }

        
    }
}

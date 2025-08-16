using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.User
{
    public record UpdateUserDto
    {
        public required int Id { get; set; }
        public  string? Username { get; set; }
        public   string? Email { get; set; }
        public  string? Password { get; set; }
       
        
        public UpdateUserDto()
        {

            Username = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            
            
        }
    }
}

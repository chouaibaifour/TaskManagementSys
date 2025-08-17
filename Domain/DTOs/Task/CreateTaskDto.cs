using Domain.DTOs.ObjectValues;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Task
{
    public class CreateTaskDto
    {

        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Priority { get; set; } 
        public required DateTime DueDate { get; set; }
        public required int CreatedById { get; set; }                 
        public required int ProjectId { get; set; }

        public CreateTaskDto()
        {

        }
        
    }
}

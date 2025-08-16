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

        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Priority { get; set; } = "medium";   // default matches DB
        public DateTime? DueDate { get; set; }
        public int CreatedBy { get; set; }                 // required: who created it
        public int? AssignedTo { get; set; }
        public int ProjectId { get; set; }

    }
}

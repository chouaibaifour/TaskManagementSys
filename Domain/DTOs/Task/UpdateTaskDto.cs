using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Task
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }                        // task identifier
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }                // "todo", "in_progress", "completed"
        public string? Priority { get; set; }              // "low", "medium", "high", "critical"
        public DateTime? DueDate { get; set; }
        public int? AssignedTo { get; set; }
    }
}

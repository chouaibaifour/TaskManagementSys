using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }    
        public string Priority { get; set; } 
        public DateTime DueDate { get; set; }

        // Foreign Keys
        public int CreatedById { get; set; }
        public int? AssignedToId { get; set; }
        public int ProjectId { get; set; }

        // Audit fields
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

       

        public TaskEntity()
        {
           
        }

        public TaskEntity(TaskModel model)
        {
            Id = model.Id ?? 0;
            Title = model.Title;
            Description = model.Description;
            Status = model.Status;
            Priority = model.Priority;
            DueDate = model.DueDate;
            CreatedById = model.CreatedBy?.Id ?? 0;
            AssignedToId = model.AssignedTo?.Id??null;
            ProjectId = model.Project?.Id ?? 0; // will be implemented
            CreatedAt = model.CreatedAt;
            UpdatedAt = model.UpdatedAt; // Default to now if null
        }
    }
}

using Domain.DTOs.ObjectValues;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Task
{
    public class ResponseTaskDto
    {
        public ResponseTaskDto(TaskModel model)
        {
            Id = model.Id ?? 0;
            Title = model.Title;
            Description = model.Description;
            Status = model.Status;
            Priority = model.Priority;
            DueDate = model.DueDate;

            CreatedById = model.CreatedBy?.Id??0;
            CreatedByUserName = model.CreatedBy?.Username;
            AssignedToId= model.AssignedTo?.Id??0;
            AssignedToUserName=model.AssignedTo?.Username??null;
            ProjectId = model.Project?.Id??0;
            ProjectName = model.Project?.Name??null;

            CreatedAt = model.CreatedAt;
            UpdatedAt = model.UpdatedAt;                         
        }

        public int Id { get; set; }
        public string Title { get; set; } 
        public string? Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime? DueDate { get; set; }

        
        public int CreatedById { get; set; }
        public string? CreatedByUserName { get; set; }         
        public int? AssignedToId { get; set; }
        public string? AssignedToUserName { get; set; }
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }

        
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}

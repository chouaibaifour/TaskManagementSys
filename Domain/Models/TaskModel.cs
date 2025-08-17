using Domain.DTOs.ObjectValues;
using Domain.DTOs.Task;
using Domain.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TaskModel
    {
      
        public int? Id { get; set; }
        private string _Title { get; set; }
        private string _Description { get; set; }
        private enStatus _Status { get; set; } 
        private enPriority _Priority { get; set; } 
        private DateTime _DueDate { get; set; }

        private UserModel? _CreatedBy { get; set; }
        private UserModel? _AssignedTo { get; set; }
        private ProjectModel? _Project { get; set; }

        private DateTime _CreatedAt { get; set; }
        private DateTime? _UpdatedAt { get; set; }

        private enObjState _state = enObjState.added;

        
        public string Title
        {
            get => _Title;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _Title = value;
                   
                }
            }
        }
        public string Description
        {
            get => _Description;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _Description = value;
                   
                }
            }
        }

        public string Status
        {
            get => _Status  switch
            {
                enStatus.Pending => "Pending",
                enStatus.Cancelled => "Cancelled",
                enStatus.Completed => "Completed",
                _ => throw new ArgumentException("Invalid status value")
            };

            set
            {
                _Status = value.ToLower()  switch
                {
                    "pending" => enStatus.Pending,
                    "cancelled" => enStatus.Cancelled,
                    "completed" => enStatus.Completed,
                    _ => throw new ArgumentException("Invalid status value")
                };
                
            }
        }
        public string Priority
        {
            get => _Priority switch
            {
                enPriority.Low => "Low",
                enPriority.Medium => "Medium",
                enPriority.High => "High",
                enPriority.Critical => "Critical",

                _ => throw new ArgumentException("Invalid Priority value")
            };
            set
            {
                _Priority = value.ToLower() switch
                {
                    "low" => enPriority.Low,
                    "medium" => enPriority.Medium,
                    "high" => enPriority.High,
                    "critical" => enPriority.Critical,
                    _ => throw new ArgumentException("Invalid Priority value")


                };
               
            }
        }
        public DateTime DueDate
        {
            get => _DueDate;
            set
            {
                if (value != default(DateTime))
                    _DueDate = value;
               
            }
        }
        public UserModel? CreatedBy
        {
            get => _CreatedBy;
            set
            {
                _CreatedBy = value ??
                    throw new ArgumentNullException(nameof(CreatedBy), "CreatedBy cannot be null.");
                
            }
        }

        public UserModel? AssignedTo
        {
            get => _AssignedTo;
            set
            {
                _AssignedTo = value;
               
            }
        }

        public ProjectModel? Project
        {
            get => _Project;
            set
            {
                _Project = value ?? 
                    throw new ArgumentNullException(nameof(Project), "Project cannot be null.");
                
            }
        }

        public DateTime CreatedAt
        {
            get => _CreatedAt;
            set
            {
                _CreatedAt = value != default(DateTime) ? value : DateTime.Now;
                
            }
        }

        public DateTime? UpdatedAt
        {
            get => _UpdatedAt;
            set
            {
                _UpdatedAt = value;
                
            }
        }

        public TaskModel(CreateTaskDto dto)
        {
            _Title = dto.Title;
            _Description =dto. Description;
            _Status = enStatus.Pending;
            Priority = dto.Priority;
            _DueDate = dto. DueDate;
            _CreatedAt =DateTime.Now;
            _state = enObjState.added;
        }

        public TaskModel(int id, string title, string description, enStatus status,
            enPriority priority, DateTime dueDate, UserModel createdBy, UserModel assignedTo, 
            ProjectModel project, DateTime createdAt, DateTime updatedAt, enObjState state)
        {
            Id = id;
            _Title = title;
            _Description = description;
            _Status = status;
            _Priority = priority;
            _DueDate = dueDate;
            _CreatedBy = createdBy;
            _AssignedTo = assignedTo;
            _Project = project;
            _CreatedAt = createdAt;
            _UpdatedAt = updatedAt;
            _state = state;
        }

        public TaskModel(TaskEntity entity)
        {
            Id = entity.Id;
            _Title = entity.Title;
            _Description = entity.Description;
            Status = entity.Status;
            Priority = entity.Priority;
            _DueDate = entity.DueDate;
            _CreatedAt = entity.CreatedAt;
            _UpdatedAt = entity.UpdatedAt;
            _state = enObjState.updated;
        }
    }
}

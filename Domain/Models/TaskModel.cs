using Domain.DTOs.ObjectValues;
using Domain.DTOs.Task;
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
        private UserModel _CreatedBy { get; set; }
        private UserModel? _AssignedTo { get; set; }
        private ProjectModel _Project { get; set; }
        private DateTime _CreatedAt { get; set; }
        private DateTime? _UpdatedAt { get; set; }
        private enObjState _state = enObjState.added;

        private void ValidateToCreate(string? attribute)
        {
            if (_state == enObjState.added)
                throw new ArgumentNullException
                    ($"{attribute} cannot be null or empty.");
        }
        public string Title
        {
            get => _Title;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _Title = value;
                    ValidateToCreate(nameof(Title));
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
                    ValidateToCreate(nameof(Description));
                }
            }
        }

        public enStatus Status
        {
            get => _Status;
            set
            {
                _Status = value;
                ValidateToCreate(nameof(Status));
            }
        }
        public enPriority Priority
        {
            get => _Priority;
            set
            {
                _Priority = value;
                ValidateToCreate(nameof(Priority));
            }
        }
        public DateTime DueDate
        {
            get => _DueDate;
            set
            {
                if (value != default(DateTime))
                    _DueDate = value;
                ValidateToCreate(nameof(DueDate));
            }
        }
        public UserModel CreatedBy
        {
            get => _CreatedBy;
            set
            {
                _CreatedBy = value ??
                    throw new ArgumentNullException(nameof(CreatedBy), "CreatedBy cannot be null.");
                ValidateToCreate(nameof(CreatedBy));
            }
        }

        public UserModel? AssignedTo
        {
            get => _AssignedTo;
            set
            {
                _AssignedTo = value;
                ValidateToCreate(nameof(AssignedTo));
            }
        }

        public ProjectModel Project
        {
            get => _Project;
            set
            {
                _Project = value ?? 
                    throw new ArgumentNullException(nameof(Project), "Project cannot be null.");
                ValidateToCreate(nameof(Project));
            }
        }

        public DateTime CreatedAt
        {
            get => _CreatedAt;
            set
            {
                _CreatedAt = value != default(DateTime) ? value : DateTime.Now;
                ValidateToCreate(nameof(CreatedAt));
            }
        }

        public DateTime? UpdatedAt
        {
            get => _UpdatedAt;
            set
            {
                _UpdatedAt = value;
                ValidateToCreate(nameof(UpdatedAt));
            }
        }

        public TaskModel(CreateTaskDto dto)
        {
            
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
    }
}

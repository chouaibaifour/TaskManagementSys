using Domain.DTOs.ObjectValues;
using Domain.DTOs.User;
using Domain.Entities;
namespace Domain.Models
{
    public class UserModel
    {
        public int? Id { get; set; }
        private string? _Username { get; set; }
        private string? _PasswordHash { get; set; }
        private string? _Email { get; set; }
        private DateTime? _CreatedAt { get; set; }
        private DateTime? _UpdatedAt { get; set; }
        private enObjState _state = enObjState.added;

        private void ValidateToCreate(string? attribute)
        {
            if (_state == enObjState.added)
                throw new ArgumentNullException
                    ( $" {attribute} cannot be null or empty.");
        }

        public string? Username
        {
            get => _Username;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    
                _Username = value;
                ValidateToCreate(nameof(Username));
            }
        }
        public string? Email
        {
            get => _Email;
            set
            {
                if (!string.IsNullOrEmpty(value))

                    _Email = value;
                ValidateToCreate(nameof(Email));
            }
        }
        public string? PasswordHash
        {
            get => _PasswordHash;
            set
            {
                if (!string.IsNullOrEmpty(value))

                    _PasswordHash = value;
                ValidateToCreate(nameof(PasswordHash));
            }
        }
        public DateTime? CreatedAt
        {
            get => _CreatedAt;
            set
            {
                if (null!=value)

                    _CreatedAt = value;
                ValidateToCreate(nameof(CreatedAt));
            }
        }
        public DateTime? UpdatedAt
        {
            get => _UpdatedAt;
            set
            {
                if (null != value)
                    _UpdatedAt = value;
                ValidateToCreate(nameof(UpdatedAt));
            }
        }

        private UserModel(int? id, string? username, string? passwordHash, string? email, DateTime? createdAt, DateTime? updatedAt, enObjState state)
        {
            Id = id;
            Username = username;
            PasswordHash = passwordHash;
            Email = email;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            _state = state;
            
        }

        public UserModel(CreateUserDto dto)
        {
            Id = null;
            _Username = dto.Username;
            _PasswordHash = HashPassword(dto.Password); 
            _Email = dto.Email;
            _CreatedAt = DateTime.Now;
            _UpdatedAt = null;
            _state = enObjState.added;
        }

        public UserModel(UpdateUserDto dto)
        {
            _state = enObjState.updated;
            Id = dto.Id;
            Username = dto.Username;
            PasswordHash = HashPassword(dto.Password);
            Email = dto.Email;
            UpdatedAt = DateTime.Now;
            
        }

        public UserModel(UserEntity entity)
        {
            Id = entity.Id;
            _Username = entity.Username;
            _PasswordHash = entity.PasswordHash;
            _Email = entity.Email;
            _CreatedAt = entity.CreatedAt;
            _UpdatedAt = entity.UpdatedAt;
            _state = enObjState.updated;
        }

        public UserModel()
        {
        }

        private string? HashPassword(string? password)
        {
            return password;
        }

        public UserModel Update(UpdateUserDto dto)
        {
            _state = enObjState.updated;
            Id = dto.Id;
            Username = dto.Username;
            PasswordHash = HashPassword(dto.Password);
            Email = dto.Email;
            UpdatedAt = DateTime.Now;
            return this;
        }
    }
}

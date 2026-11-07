using IIS.Domain.Common;
using IIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Domain.Entities.Identity
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }

        public Student? Student { get; set; }
        public Teacher? Teacher { get; set; }
    }
}

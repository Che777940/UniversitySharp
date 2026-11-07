using IIS.Domain.Common;
using IIS.Domain.Entities.Academics;
using IIS.Domain.Entities.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Domain.Entities.Identity
{
    public class Teacher : BaseEntity
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Degree { get; set; } 
        public Guid DepartmentId { get; set; }

        public User User { get; set; } = null!;
        public Department Department { get; set; } = null!;
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}

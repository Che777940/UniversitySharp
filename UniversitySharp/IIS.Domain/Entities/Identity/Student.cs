using IIS.Domain.Common;
using IIS.Domain.Entities.Grading;
using IIS.Domain.Entities.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Domain.Entities.Identity
{
    public class Student : BaseEntity
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RecordBookNumber { get; set; } = string.Empty;
        public Guid GroupId { get; set; }

        public User User { get; set; } = null!;
        public Group Group { get; set; } = null!;
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}

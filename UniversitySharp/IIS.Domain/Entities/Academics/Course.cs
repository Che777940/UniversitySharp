using IIS.Domain.Common;
using IIS.Domain.Entities.Grading;
using IIS.Domain.Entities.Identity;
using IIS.Domain.Entities.Scheduling;
using IIS.Domain.Entities.Structure;
using IIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Domain.Entities.Academics
{
    public class Course : BaseEntity
    {
        public Guid SubjectId { get; set; }
        public Guid TeacherId { get; set; }

        public Guid GroupId { get; set; }

        public Semester Semester { get; set; }
        public string AcademicYear { get; set; } = string.Empty;
        public Subject Subject { get; set; } = null!;
        public Teacher Teacher { get; set; } = null!;
        public Group Group { get; set; } = null!;
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}

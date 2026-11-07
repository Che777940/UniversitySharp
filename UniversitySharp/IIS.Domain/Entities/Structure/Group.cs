using IIS.Domain.Common;
using IIS.Domain.Entities.Academics;
using IIS.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Domain.Entities.Structure
{
    public class Group : BaseEntity
    {
    public string Name { get; set; } = string.Empty;
    public int CourseNumber { get; set; }
    public Guid DepartmentId { get; set; }

    public Department Department { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}

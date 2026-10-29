using System;
using System.Collections.Generic;
using System.Text;
using IIS.Domain.Entities.Identity;

namespace IIS.Domain.Entities.Structure
{
    public class Group
    {
    public string Name { get; set; } = string.Empty;
    public int CourseNumber { get; set; }
    public Guid DepartmentId { get; set; }

    public Department Department { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}

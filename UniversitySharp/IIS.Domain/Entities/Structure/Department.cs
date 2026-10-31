using System;
using System.Collections.Generic;
using System.Text;
using IIS.Domain.Common;
using IIS.Domain.Entities.Identity;

namespace IIS.Domain.Entities.Structure
{
    // Здесь будет храниться кафедру
    public class Department : BaseEntity
    {
    public string Name { get; set; } = string.Empty;
    public Guid FacultyId { get; set; }

    public Faculty Faculty { get; set; } = null!;
    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    public ICollection<Group> Groups { get; set; } = new List<Group>();    
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTOs
{
    public class CreateGroupDto
    {
        public string Name { get; set; } = string.Empty;
        public int CourseNumber { get; set; }
        public Guid DepartmentId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTOs
{
    public class CreateDepartmentDto
    {
        public string Name { get; set; } = string.Empty;
        public Guid FacultyId { get; set; }
    }
}

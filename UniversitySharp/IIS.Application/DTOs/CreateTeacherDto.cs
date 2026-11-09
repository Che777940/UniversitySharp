using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTOs
{
    public class CreateTeacherDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Degree { get; set; } 
        public Guid DepartmentId { get; set; }
        public string Email { get; set; } = string.Empty; 
    }
}

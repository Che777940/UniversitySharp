using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTOs
{
    public class ProfileDto
    {
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? GroupName { get; set; }
        public string? RecordBookNumber { get; set; }

        public string? Degree { get; set; }
        public string? DepartmentName { get; set; }
    }
}

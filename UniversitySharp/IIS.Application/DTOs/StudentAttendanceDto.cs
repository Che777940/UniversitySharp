using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTOs
{
    public class StudentAttendanceDto
    {
        public Guid StudentId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public bool IsPresent { get; set; } = true; 
        public string? Reason { get; set; }
    }
}

using IIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTOs
{
    public class CreateCourseDto
    {
        public Guid SubjectId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid GroupId { get; set; }
        public Semester Semester { get; set; }
        public string AcademicYear { get; set; } = "2024/2025";
    }
}

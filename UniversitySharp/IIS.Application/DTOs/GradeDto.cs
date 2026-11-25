using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTOs
{
    public class GradeDto
    {
        public Guid Id { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string TeacherName { get; set; } = string.Empty;
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public string? Comment { get; set; }
    }
}

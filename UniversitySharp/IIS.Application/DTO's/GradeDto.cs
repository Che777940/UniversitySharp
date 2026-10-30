using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTO_s.Grade
{
    public class GradeDto
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public string? Comment { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
    }
}

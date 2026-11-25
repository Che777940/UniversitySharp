using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTOs
{
    public class CreateGradeDto
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public int Value { get; set; }
        public string? Comment { get; set; }
    }
}

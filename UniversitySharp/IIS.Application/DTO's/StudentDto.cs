using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTO_s.Student
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RecordBookNumber { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty; 
    }
}

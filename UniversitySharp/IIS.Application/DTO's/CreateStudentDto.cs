using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTO_s.Student
{
    public class CreateStudentDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RecordBookNumber { get; set; } = string.Empty;
        public Guid GroupId { get; set; }
        public string Email { get; set; } = string.Empty; 
        public string Password { get; set; } = string.Empty;
    }
}

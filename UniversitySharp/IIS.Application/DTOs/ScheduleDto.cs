using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTOs
{
    public class ScheduleDto
    {
        public Guid Id { get; set; }
        public string DayOfWeek { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string TeacherName { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty;
        public string Classroom { get; set; } = string.Empty;
        public string LessonType { get; set; } = string.Empty;
    }
}

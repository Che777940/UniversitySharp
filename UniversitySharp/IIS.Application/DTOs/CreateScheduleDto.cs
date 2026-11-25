using IIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTOs
{
    public class CreateScheduleDto
    {
        public Guid CourseId { get; set; }
        public Guid ClassroomId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public LessonType LessonType { get; set; }
    }
}

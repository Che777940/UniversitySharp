using IIS.Domain.Common;
using IIS.Domain.Entities.Academics;
using IIS.Domain.Entities.Grading;
using IIS.Domain.Enums;
using System.Collections.Generic;
using System.Text;

namespace IIS.Domain.Entities.Scheduling
{
    public class Schedule : BaseEntity
    {
        public Guid CourseId { get; set; }
        public Guid ClassroomId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public LessonType LessonType { get; set; }

        public Course Course { get; set; } = null!;
        public Classroom Classroom { get; set; } = null!;
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}

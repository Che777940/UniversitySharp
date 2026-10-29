using IIS.Domain.Common;
using IIS.Domain.Entities.Identity;
using IIS.Domain.Entities.Scheduling;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Domain.Entities.Grading
{
    public class Attendance : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Guid ScheduleId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public string? Reason { get; set; }

        public Student Student { get; set; } = null!;
        public Schedule Schedule { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTOs
{
    public class AttendanceDto
    {
        public Guid ScheduleId { get; set; }
        public DateTime Date { get; set; }
        public List<StudentAttendanceDto> Students { get; set; } = new();
    }
}

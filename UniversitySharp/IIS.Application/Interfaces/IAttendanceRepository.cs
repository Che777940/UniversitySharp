using IIS.Domain.Entities.Grading;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetByStudentIdAsync(Guid studentId);
        Task<List<Attendance>> GetByScheduleIdAndDateAsync(Guid scheduleId, DateTime date);
        Task AddRangeAsync(List<Attendance> attendances);
    }

}

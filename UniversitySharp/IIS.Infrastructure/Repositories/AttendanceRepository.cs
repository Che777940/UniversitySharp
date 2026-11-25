using IIS.Application.Interfaces;
using IIS.Domain.Entities.Grading;
using IIS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IIS.Infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Attendance>> GetByStudentIdAsync(Guid studentId)
        {
            return await _context.Attendances
                .Include(a => a.Schedule)
                    .ThenInclude(s => s.Course)
                        .ThenInclude(c => c.Subject)
                .Where(a => a.StudentId == studentId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Attendance>> GetByScheduleIdAndDateAsync(Guid scheduleId, DateTime date)
        {
            return await _context.Attendances
                .Where(a => a.ScheduleId == scheduleId && a.Date.Date == date.Date)
                .ToListAsync();
        }

        public async Task AddRangeAsync(List<Attendance> attendances)
        {
            await _context.Attendances.AddRangeAsync(attendances);
            await _context.SaveChangesAsync();
        }
    }
}

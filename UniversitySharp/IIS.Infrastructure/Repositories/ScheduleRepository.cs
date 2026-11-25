using IIS.Application.Interfaces;
using IIS.Domain.Entities.Scheduling;
using IIS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IIS.Infrastructure.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ApplicationDbContext _context;
        public ScheduleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private IQueryable<Schedule> GetBaseQuery()
        {
            return _context.Schedules
                .Include(s => s.Course).ThenInclude(c => c.Subject)
                .Include(s => s.Course).ThenInclude(c => c.Teacher)
                .Include(s => s.Course).ThenInclude(c => c.Group)
                .Include(s => s.Classroom)
                .AsNoTracking();
        }

        public async Task<List<Schedule>> GetAllAsync() => await GetBaseQuery().ToListAsync();

        public async Task<List<Schedule>> GetByTeacherIdAsync(Guid teacherId)
            => await GetBaseQuery().Where(s => s.Course.TeacherId == teacherId).ToListAsync();

        public async Task<List<Schedule>> GetByGroupIdAsync(Guid groupId)
            => await GetBaseQuery().Where(s => s.Course.GroupId == groupId).ToListAsync();

        public async Task AddAsync(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();
        }
    }
}

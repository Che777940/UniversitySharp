using IIS.Domain.Entities.Scheduling;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Interfaces
{
    public interface IScheduleRepository
    {
        Task<List<Schedule>> GetAllAsync();
        Task<List<Schedule>> GetByTeacherIdAsync(Guid teacherId);
        Task<List<Schedule>> GetByGroupIdAsync(Guid groupId);
        Task AddAsync(Schedule schedule);
    }
}

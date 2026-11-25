using IIS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public interface IScheduleService
    {
        Task<List<ScheduleDto>> GetAllAsync();
        Task<List<ScheduleDto>> GetForTeacherAsync(Guid userId); 
        Task<List<ScheduleDto>> GetForStudentAsync(Guid userId); 
        Task CreateAsync(CreateScheduleDto dto);
    }
}

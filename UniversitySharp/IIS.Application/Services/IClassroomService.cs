using IIS.Application.DTOs;
using IIS.Domain.Entities.Scheduling;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public interface IClassroomService
    {
        Task<List<Classroom>> GetAllAsync();
        Task CreateAsync(CreateClassroomDto dto);
    }
}

using IIS.Application.DTOs;
using IIS.Domain.Entities.Academics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllAsync();
        Task CreateAsync(CreateCourseDto dto);
    }
}

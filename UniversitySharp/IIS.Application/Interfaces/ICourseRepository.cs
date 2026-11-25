using IIS.Domain.Entities.Academics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task AddAsync(Course course);
    }
}

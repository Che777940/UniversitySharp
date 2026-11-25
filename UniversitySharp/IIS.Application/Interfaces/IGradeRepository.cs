using IIS.Domain.Entities.Grading;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Interfaces
{
    public interface IGradeRepository
    {
        Task<List<Grade>> GetByStudentIdAsync(Guid studentId);
        Task AddAsync(Grade grade);
    }
}

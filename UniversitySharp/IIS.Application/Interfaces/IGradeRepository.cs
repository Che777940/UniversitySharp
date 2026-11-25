using IIS.Domain.Entities.Grading;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Interfaces
{
    public interface IGradeRepository
    {
        Task<Grade?> GetByIdAsync(Guid id);
        Task<List<Grade>> GetByStudentIdAsync(Guid studentId);
        Task AddAsync(Grade grade);
        Task DeleteAsync(Grade grade);
    }
}

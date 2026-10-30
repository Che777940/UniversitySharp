using IIS.Application.DTO_s.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public interface IStudentService
    {
        Task<StudentDto?> GetByIdAsync(Guid id);
        Task<List<StudentDto>> GetAllAsync();
        Task<Guid> CreateAsync(CreateStudentDto dto);
        Task DeleteAsync(Guid id);
    }
}

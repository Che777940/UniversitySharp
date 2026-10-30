using System;
using System.Collections.Generic;
using System.Text;
using IIS.Domain.Entities.Identity;

namespace IIS.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student?> GetByIdAsync(Guid id);
        Task<List<Student>> GetAllAsync();
        Task AddAsync(Student student);
        Task UpdateAsync (Student student);
        Task DeleteAsync (Student student);
        Task<bool> ExistsByRecordBookAsync(string recordBookNumber);
    }
}

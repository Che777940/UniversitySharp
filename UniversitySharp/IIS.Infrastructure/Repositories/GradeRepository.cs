using IIS.Application.Interfaces;
using IIS.Domain.Entities.Grading;
using IIS.Domain.Entities.Identity;
using IIS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Infrastructure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _context;
        public GradeRepository(ApplicationDbContext context) => _context = context;

        public async Task<Grade?> GetByIdAsync(Guid id)
        {
            return await _context.Grades.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<List<Grade>> GetByStudentIdAsync(Guid studentId)
        {
            return await _context.Grades
                .Include(g => g.Course)
                    .ThenInclude(c => c.Subject) 
                .Include(g => g.Course)
                    .ThenInclude(c => c.Teacher) 
                .Where(g => g.StudentId == studentId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(Grade grade)
        {
            await _context.Grades.AddAsync(grade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Grade grade)
        {
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
        }
    }
}

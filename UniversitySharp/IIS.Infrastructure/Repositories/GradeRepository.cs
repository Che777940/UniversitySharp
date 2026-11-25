using IIS.Application.Interfaces;
using IIS.Domain.Entities.Grading;
using IIS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IIS.Infrastructure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _context;
        public GradeRepository(ApplicationDbContext context) => _context = context;

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
    }
}

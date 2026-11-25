using IIS.Application.Interfaces;
using IIS.Domain.Entities.Academics;
using IIS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IIS.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context) => _context = context;

        public async Task<List<Course>> GetAllAsync()
        {
           
            return await _context.Courses
                .Include(c => c.Subject)
                .Include(c => c.Teacher)
                .Include(c => c.Group)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }
    }
}

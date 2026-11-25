using IIS.Application.Interfaces;
using IIS.Domain.Entities.Structure;
using IIS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IIS.Infrastructure.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly ApplicationDbContext _context;
        public FacultyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Faculty>> GetAllAsync()
        {
            return await _context.Faculties
                .Include(f => f.Departments) 
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Faculty?> GetByIdAsync(Guid id)
        {
            return await _context.Faculties
                .Include(f => f.Departments)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddAsync(Faculty faculty)
        {
            await _context.Faculties.AddAsync(faculty);
            await _context.SaveChangesAsync();
        }
    }
}

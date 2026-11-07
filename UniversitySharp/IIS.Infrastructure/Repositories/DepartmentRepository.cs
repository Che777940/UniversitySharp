using IIS.Application.Interfaces;
using IIS.Domain.Entities.Structure;
using IIS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context) => _context = context;

        public async Task<List<Department>> GetAllAsync() => await _context.Departments.AsNoTracking().ToListAsync();

        public async Task AddAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
        }
    }
}

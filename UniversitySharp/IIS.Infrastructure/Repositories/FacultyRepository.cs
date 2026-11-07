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
        public FacultyRepository(ApplicationDbContext context) => _context = context;

        public async Task<List<Faculty>> GetAllAsync() => await _context.Faculties.AsNoTracking().ToListAsync();
    }
}

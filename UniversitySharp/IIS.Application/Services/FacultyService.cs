using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using IIS.Domain.Entities.Structure;

namespace IIS.Application.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _repository;

        public FacultyService(IFacultyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Faculty>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<FacultyDetailsDto?> GetDetailsAsync(Guid id)
        {
            var faculty = await _repository.GetByIdAsync(id);
            if (faculty == null) return null;

            return new FacultyDetailsDto
            {
                Id = faculty.Id,
                Name = faculty.Name,
                ShortName = faculty.ShortName,
                Departments = faculty.Departments.ToList()
            };
        }

        public async Task CreateAsync(CreateFacultyDto dto)
        {
            var faculty = new Faculty
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                ShortName = dto.ShortName,
                CreatedAt = DateTime.UtcNow
            };
            await _repository.AddAsync(faculty);
        }
    }
}

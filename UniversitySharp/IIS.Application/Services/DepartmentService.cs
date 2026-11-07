using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<IIS.Domain.Entities.Structure.Department>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task CreateAsync(CreateDepartmentDto dto)
        {
            var department = new IIS.Domain.Entities.Structure.Department
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                FacultyId = dto.FacultyId,
                CreatedAt = DateTime.UtcNow
            };
            await _repository.AddAsync(department);
        }
    }
}

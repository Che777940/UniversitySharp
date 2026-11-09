using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using IIS.Domain.Entities.Identity;

namespace IIS.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;

        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task CreateAsync(CreateTeacherDto dto)
        {
            var teacher = new IIS.Domain.Entities.Identity.Teacher
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Degree = dto.Degree,
                DepartmentId = dto.DepartmentId,
                UserId = Guid.NewGuid(), 
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(teacher);
        }
    }
}

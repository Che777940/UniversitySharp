using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using IIS.Domain.Entities.Academics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;

        public SubjectService(ISubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Subject>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task CreateAsync(CreateSubjectDto dto)
        {
            var subject = new Subject
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Credits = dto.Credits,
                CreatedAt = DateTime.UtcNow
            };
            await _repository.AddAsync(subject);
        }
    }
}

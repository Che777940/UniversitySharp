using IIS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using IIS.Application.DTOs;
using IIS.Domain.Entities.Scheduling;

namespace IIS.Application.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly IClassroomRepository _repository;

        public ClassroomService(IClassroomRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Classroom>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task CreateAsync(CreateClassroomDto dto)
        {
            var classroom = new IIS.Domain.Entities.Scheduling.Classroom
            {
                Id = Guid.NewGuid(),
                Number = dto.Number,
                Building = dto.Building,
                Capacity = dto.Capacity,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(classroom);
        }
    }
}

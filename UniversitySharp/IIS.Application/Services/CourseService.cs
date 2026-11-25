using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<IIS.Domain.Entities.Academics.Course>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task CreateAsync(CreateCourseDto dto)
        {
            var course = new IIS.Domain.Entities.Academics.Course
            {
                Id = Guid.NewGuid(),
                SubjectId = dto.SubjectId,
                TeacherId = dto.TeacherId,
                GroupId = dto.GroupId,
                Semester = dto.Semester,
                AcademicYear = dto.AcademicYear,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(course);
        }
    }
}

using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _repository;

        public GradeService(IGradeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GradeDto>> GetStudentGradesAsync(Guid studentId)
        {
            var grades = await _repository.GetByStudentIdAsync(studentId);

            return grades.Select(g => new GradeDto
            {
                Id = g.Id,
                SubjectName = g.Course?.Subject?.Name ?? "Неизвестный предмет",
                TeacherName = g.Course?.Teacher != null ? $"{g.Course.Teacher.LastName} {g.Course.Teacher.FirstName}" : "Неизвестно",
                Value = g.Value,
                Date = g.Date,
                Comment = g.Comment
            }).ToList();
        }

        public async Task AddGradeAsync(CreateGradeDto dto)
        {
            var grade = new IIS.Domain.Entities.Grading.Grade
            {
                Id = Guid.NewGuid(),
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                Value = dto.Value,
                Date = DateTime.UtcNow,
                Comment = dto.Comment,
                CreatedAt = DateTime.UtcNow
            };
            await _repository.AddAsync(grade);
        }
    }
}

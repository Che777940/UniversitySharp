using IIS.Application.DTO_s.Student;
using IIS.Application.Interfaces;
using IIS.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDto?> GetByIdAsync (Guid id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null) return null;

            return new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                RecordBookNumber = student.RecordBookNumber,
                GroupName = student.Group?.Name ?? "Неизвестная группа"
            };
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();

            return students.Select(s => new StudentDto
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                RecordBookNumber = s.RecordBookNumber,
                GroupName = s.Group?.Name ?? "Неизвестная группа"
            }).ToList();
        }


        public async Task<Guid> CreateAsync(CreateStudentDto dto)
        {
            var exists = await _studentRepository.ExistsByRecordBookAsync(dto.RecordBookNumber);
            if (exists)
            {
                throw new Exception("Студент с таким номером зачетной книжки уже существует.");
            }

            var newStudent = new Student
            {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName= dto.LastName,
            RecordBookNumber= dto.RecordBookNumber,
            GroupId = dto.GroupId,
            CreatedAt = DateTime.UtcNow
            };

            await _studentRepository.AddAsync(newStudent);
            return newStudent.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                throw new Exception("Студент не найден");
            }

            await _studentRepository.DeleteAsync(student);
        }
    }
}

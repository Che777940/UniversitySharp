using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using IIS.Domain.Entities.Identity;
using IIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;

        public AuthService(IUserRepository userRepository, IStudentRepository studentRepository, ITeacherRepository teacherRepository)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<User?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null) return null;

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash)) return null;

            return user;
        }

        public async Task RegisterStudentAsync(RegisterStudentDto dto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = UserRole.Student,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            await _userRepository.AddAsync(user);

            var student = new Student
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                RecordBookNumber = dto.RecordBookNumber,
                GroupId = dto.GroupId,
                CreatedAt = DateTime.UtcNow
            };
            await _studentRepository.AddAsync(student);
        }

        public async Task RegisterTeacherAsync(RegisterTeacherDto dto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = UserRole.Teacher,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            await _userRepository.AddAsync(user);

            var teacher = new Teacher
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Degree = dto.Degree,
                DepartmentId = dto.DepartmentId,
                CreatedAt = DateTime.UtcNow
            };
            await _teacherRepository.AddAsync(teacher);
        }
    }
}

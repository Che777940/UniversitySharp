using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;

        public ScheduleService(
            IScheduleRepository scheduleRepository,
            IStudentRepository studentRepository,
            ITeacherRepository teacherRepository)
        {
            _scheduleRepository = scheduleRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<List<ScheduleDto>> GetAllAsync()
        {
            var schedules = await _scheduleRepository.GetAllAsync();
            return MapToDto(schedules);
        }

        public async Task<List<ScheduleDto>> GetForTeacherAsync(Guid userId)
        {
            var teacher = (await _teacherRepository.GetAllAsync()).FirstOrDefault(t => t.UserId == userId);
            if (teacher == null) return new List<ScheduleDto>();

            var schedules = await _scheduleRepository.GetByTeacherIdAsync(teacher.Id);
            return MapToDto(schedules);
        }

        public async Task<List<ScheduleDto>> GetForStudentAsync(Guid userId)
        {
            var student = (await _studentRepository.GetAllAsync()).FirstOrDefault(s => s.UserId == userId);
            if (student == null) return new List<ScheduleDto>();

            var schedules = await _scheduleRepository.GetByGroupIdAsync(student.GroupId);
            return MapToDto(schedules);
        }

        public async Task CreateAsync(CreateScheduleDto dto)
        {
            var schedule = new IIS.Domain.Entities.Scheduling.Schedule
            {
                Id = Guid.NewGuid(),
                CourseId = dto.CourseId,
                ClassroomId = dto.ClassroomId,
                DayOfWeek = dto.DayOfWeek,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                LessonType = dto.LessonType,
                CreatedAt = DateTime.UtcNow
            };
            await _scheduleRepository.AddAsync(schedule);
        } 
        private List<ScheduleDto> MapToDto(List<IIS.Domain.Entities.Scheduling.Schedule> schedules)
        {
            return schedules.Select(s => new ScheduleDto
            {
                Id = s.Id,
                DayOfWeek = s.DayOfWeek.ToString(),
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                SubjectName = s.Course?.Subject?.Name ?? "",
                TeacherName = s.Course?.Teacher != null ? $"{s.Course.Teacher.LastName} {s.Course.Teacher.FirstName}" : "",
                GroupName = s.Course?.Group?.Name ?? "",
                Classroom = s.Classroom != null ? $"{s.Classroom.Building}, ауд. {s.Classroom.Number}" : "",
                LessonType = s.LessonType.ToString()
            }).OrderBy(s => s.DayOfWeek).ThenBy(s => s.StartTime).ToList();
        }
    }
}

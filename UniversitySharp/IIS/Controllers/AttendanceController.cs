using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using IIS.Domain.Entities.Grading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IIS.Controllers
{
    [Authorize]
    public class AttendanceController : Controller
    {
        private readonly IScheduleRepository _scheduleRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly IAttendanceRepository _attendanceRepo;

        public AttendanceController(IScheduleRepository scheduleRepo, IStudentRepository studentRepo, IAttendanceRepository attendanceRepo)
        {
            _scheduleRepo = scheduleRepo;
            _studentRepo = studentRepo;
            _attendanceRepo = attendanceRepo;
        }

        [Authorize(Roles = "Admin,Teacher")]
        [HttpGet]
        public async Task<IActionResult> Mark(Guid scheduleId)
        {
            var schedule = (await _scheduleRepo.GetAllAsync()).FirstOrDefault(s => s.Id == scheduleId);
            if (schedule == null) return NotFound();

            var students = (await _studentRepo.GetAllAsync()).Where(s => s.GroupId == schedule.Course.GroupId).ToList();

            var existingRecords = await _attendanceRepo.GetByScheduleIdAndDateAsync(scheduleId, DateTime.UtcNow.Date);

            var model = new AttendanceDto
            {
                ScheduleId = scheduleId,
                Date = DateTime.UtcNow.Date,
                Students = students.Select(s => new StudentAttendanceDto
                {
                    StudentId = s.Id,
                    FullName = $"{s.LastName} {s.FirstName}",
                    IsPresent = existingRecords.FirstOrDefault(a => a.StudentId == s.Id)?.IsPresent ?? true,
                    Reason = existingRecords.FirstOrDefault(a => a.StudentId == s.Id)?.Reason
                }).ToList()
            };

            ViewBag.SubjectName = schedule.Course.Subject.Name;
            return View(model);
        }

        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost]
        public async Task<IActionResult> Mark(AttendanceDto model)
        {
            var attendances = model.Students.Select(s => new Attendance
            {
                Id = Guid.NewGuid(),
                StudentId = s.StudentId,
                ScheduleId = model.ScheduleId,
                Date = model.Date,
                IsPresent = s.IsPresent,
                Reason = s.Reason
            }).ToList();

            await _attendanceRepo.AddRangeAsync(attendances);
            TempData["Success"] = "Посещаемость сохранена!";
            return RedirectToAction("Index", "Schedule");
        }

        [Authorize(Roles = "Student")]
        public async Task<IActionResult> MyAttendance()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(userIdStr!);
            var student = (await _studentRepo.GetAllAsync()).FirstOrDefault(s => s.UserId == userId);

            if (student == null) return NotFound();

            var records = await _attendanceRepo.GetByStudentIdAsync(student.Id);
            return View(records);
        }
    }
}

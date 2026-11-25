using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using IIS.Application.Services;
using IIS.Domain.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace IIS.Controllers
{
    [Authorize] 
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;
        private readonly ICourseRepository _courseRepository;
        private readonly IClassroomRepository _classroomRepository;

        public ScheduleController(IScheduleService scheduleService, ICourseRepository courseRepository, IClassroomRepository classroomRepository)
        {
            _scheduleService = scheduleService;
            _courseRepository = courseRepository;
            _classroomRepository = classroomRepository;
        }

        public async Task<IActionResult> Index()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(userIdStr!);

            List<ScheduleDto> schedule;

            if (User.IsInRole("Admin"))
            {
                schedule = await _scheduleService.GetAllAsync();
                ViewBag.IsAdmin = true;
            }
            else if (User.IsInRole("Teacher"))
            {
                schedule = await _scheduleService.GetForTeacherAsync(userId);
                ViewBag.IsAdmin = false;
            }
            else
            {
                schedule = await _scheduleService.GetForStudentAsync(userId);
                ViewBag.IsAdmin = false;
            }

            return View(schedule);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            await LoadDropdownsAsync();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateScheduleDto dto)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync(dto);
                return View(dto);
            }

            await _scheduleService.CreateAsync(dto);
            TempData["Success"] = "Занятие добавлено в расписание!";
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadDropdownsAsync(CreateScheduleDto? dto = null)
        {
            var courses = await _courseRepository.GetAllAsync();
            var courseList = courses.Select(c => new { c.Id, Name = $"{c.Subject?.Name} (Гр. {c.Group?.Name})" });
            ViewBag.Courses = new SelectList(courseList, "Id", "Name", dto?.CourseId);

            var classrooms = await _classroomRepository.GetAllAsync();
            var classroomList = classrooms.Select(c => new { c.Id, Name = $"{c.Building} - {c.Number}" });
            ViewBag.Classrooms = new SelectList(classroomList, "Id", "Name", dto?.ClassroomId);
        }
    }
}

using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using IIS.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IIS.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IGroupRepository _groupRepository;

        public CoursesController(
            ICourseService courseService,
            ISubjectRepository subjectRepository,
            ITeacherRepository teacherRepository,
            IGroupRepository groupRepository)
        {
            _courseService = courseService;
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
            _groupRepository = groupRepository;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllAsync();
            return View(courses);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadViewBagsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseDto dto)
        {
            if (!ModelState.IsValid)
            {
                await LoadViewBagsAsync(dto);
                return View(dto);
            }

            await _courseService.CreateAsync(dto);
            TempData["Success"] = "Курс успешно создан!";
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadViewBagsAsync(CreateCourseDto? dto = null)
        {
            var subjects = await _subjectRepository.GetAllAsync();
            var teachers = await _teacherRepository.GetAllAsync();
            var groups = await _groupRepository.GetAllAsync();

            ViewBag.Subjects = new SelectList(subjects, "Id", "Name", dto?.SubjectId);

            var teacherList = teachers.Select(t => new { t.Id, FullName = $"{t.LastName} {t.FirstName}" });
            ViewBag.Teachers = new SelectList(teacherList, "Id", "FullName", dto?.TeacherId);

            ViewBag.Groups = new SelectList(groups, "Id", "Name", dto?.GroupId);
        }
    }
}

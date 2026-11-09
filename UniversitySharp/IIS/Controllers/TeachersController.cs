using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using IIS.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IIS.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IDepartmentRepository _departmentRepository;

        public TeachersController(ITeacherService teacherService, IDepartmentRepository departmentRepository)
        {
            _teacherService = teacherService;
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var teachers = await _teacherService.GetAllAsync();
            return View(teachers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var departments = await _departmentRepository.GetAllAsync();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherDto dto)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentRepository.GetAllAsync();
                ViewBag.Departments = new SelectList(departments, "Id", "Name", dto.DepartmentId);
                return View(dto);
            }

            await _teacherService.CreateAsync(dto);
            TempData["Success"] = "Преподаватель успешно добавлен!";
            return RedirectToAction(nameof(Index));
        }
    }
}

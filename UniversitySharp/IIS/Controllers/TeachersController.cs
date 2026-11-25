using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using IIS.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IIS.Controllers
{
    [Authorize]
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IAuthService _authService;

        public TeachersController(ITeacherService teacherService, IDepartmentRepository departmentRepository, IAuthService authService)
        {
            _teacherService = teacherService;
            _departmentRepository = departmentRepository;
            _authService = authService;
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

            var registerDto = new RegisterTeacherDto
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Degree = dto.Degree,
                DepartmentId = dto.DepartmentId,
                Email = dto.Email,
                Password = dto.Password
            };

            await _authService.RegisterTeacherAsync(registerDto);
            TempData["Success"] = "Преподаватель успешно добавлен и может войти в систему!";
            return RedirectToAction(nameof(Index));
        }
    }
}

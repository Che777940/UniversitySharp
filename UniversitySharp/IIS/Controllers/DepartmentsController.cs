using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using IIS.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IIS.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IFacultyRepository _facultyRepository;

        public DepartmentsController(IDepartmentService departmentService, IFacultyRepository facultyRepository)
        {
            _departmentService = departmentService;
            _facultyRepository = facultyRepository;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetAllAsync();
            return View(departments);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var faculties = await _facultyRepository.GetAllAsync();
            ViewBag.Faculties = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(faculties, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentDto dto)
        {
            if (!ModelState.IsValid)
            {
                var faculties = await _facultyRepository.GetAllAsync();
                ViewBag.Faculties = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(faculties, "Id", "Name");
                return View(dto);
            }

            await _departmentService.CreateAsync(dto);
            TempData["Success"] = "Кафедра успешно создана!";
            return RedirectToAction(nameof(Index));
        }
    }
}

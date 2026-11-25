using IIS.Application.DTOs;
using IIS.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IIS.Controllers
{
    [Authorize] 
    public class FacultiesController : Controller
    {
        private readonly IFacultyService _facultyService;

        public FacultiesController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        public async Task<IActionResult> Index()
        {
            var faculties = await _facultyService.GetAllAsync();
            return View(faculties);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var faculty = await _facultyService.GetDetailsAsync(id);
            if (faculty == null) return NotFound();
            return View(faculty);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateFacultyDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _facultyService.CreateAsync(dto);
            TempData["Success"] = "Факультет успешно создан!";
            return RedirectToAction(nameof(Index));
        }
    }
}

using IIS.Application.DTOs;
using IIS.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IIS.Controllers
{
    public class ClassroomsController : Controller
    {
        private readonly IClassroomService _classroomService;

        public ClassroomsController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        public async Task<IActionResult> Index()
        {
            var classrooms = await _classroomService.GetAllAsync();
            return View(classrooms);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClassroomDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _classroomService.CreateAsync(dto);
            TempData["Success"] = "Аудитория успешно добавлена!";
            return RedirectToAction(nameof(Index));
        }
    }
}

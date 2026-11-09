using IIS.Application.DTOs;
using IIS.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IIS.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectService _service;
        public SubjectsController(ISubjectService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubjectDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            await _service.CreateAsync(dto);
            TempData["Success"] = "Дисциплина успешно добавлена!";
            return RedirectToAction(nameof(Index));
        }
    }
}

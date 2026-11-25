using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using IIS.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IIS.Controllers
{

    [Authorize(Roles = "Admin")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IGroupRepository _groupRepository;

        private readonly IGradeService _gradeService;

        public StudentsController(IStudentService studentService, IGroupRepository groupRepository, IGradeService gradeService)
        {
            _studentService = studentService;
            _groupRepository = groupRepository;
            _gradeService = gradeService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var groups = await _groupRepository.GetAllAsync();
            ViewBag.Groups = new SelectList(groups, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
            {
                var groups = await _groupRepository.GetAllAsync();
                ViewBag.Groups = new SelectList(groups, "Id", "Name", dto.GroupId);
                return View(dto);
            }

            try
            {
                await _studentService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var groups = await _groupRepository.GetAllAsync();
                ViewBag.Groups = new SelectList(groups, "Id", "Name", dto.GroupId);
                return View(dto);
            }
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Grades(Guid id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null) return NotFound();

            var grades = await _gradeService.GetStudentGradesAsync(id);

            ViewBag.StudentName = $"{student.LastName} {student.FirstName}";
            ViewBag.StudentId = id;

            return View(grades);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _studentService.DeleteAsync(id);
                TempData["Success"] = "Студент успешно удален!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Не удалось удалить студента. Возможно, у него есть связанные данные (оценки, посещаемость).";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

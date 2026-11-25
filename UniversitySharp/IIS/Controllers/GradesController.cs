using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using IIS.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IIS.Controllers
{
    [Authorize(Roles = "Admin,Teacher")] 
    public class GradesController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public GradesController(IGradeService gradeService, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _gradeService = gradeService;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid? studentId)
        {
            await LoadDropdownsAsync(studentId);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGradeDto dto)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync(dto.StudentId, dto.CourseId);
                return View(dto);
            }

            await _gradeService.AddGradeAsync(dto);
            TempData["Success"] = "Оценка выставлена!";

            if (dto.StudentId != Guid.Empty)
                return RedirectToAction("Grades", "Students", new { id = dto.StudentId });

            return RedirectToAction("Index", "Home");
        }

        private async Task LoadDropdownsAsync(Guid? studentId = null, Guid? courseId = null)
        {
            var students = await _studentRepository.GetAllAsync();
            var studentList = students.Select(s => new { s.Id, FullName = $"{s.LastName} {s.FirstName} ({s.Group?.Name})" });
            ViewBag.Students = new SelectList(studentList, "Id", "FullName", studentId);

            var courses = await _courseRepository.GetAllAsync();
            var courseList = courses.Select(c => new { c.Id, Name = $"{c.Subject?.Name} (Гр. {c.Group?.Name})" });
            ViewBag.Courses = new SelectList(courseList, "Id", "Name", courseId);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Delete(Guid id, Guid studentId)
        {
            await _gradeService.DeleteAsync(id);
            TempData["Success"] = "Оценка удалена.";
            return RedirectToAction("Grades", "Students", new { id = studentId }); 
        }
    }
}

using IIS.Application.DTOs;
using IIS.Application.Interfaces;
using IIS.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IIS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    [Authorize(Roles = "Admin")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IGroupRepository _groupRepository;

        public StudentsController(IStudentService studentService, IGroupRepository groupRepository)
        {
            _studentService = studentService;
            _groupRepository = groupRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var groups = await _groupRepository.GetAllAsync();
            ViewBag.Groups = new SelectList(groups, "Id", "Name");
            return View();
        }


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
    }
}
